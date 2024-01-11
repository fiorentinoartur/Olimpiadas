using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace wsTower
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private string user = "adm";
        private int senha = 1234;
        private int tentativasFalhas = 0;
        private DateTime? bloqueioExpiracao = null;

        public Login()
        {
            InitializeComponent();
            LblIncorreta.IsVisible = false;
            LblTempo.IsVisible = false;
        }

        private void VerificarLogin(object sender, EventArgs e)
        {
            if (IptUsuario.Text == user && IptSenha.Text == senha.ToString() )
            {
                     AppShell appShell = new AppShell();

                     Application.Current.MainPage = appShell;
            }
            else
            {
               LblIncorreta.IsVisible=true;
               tentativasFalhas++;
               
                if (tentativasFalhas >= 3)
                {
                    LblIncorreta.IsVisible = false;
                    LblTempo.IsVisible = true;

                    IptUsuario.IsEnabled = false;
                    IptSenha.IsEnabled = false;
                    btnLogin.IsEnabled = false;
                    bloqueioExpiracao = DateTime.Now.AddSeconds(5);
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Task.Delay(5000);
                        tentativasFalhas = 0;
                        IptUsuario.IsEnabled = true;
                        IptSenha.IsEnabled= true;
                        btnLogin.IsEnabled = true;
                        LblIncorreta.IsEnabled = false;
                        LblTempo.IsVisible = false;
                    });
      
                }
            }
        }
    }
}