using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FiorentionoDesktop.ViewModels
{
    public class Ranking
    {
        public int Posicao { get; set; }
        public byte[] Bandeira { get; set; }
        public string Nome { get; set; }
        public int Pontos { get; set; }
        public int PartidasJogadas { get; set; }
        public int Vitorias { get; set; }
        public int Empates { get; set; }
        public int Derrotas { get; set; }
        public int GolsPro { get; set; }
        public int GolsContra { get; set; }
        public int SaldoGols { get; set; } 

    }
}
