using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class CadastrarRelato
    {
        public int usuarioId { get; set; }

        public string Relato { get; set; }
        public string Imagem { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

    }
}
