using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroondasDigital.Business.Models
{
    public class ProgramaPredefinido
    {
        public string Nome { get; set; }
        public int Tempo { get; set; } // Em segundos
        public int Potencia { get; set; }
        public string Instrucao { get; set; }
        public char CaractereAquecimento { get; set; }

        public ProgramaPredefinido(string nome, int tempo, int potencia, string instrucao, char caractere)
        {
            Nome = nome;
            Tempo = tempo;
            Potencia = potencia;
            Instrucao = instrucao;
            CaractereAquecimento = caractere;
        }
    }
}
