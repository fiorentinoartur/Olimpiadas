using FiorentionoDesktop.Model;
using FiorentionoDesktop.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiorentionoDesktop
{
    
    internal static class Program
    {

       static Settings settings = Settings.Default;
      static  ModuloDesktopEntities ctx = new ModuloDesktopEntities();
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (settings.keep)
            {
                var logado = ctx.Usuarios.Find(settings.idUser);
                Application.Run(new PrincipalForm(logado));

            }
            else
            {
                Application.Run(new Form1());
            }
        }
    }

    public static class ME
    {
        public static DialogResult Information(this string text)
        {
            return MessageBox.Show(text, "WsTowers - Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult Confirmation(this string text)
        {
            return MessageBox.Show(text, "WsTowers - Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static DialogResult Alert(this string text)
        {
            return MessageBox.Show(text, "WsTowers - Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
