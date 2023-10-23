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
        private IRanking _participanteRepository { get; set; }


        public ParticipanteController()
        {
            _participanteRepository = new RankingRepository();
        }
        /// <summary>
        /// gfsdgsfdfgsdgs
        /// </summary>
        /// <param name="name">sgfsdgsgs</param>
        /// <returns>gfsdgsfgsg</returns>
        [HttpGet]
        public IActionResult GetByName(string name)
        {
            try
            {
                Ranking participanteBuscado = _participanteRepository.BuscarPeloNome(name);
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
        [HttpGet("{pontos}")]
        public IActionResult GetByPoints(int points) 
        { 
        try
            {
                List<Ranking> participanteBuscado = _participanteRepository.BuscarPelaPontuação(points);
                if (participanteBuscado.Count == 0)
                {
                    return NotFound("Nenhum participante  encontrado encontrado!");
                }
                return Ok(participanteBuscado);
            }
            catch(Exception e) 
            { 
            return BadRequest(e.Message);
            }
        }

    }
}