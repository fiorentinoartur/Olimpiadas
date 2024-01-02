using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using webapi_desktop2020.Domains;
using webapi_desktop2020.Repositories;
using webapi_desktop2020.Usuarios;

namespace webapi_desktop2020.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarios _usuariosRepository { get; set; }

        public UsuariosController()
        {
            _usuariosRepository = new UsuariosRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {

            try
            {

                return Ok(_usuariosRepository.GetUsuarios());
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("/email")]
        public IActionResult GetByEmailSenha(string email, string senha)
        {
            try
            {
                return Ok(_usuariosRepository.BuscarPorEmailESenha(email, senha));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("/api")]
        public IActionResult GetByemail(string email) 
        {
            try
            {
                return Ok(_usuariosRepository.BuscarPorEmail(email));
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
