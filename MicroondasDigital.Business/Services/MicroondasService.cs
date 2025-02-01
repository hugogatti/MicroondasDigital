using MicroondasDigital.Business.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MicroondasDigital.Business.Services
{
    public class MicroondasService : IMicroondasService
    {
        private bool _aquecendo;
        private bool _pausado;
        private int _tempoRestante;
        private int _potencia;
        private string _stringAquecimento;
        private CancellationTokenSource _cancellationTokenSource;

        public bool Aquecendo => _aquecendo;
        public bool Pausado => _pausado;
        public string StringAquecimento => _stringAquecimento;
        public string TempoFormatado => $"{_tempoRestante / 60:D2}:{_tempoRestante % 60:D2}";

        public async Task<string> IniciarAquecimento(int tempo, int potencia)
        {
            if (_aquecendo)
            {
                // Acréscimo de 30 segundos
                _tempoRestante = Math.Min(_tempoRestante + 30, 120);
                return $"Tempo acrescido. Novo tempo: {_tempoRestante} segundos.";
            }

            // Validar o tempo e a potência
            if (tempo < 1 || tempo > 120)
                throw new ArgumentException("O tempo deve estar entre 1 segundo e 2 minutos.");
            if (potencia < 1 || potencia > 10)
                throw new ArgumentException("Potência deve estar entre 1 e 10.");

            _tempoRestante = tempo;
            _potencia = potencia;
            _aquecendo = true;
            _pausado = false;
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await ContagemRegressiva(_cancellationTokenSource.Token);
            }
            catch (TaskCanceledException)
            {
                return _pausado ? "Aquecimento pausado" : "Aquecimento cancelado";
            }

            return _tempoRestante == 0 ? "Aquecimento concluído" : "Aquecimento interrompido";        
        }

        public async Task<string> PausarAquecimento()
        {
            if (!_aquecendo)
                return "Nenhum aquecimento em andamento";

            _pausado = true;
            _aquecendo = false;
            _cancellationTokenSource?.Cancel();

            await Task.Delay(100); // Pequeno delay para garantir a interrupção

            return "Aquecimento pausado";
        }

        public async Task<string> CancelarAquecimento()
        {
            if (!_aquecendo && !_pausado)
                return "Nenhum aquecimento em andamento.";

            _cancellationTokenSource?.Cancel();
            _tempoRestante = 0;
            _stringAquecimento = "";
            _pausado = false;
            _aquecendo = false;

            await Task.Delay(100); // Pequeno delay para garantir interrupção

            return "Aquecimento cancelado";
        }

        private async Task ContagemRegressiva(CancellationToken cancellationToken)
        {
            while (_tempoRestante > 0 && !cancellationToken.IsCancellationRequested)
            {
                if (_pausado)
                {
                    await Task.Delay(500, cancellationToken); // Reduz tempo de espera para menor impacto nos testes
                    continue;
                }

                _stringAquecimento = $"{TempoFormatado} " + new string('*', _potencia);
                _tempoRestante--;
                await Task.Delay(1000, cancellationToken);
            }

            if (_tempoRestante == 0 && !cancellationToken.IsCancellationRequested)
            {
                _stringAquecimento = "00:00 Aquecimento concluído.";
                _aquecendo = false;
            }
        }

        public string GerarStringAquecimento(int potencia)
        {
            if (potencia < 1 || potencia > 10)
            {
                throw new ArgumentException("Potência deve estar entre 1 e 10.");
            }

            return new string('*', potencia); // Retorna uma string com "*" baseado na potência
        }

        public async Task<string> AcrescentarTempo()
        {
            if (!_aquecendo)
            {
                return "Tempo acrescido";
            }

            _tempoRestante = Math.Min(_tempoRestante + 30, 120);
            return $"Tempo acrescido";
        }

        public int ConverterTempoEmSegundos(string tempo)
        {
            if (tempo.Contains(":")) // Formato MM:SS
            {
                var partes = tempo.Split(':');
                if (partes.Length != 2 || !int.TryParse(partes[0], out int minutos) || !int.TryParse(partes[1], out int segundos))
                {
                    throw new FormatException("Formato inválido. Use MM:SS.");
                }
                return minutos * 60 + segundos;
            }
            else if (tempo.Length == 4 && int.TryParse(tempo.Substring(0, 2), out int min) && int.TryParse(tempo.Substring(2, 2), out int seg))
            {
                return min * 60 + seg;
            }
            else
            {
                throw new FormatException("Formato inválido. MM:SS.");
            }
        }
    }
}
