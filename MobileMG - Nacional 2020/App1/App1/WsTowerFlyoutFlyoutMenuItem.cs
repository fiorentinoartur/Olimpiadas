﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Type TargetType { get; set; }
    }
}