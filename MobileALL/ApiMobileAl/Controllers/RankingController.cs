//using ApiMobileAl.Repositories;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.HttpLogging;
//using Microsoft.AspNetCore.Mvc;

//namespace ApiMobileAl.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RankingController : ControllerBase
//    {
//        RankingRepository repository = new RankingRepository();


//        [HttpGet]
//        public IActionResult GetRaking()
//        {
//            var lista = repository.CalculateRanking();

//            return Ok(lista);
//        }

//        [HttpGet("<{score}")]
//        public IActionResult GetMinimiumScore(int score) 
//        {

//            var lista = repository.CalculateRanking().Where(x => x.Pontos < score);

//            return Ok(lista);   
       
//        }

//        [HttpGet(">{score}")]
//        public IActionResult GetMaximumScore(int score) 
//        {
//            var lista = repository.CalculateRanking().Where(x => x.Pontos > score);

//            return Ok(lista);
//        }

//        [HttpGet(">={score}")]
//        public IActionResult GetMaximumScoreInclusive(int score) 
        
//        {
//            var lista = repository.CalculateRanking().Where(x => x.Pontos >= score);

//            return Ok(lista);
//        }        
        
//        [HttpGet("<={score}")]
//        public IActionResult GetMinimumScoreInclusive(int score) 
        
//        {
//            var lista = repository.CalculateRanking().Where(x => x.Pontos <= score);

//            return Ok(lista);
//        }

//        [HttpGet("+{estado}")]
//        public IActionResult GetByEstado(string estado)
//        {
//            var lista = repository.CalculateRanking().Where(x => x.EstadoNome.ToLower()
//            .StartsWith(estado.Substring(0, 2)));

//            return Ok(lista);
//        }

//        [HttpGet("%{nome}")]
//        public IActionResult GetByendName(string name) 
//        { 
//        var lista = repository.CalculateRanking().Where(x => x.Nome.ToLower().EndsWith(name.ToLower()));

//            return Ok(lista);
//        }   
        
//        [HttpGet("{nome}%")]
//        public IActionResult GetByStartName(string name) 
//        { 
//        var lista = repository.CalculateRanking().Where(x => x.Nome.ToLower().StartsWith(name.ToLower()));

//            return Ok(lista);
//        }      
        
//        [HttpGet("%{nome}%")]
//        public IActionResult GetByName(string name) 
//        { 
//        var lista = repository.CalculateRanking().Where(x => x.Nome.ToLower().Contains(name.ToLower()));

//            return Ok(lista);
//        }

//        [HttpGet("!>{type}")]
//        public IActionResult OrderAscName(string type) 
//        {
//            if (type == "PA")
//                return Ok(repository.CalculateRanking().OrderByDescending(x => x.Nome));

//            else if (type == "PO")
//                return Ok(repository.CalculateRanking().OrderByDescending(x => x.Pontos));

//            else return NotFound();  
            
//        }



//    }
//}
