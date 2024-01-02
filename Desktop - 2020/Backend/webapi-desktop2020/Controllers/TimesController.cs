using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi_desktop2020.Interfaces;
using webapi_desktop2020.Repositories;

namespace webapi_desktop2020.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class TimesController : ControllerBase
    {

        private ITimes _timesRepository { get; set; }

        public TimesController()
        {
             _timesRepository = new TimesRepository();
        }


        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                return Ok(_timesRepository.Listar());
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
