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
    public class NotificacoesController : ControllerBase
    {
        private INotificacoes _notificacoesRepository { get; set; }

        public NotificacoesController()
        {
            _notificacoesRepository = new NotificacaoRepository();
        }
        [HttpPost]
        public IActionResult Post(NotificacaoViewModel notificacao)
        {
            try
            {
                _notificacoesRepository.Cadastrar(notificacao);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get() 
        {

            try
            {
                return Ok(_notificacoesRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id) 
        {

            try
            {
                _notificacoesRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
