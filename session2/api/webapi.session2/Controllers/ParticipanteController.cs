using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using webapi.session2.Domains;
using webapi.session2.Interfaces;
using webapi.session2.Repositories;

namespace session2.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ParticipanteController : ControllerBase
    {
        private IParticipante _participanteRepository { get; set; }


        public ParticipanteController()
        {
            _participanteRepository = new ParticipanteRepository();
        }
        [HttpGet]
        public IActionResult GetByName(string name)
        {
            try
            {
                Participante participanteBuscado = _participanteRepository.BuscarPeloNome(name);
                if (participanteBuscado == null)
                {
                    return NotFound("Participante não encontrado!");
                }
                return Ok(participanteBuscado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}