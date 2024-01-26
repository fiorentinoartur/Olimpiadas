using App1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App1.ViewModels
{
    public class BaseVM
    {
        public ObservableCollection<Relatos> Relatos { get; set; } = new ObservableCollection<Relatos>();
    }
}
