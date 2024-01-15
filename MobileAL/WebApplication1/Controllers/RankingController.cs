using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        RankingRepository repository = new RankingRepository();


        [HttpGet]
        public IActionResult GetRaking()
        {
            var lista = repository.CalculateRanking();

            return Ok(lista);
        }

        [HttpGet("<{score}")]
        public IActionResult GetMinimiumScore(int score)
        {

            var lista = repository.CalculateRanking().Where(x => x.pontos < score);

            return Ok(lista);

        }

        [HttpGet(">{score}")]
        public IActionResult GetMaximumScore(int score)
        {
            var lista = repository.CalculateRanking().Where(x => x.pontos > score);

            return Ok(lista);
        }

        [HttpGet(">={score}")]
        public IActionResult GetMaximumScoreInclusive(int score)

        {
            var lista = repository.CalculateRanking().Where(x => x.pontos >= score);

            return Ok(lista);
        }

        [HttpGet("<={score}")]
        public IActionResult GetMinimumScoreInclusive(int score)

        {
            var lista = repository.CalculateRanking().Where(x => x.pontos <= score);

            return Ok(lista);
        }

        [HttpGet("+{estado}")]
        public IActionResult GetByEstado(string estado)
        {
            var lista = repository.CalculateRanking().Where(x => x.estadonome.ToLower()
            .StartsWith(estado.Substring(0, 2)));

            return Ok(lista);
        }

        [HttpGet("%{nome}")]
        public IActionResult GetByendName(string name)
        {
            var lista = repository.CalculateRanking().Where(x => x.Nome.ToLower().EndsWith(name.ToLower()));

            return Ok(lista);
        }

        [HttpGet("{nome}%")]
        public IActionResult GetByStartName(string name)
        {
            var lista = repository.CalculateRanking().Where(x => x.Nome.ToLower().StartsWith(name.ToLower()));

            return Ok(lista);
        }

        [HttpGet("%{nome}%")]
        public IActionResult GetByName(string name)
        {
            var lista = repository.CalculateRanking().Where(x => x.Nome.ToLower().Contains(name.ToLower()));

            return Ok(lista);
        }

        [HttpGet("!>{type}")]
        public IActionResult OrderAscName(string type)
        {
            if (type == "PA")
                return Ok(repository.CalculateRanking().OrderByDescending(x => x.Nome));

            else if (type == "PO")
                return Ok(repository.CalculateRanking().OrderByDescending(x => x.pontos));

            else return NotFound();

        }
    }
}
