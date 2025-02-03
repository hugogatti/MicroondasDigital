using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroondasDigital.Business.Interfaces;
using MicroondasDigital.Business.Models;

namespace MicroondasDigital.Business.Services
{
    public class ProgramaService : IProgramaService
    {
        private readonly IMicroondasService _microondasService;
        private readonly List<ProgramaPredefinido> _programas;

        public ProgramaService(IMicroondasService microondasService)
        {
            _microondasService = microondasService;
            _programas = new List<ProgramaPredefinido>
            {
                new ProgramaPredefinido("Pipoca", 60, 7, "Utilize um recipiente adequado para micro-ondas.", '*'),
                new ProgramaPredefinido("Leite", 30, 5, "Mexa o leite após o aquecimento.", '~'),
                new ProgramaPredefinido("Arroz", 120, 8, "Adicione água suficiente para cozimento.", '#'),
                new ProgramaPredefinido("Feijão", 180, 9, "Deixe de molho antes de aquecer.", '+'),
                new ProgramaPredefinido("Carne", 90, 6, "Corte em pedaços pequenos antes de aquecer.", '@')
            };
        }

        public List<ProgramaPredefinido> ObterTodosProgramas() => _programas;

        public ProgramaPredefinido ObterPrograma(string nome)
        {
            return _programas.FirstOrDefault(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<string> IniciarPrograma(string nome)
        {
            var programa = ObterPrograma(nome);
            if (programa == null)
                return "Programa não encontrado.";

            return await _microondasService.IniciarAquecimento(programa.Tempo, programa.Potencia);
        }
    }
}
