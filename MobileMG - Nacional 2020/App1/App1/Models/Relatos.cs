using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
   public class Relatos
    {
        public  int Id { get; set; }
        public string UserName { get; set; }
        public string Relato { get; set; }
        public string Imagem { get; set; }
        public string Telefone { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Email { get; set; }
    }
}
