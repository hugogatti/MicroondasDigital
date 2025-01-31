using MicroondasDigital.Business.Interfaces;
using System;
using System.Threading.Tasks;

namespace MicroondasDigital.Business.Services
{
    public class MicroondasService : IMicroondasService
    {
        private bool Aquecendo { get; set; }
        private int Tempo { get; set; }
        private int Potencia { get; set; }

        public async Task<string> IniciarAquecimento(int tempo, int potencia)
        {
            if (Aquecendo)
                return "Já está aquecendo.";

            // Validar o tempo
            if (tempo < 1 || tempo > 120)
                return "O tempo deve estar entre 1 segundo e 2 minutos";

            if (potencia < 1 || potencia > 10)
                potencia = 10;

            Tempo = tempo;
            Potencia = potencia;
            Aquecendo = true;

            // Simulando o aquecimento
            await Task.Delay(Tempo * 100); // Simula o tempo de aquecimento
            Aquecendo = false;

            return "Aquecimento finalizado!";
        }

        public Task<string> PausarAquecimento()
        {
            if (!Aquecendo)
                return Task.FromResult("Aquecimento pausado");

            Aquecendo = false;
            return Task.FromResult("Aquecimento pausado");
        }

        public Task<string> CancelarAquecimento()
        {
            if (!Aquecendo)
                return Task.FromResult("Aquecimento cancelado.");

            Aquecendo = false;
            return Task.FromResult("Aquecimento cancelado.");
        }
    }
}
