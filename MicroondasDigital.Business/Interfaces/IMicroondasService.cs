using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroondasDigital.Business.Interfaces
{
    public interface IMicroondasService
    {
        Task<string> IniciarAquecimento(int tempo, int potencia);
        Task<string> PausarAquecimento();
        Task<string> CancelarAquecimento();
    }
}
