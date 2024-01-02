using webapi_desktop2020.Domains;
using webapi_desktop2020.ViewModel;

namespace webapi_desktop2020.Usuarios
{
    public interface IUsuarios
    {
        List<Usuario> GetUsuarios();

        Usuario BuscarPorEmailESenha(string email, string senha);

        void AtualizarUsuarioByEmail(string email, AtualizarUsuario usuario);

        Usuario BuscarPorEmail(string email);

        public void FirstCadastro(FirstCadastro usuario);
    }
}
