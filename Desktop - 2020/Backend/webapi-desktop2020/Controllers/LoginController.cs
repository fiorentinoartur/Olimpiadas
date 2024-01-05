using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi_desktop2020.Domains;
using webapi_desktop2020.Repositories;
using webapi_desktop2020.Usuarios;
using webapi_desktop2020.ViewModel;

namespace webapi_desktop2020.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private IUsuarios _usuariosRepository { get; set; }

        public LoginController()
        {
            _usuariosRepository = new UsuariosRepository();
        }





        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
         Usuario usuarioBuscado = _usuariosRepository.BuscarPorEmailESenha(usuario.Email, usuario.Senha);

            if (usuarioBuscado == null)
            {
                return StatusCode(401, "Email ou senha inválido");
            }

                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                new Claim("role", usuarioBuscado.Perfil),
          
            };


            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("desktop-webapi-chave-autenticacao-ef"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var meuToken = new JwtSecurityToken(
                issuer: "desktop.event+",
                audience: "desktop.event+",
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: creds
           
                );


            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(meuToken)
            }) ;
            }
            catch (Exception)
            {

                throw;
            }
   
        }
    }
}
