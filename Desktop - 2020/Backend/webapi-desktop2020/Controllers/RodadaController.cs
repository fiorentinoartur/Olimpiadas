using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi_desktop2020.Interfaces;
using webapi_desktop2020.Repositories;

namespace webapi_desktop2020.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class RodadaController : ControllerBase
    {
        private IRodada _rodadaRepository { get; set; }

        public RodadaController()
        {
            _rodadaRepository = new RodadaRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
               
                return Ok(_rodadaRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
