using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi_desktop2020.Domains;
using webapi_desktop2020.Repositories;
using webapi_desktop2020.Usuarios;
using webapi_desktop2020.ViewModel;

namespace webapi_desktop2020.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FirstCadastroController : ControllerBase
    {
        private IUsuarios _firstCadastroRepository {  get; set; }

        public FirstCadastroController()
        {
            _firstCadastroRepository = new UsuariosRepository();
        }


        [HttpPost]
        [Consumes("multipart/form-data")]
        public IActionResult Post([FromForm] FirstCadastro usuario)
        {
            try
            {
                _firstCadastroRepository.FirstCadastro(usuario);
                return NoContent();
            }
            catch (Exception e)
            {
               
                return BadRequest(e.Message);
            }
        }
    }
}
