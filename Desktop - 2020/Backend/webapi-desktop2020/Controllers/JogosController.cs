using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi_desktop2020.Interfaces;
using webapi_desktop2020.Repositories;
using webapi_desktop2020.ViewModel;

namespace webapi_desktop2020.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]  
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogos _jogosRepository {  get; set; }

        public JogosController()
        {
            _jogosRepository = new JogoRepositorie();
        }
        [HttpGet]
        public IActionResult Get(int rodada) 
        {
            try
            {
                return Ok(_jogosRepository.Listar(rodada));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                _jogosRepository.Cadastrar();
                return NoContent();
            }
            catch (Exception e)
            {
              return 
                BadRequest(e.InnerException);
            }
        }
        [HttpPut]
        public IActionResult Put(int jogo, AtualizarPlacar placar) 
        {
            try
            {
                _jogosRepository.atulizarPlacar(jogo,placar);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
