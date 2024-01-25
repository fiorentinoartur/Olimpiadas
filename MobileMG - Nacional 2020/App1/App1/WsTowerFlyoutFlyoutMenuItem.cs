﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App1
{

    public class WsTowerFlyoutFlyoutMenuItem
    {
        public WsTowerFlyoutFlyoutMenuItem()
        {
            TargetType = typeof(WsTowerFlyoutFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Imagem { get; set; }
        public Type TargetType { get; set; }
        public ICommand Command { get; set; }
        public bool isEnable { get; set; } = true;
    }
}