using System;
using System.Collections.Generic;
using System.Text;

namespace FiorentinoApp.Models
{
   public class ProjetoItem
    {
        public string Nome { get; set; }
        public bool IsHeader { get; set; }
        public int Codigo { get; set; }
        public int CodProjeto { get; set; }
        public bool isConcluida { get; set; }
        public string Texto{ get; set; }
        public int? CodResponsavel{ get; set; }
        public DateTime DataAgendada{ get; set; }
        public string NomeResponsavel { get; set; }
    }
}

