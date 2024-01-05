using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi_desktop2020.Interfaces;
using webapi_desktop2020.Repositories;

namespace webapi_desktop2020.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class JogadoresController : ControllerBase
    {
        private IJogadores _jogadoresRepository { get; set; }

        public JogadoresController()
        {
            _jogadoresRepository = new JogadoresRepositorie();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_jogadoresRepository.GetJogadores());
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            try
            {
                return Ok(_jogadoresRepository.GetById(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
