using MicroondasDigital.Business.Models;

namespace MicroondasDigital.Business.Interfaces
{
    public interface IProgramaService
    {
        List<ProgramaPredefinido> ObterTodosProgramas();
        ProgramaPredefinido ObterPrograma(string nome);
        Task<string> IniciarPrograma(string nome);
    }
}
