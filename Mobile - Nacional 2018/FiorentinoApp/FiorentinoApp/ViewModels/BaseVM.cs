using FiorentinoApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FiorentinoApp.ViewModels
{
    public class BaseVM : BaseViewModel
    {
        public ObservableCollection<Usuario> Usuarios { get; set; } = new ObservableCollection<Usuario>();
        public ObservableCollection<Projetos> Projetos { get; set; } = new ObservableCollection<Projetos>();
        public ObservableCollection<ProjetoItem> Tarefas { get; set; } = new ObservableCollection<ProjetoItem>();
    }
}
