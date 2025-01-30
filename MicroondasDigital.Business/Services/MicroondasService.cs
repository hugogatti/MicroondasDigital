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

            Tempo = tempo;
            Potencia = potencia;
            Aquecendo = true;

            // Simulando o aquecimento
            await Task.Delay(Tempo * 1000); // Simula o tempo de aquecimento

            Aquecendo = false;
            return "Aquecimento finalizado!";
        }

        public Task<string> PausarAquecimento()
        {
            if (!Aquecendo)
                return Task.FromResult("Não há aquecimento em andamento.");

            Aquecendo = false;
            return Task.FromResult("Aquecimento pausado.");
        }

        public Task<string> CancelarAquecimento()
        {
            if (!Aquecendo)
                return Task.FromResult("Não há aquecimento em andamento.");

            Aquecendo = false;
            return Task.FromResult("Aquecimento cancelado.");
        }
    }
}
