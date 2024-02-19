using FiorentinoApp;
using FiorentinoApp.Models;
using FiorentinoApp.Service;
using FiorentinoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FiorentinoApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TarefasPage : ContentPage
	{
        BaseVM vm = new BaseVM();
        List<ProjetoItem> tarefasFinal = new List<ProjetoItem>();
        private Projetos projeto;

        public TarefasPage()
        {
            InitializeComponent();
            BindingContext = vm;
        }
        public TarefasPage(Projetos projeto)
		{
			InitializeComponent();
            BindingContext = vm;
			this.projeto = projeto;
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
			this.Title = projeto.Nome;

			LoadDataAsync();
        }

        private async  void LoadDataAsync()
        {
            var users = await ApiService<Usuario>.GetList("Usuario/Get");
            var listaTarefas = await ApiService<ProjetoItem>.GetList("ProjetoItems/Get");
            var tarefas = listaTarefas.Where(x => x.CodProjeto == projeto.Codigo).ToList();
            var tarefasFinal = new List<ProjetoItem>();

            foreach (var item in tarefas )
            {
                if (item.CodResponsavel != null)
                {
                    item.NomeResponsavel = users.Where(x => x.Codigo == item.CodResponsavel.Value).FirstOrDefault().Nome.Substring(0, 1);
                }
              tarefasFinal.Add(item); 
            }
            PopuleItems(tarefasFinal);
            this.tarefasFinal = tarefasFinal;

        }

        public void PopuleItems(List<ProjetoItem> tarefaFinal)
        {
            vm.Tarefas.Clear();
            foreach (var item in tarefaFinal)
            {
                if(item.DataAgendada.Date == DateTime.Now)
                {
                    item.Nome = "Hoje";
                }
                else if(item.DataAgendada.Date > DateTime.Now && item.DataAgendada.Date < DateTime.Now.AddDays(7))
                {
                    item.Nome = "Semana";
                }
                else if(item.DataAgendada.Date == null)
                {
                    item.Nome = "Indefinida";
                }
                else
                {
                    item.Nome = item.DataAgendada.Date.ToShortDateString();
                }
                vm.Tarefas.Add(item);
            }

        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Modal.IsVisible = true;

        }

        private void Pendentes_Clicked(object sender, EventArgs e)
        {
            Modal.IsVisible = false;
           var newLista = tarefasFinal.Where(x => x.isConcluida == false).ToList();
            PopuleItems(newLista);
        }

        private void MyPendent_Clicked(object sender, EventArgs e)
        {
            Modal.IsVisible = false;
            var newLista = tarefasFinal.Where(x => x.isConcluida == false && x.CodResponsavel == UserDados.usuario.Codigo).ToList();
            PopuleItems(newLista);
        }

        private void MyTasks_Clicked(object sender, EventArgs e)
        {
            Modal.IsVisible = false;
            var newLista = tarefasFinal.Where(x => x.CodResponsavel == UserDados.usuario.Codigo).ToList();
            PopuleItems(newLista);
        
        }

        private void Concluidas_Clicked(object sender, EventArgs e)
        {
            Modal.IsVisible = false;
            var newLista = tarefasFinal.Where(x => x.isConcluida == true).ToList();
        }

        private void MyConcluidas_Clicked(object sender, EventArgs e)
        {
            Modal.IsVisible = false;
            var newLista = tarefasFinal.Where(x => x.isConcluida == true && x.CodResponsavel == UserDados.usuario.Codigo).ToList();
            PopuleItems(newLista);
        }

        private async void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            int id = Convert.ToInt32((sender as CheckBox).BindingContext);
           
            if(e.Value)
            {
                await ApiService<ProjetoItem>.GetToDelete($"ProjetoItems/Concluir?id={id}");

            }
            else
            {
                await ApiService<ProjetoItem>.GetToDelete($"ProjetoItems/Remover?id={id}");

            }
        }
    }
}


