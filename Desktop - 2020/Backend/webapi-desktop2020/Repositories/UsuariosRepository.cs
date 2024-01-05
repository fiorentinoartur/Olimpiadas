using System.Reflection;
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

        public Usuario BuscarPorId(int id)
        {

            var user = ctx.Usuarios.Select(x => new Usuario
            {
                Id = x.Id,
                Nome = x.Nome,
                Email = x.Email,
                Senha = x.Senha,
                Nascimento = x.Nascimento,
                Foto = x.Foto,
                Sexo = x.Sexo,
                TimeFavoritoId = x.TimeFavoritoId,
                Perfil = x.Perfil,
            }).FirstOrDefault(x => x.Id == id);


            return user;


        }


        public static string ConverterImagem(byte[] imagemBytes)
        {
            if (imagemBytes != null && imagemBytes.Length > 0)
            {
                return $"data:image/*;base64,{Convert.ToBase64String(imagemBytes)}";
            }
            return null;
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


                if (usuario.Foto == null)
                {
                    string fotoPadrao = "SemFoto.jpg";
                    string diretorioAtual = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    string caminhoArquivo = Path.Combine(diretorioAtual, fotoPadrao);

                    using (var fileStream = new FileStream(caminhoArquivo, FileMode.Open))
                    using (var memoryStream = new MemoryStream())
                    {
                        fileStream.CopyTo(memoryStream);
                        user.Foto = memoryStream.ToArray();
                    }
                }
                else
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        usuario.Foto.CopyTo(memoryStream);
                        user.Foto = memoryStream.ToArray();
                    }
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

            return ctx.Usuarios.Select(x => new Usuario
            {
                Id = x.Id,
                Nome = x.Nome,
                Email = x.Email,
                Senha = x.Senha,
                Nascimento = x.Nascimento,
                Foto = x.Foto,
                Sexo = x.Sexo,
                TimeFavoritoId = x.TimeFavoritoId,
                Perfil = x.Perfil,
            }).ToList();
        }
    }
}
