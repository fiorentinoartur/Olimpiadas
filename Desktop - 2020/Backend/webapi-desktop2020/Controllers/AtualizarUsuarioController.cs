using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using webapi_desktop2020.Domains;
using webapi_desktop2020.Repositories;
using webapi_desktop2020.Usuarios;
using webapi_desktop2020.ViewModel;

namespace webapi_desktop2020.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class AtualizarUsuarioController : ControllerBase
    {
        private IUsuarios _usuariosRepository { get; set; }

        public AtualizarUsuarioController()
        {
            _usuariosRepository = new UsuariosRepository();
        }

        [HttpPut("{email}")]
        public IActionResult Put(
      string email,
            AtualizarUsuario usuario)
        {
            try
            {

                _usuariosRepository.AtualizarUsuarioByEmail(email, usuario);
                return NoContent();
            }
            catch (Exception e)
            {
                if (e.Message.Contains("menor de 18 anos"))
                {
                    return BadRequest("Usuário deve ter pelo menos 18 anos");
                }
                return BadRequest(e.Message);
            }
        }

    }
}
