using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Views
{
    public class UsuarioViewModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string telefone { get; set; }
        public int funcaoid { get; set; }
    }
}