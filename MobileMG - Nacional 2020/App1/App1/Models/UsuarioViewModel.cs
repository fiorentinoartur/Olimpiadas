﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int FuncaoId { get; set; }

    }
}
