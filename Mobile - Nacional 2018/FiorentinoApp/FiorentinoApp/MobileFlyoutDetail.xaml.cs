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
    public partial class MobileFlyoutDetail : ContentPage
    {
        BaseVM vm = new BaseVM();

        public MobileFlyoutDetail()
        {
            InitializeComponent();
            BindingContext = vm;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            barraPesquisa.IsVisible = true;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadProjetos();
        }

        private async void LoadProjetos()
        {
            var projetosMembro = await ApiService<ProjetoMembro>.GetList($"ProjetosMembros/Get");

            var projetoMembro = projetosMembro.Where(x => x.CodUsuario == UserDados.usuario.Codigo);

            var projetosIds = projetoMembro.Select(x => x.CodProjeto).Distinct();

            var projetos = await Task.WhenAll(projetosIds.Select(id => ApiService<Projetos>.Get($"Projetos/Get?id={id}")));

            var projetosItems = await ApiService<ProjetoItem>.GetList("ProjetoItems/Get");

            vm.Projetos.Clear();
            foreach (var projeto in projetos)
            {
                var tarefasPendentes = projetosItems.Count(x => x.CodProjeto == projeto.Codigo && !x.isConcluida);
                projeto.Pendente = tarefasPendentes;
                vm.Projetos.Add(projeto);
            }
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var projeto = e.SelectedItem as Projetos;
            await Navigation.PushAsync(new TarefasPage(projeto));
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {

            var menuItem = ((MenuItem)sender);
            vm.Projetos.Remove((Projetos)menuItem.CommandParameter);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(inputPesquisa.Text))
            {
                LoadProjetos();
                return;
            }

            var newLista = vm.Projetos.Where(x => x.Nome.ToLower().Contains(inputPesquisa.Text)).ToList();
            vm.Projetos.Clear();

            foreach (var item in newLista)
            {

                vm.Projetos.Add(item);
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            barraPesquisa.IsVisible = false;
            barraPadrao.IsVisible = true;
        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            barraPadrao.IsVisible = false;
            barraPesquisa.IsVisible = true;
            inputPesquisa.Focus();
        }
    }
}