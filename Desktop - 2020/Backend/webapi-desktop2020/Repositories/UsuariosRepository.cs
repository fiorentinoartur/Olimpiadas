using webapi_desktop2020.Contexts;
using webapi_desktop2020.Domains;
using webapi_desktop2020.Usuarios;
using webapi_desktop2020.ViewModel;

namespace webapi_desktop2020.Repositories
{
    public class UsuariosRepository : IUsuarios
    {
        DesktopContext ctx = new DesktopContext();

        public void AtualizarUsuarioByEmail(string email, AtualizarUsuario usuario)
        {
            var usuarioBuscado = ctx.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuarioBuscado != null)
            {
                var currentDate = DateTime.Now;
                if (usuario.Nascimento != null)
                {
                    DateTime dataNascimento = usuario.Nascimento.Value;
                    if (currentDate.Year - dataNascimento.Year < 18
                        || (currentDate.Year - dataNascimento.Year == 18 &&
                        (currentDate.Month < dataNascimento.Month && currentDate.Day < dataNascimento.Day)))
                    {
                        throw new Exception("Usuario deve ter pelo menos 18 anos");
                    }
                    usuarioBuscado.Nascimento = usuario.Nascimento.Value;
                }

                if (usuario.TimeFavoritoId != 0)
                    usuarioBuscado.TimeFavoritoId = usuario.TimeFavoritoId;

                if (!string.IsNullOrEmpty(usuario.Senha))
                    usuarioBuscado.Senha = usuario.Senha;
            }

            ctx.Usuarios.Update(usuarioBuscado);
            ctx.SaveChanges();
        }

        public Usuario BuscarPorEmail(string email)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(x => x.Email == email);

            if (usuario != null)
            {
                return usuario;
            }
            else
            {
                return null;
            }
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            Usuario usuariobuscado = ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);


            return usuariobuscado;
        }

        public void FirstCadastro(FirstCadastro usuario)
        {

            try
            {

                Usuario user = new Usuario();

                user.Nome = usuario.Nome;
                user.Sexo = usuario.Sexo;
                user.TimeFavoritoId = usuario.TimeFavoritoId;
                user.Nascimento = usuario.Nascimento;
                user.Email = usuario.Email;
                user.Senha = usuario.Senha;
                user.Perfil = usuario.Perfil;



                using (MemoryStream memoryStream = new MemoryStream())
                {
                    usuario.Foto.CopyTo(memoryStream);
                    user.Foto = memoryStream.ToArray();
                }



                ctx.Add(user);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                // Tratamento de exceções: registe, lance ou manipule conforme necessário.
                Console.WriteLine($"Erro durante o cadastro: {ex.Message}");
                throw;
            }

        }

        public List<Usuario> GetUsuarios()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
