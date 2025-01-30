using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroondasDigital.Business.Models
{
    public class Microondas
    {
        public int Tempo { get; set; }
        public int Potencia { get; set; }
        public string Status { get; set; }  // "Em andamento", "Pausado", "Cancelado", etc.
        public DateTime HoraInício { get; set; }
    }
}
