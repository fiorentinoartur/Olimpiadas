using webapi.session2.Contexts;
using webapi.session2.Domains;
using webapi.session2.Interfaces;

namespace webapi.session2.Repositories
{
    public class RankingRepository : IRanking
    {
        private readonly SessionContext ctx;

        public RankingRepository()
        {
            ctx = new SessionContext();
        }

    

        public Ranking BuscarPeloNome(string nomeParticipante)
        {
            Ranking participanteBuscado = ctx.Rankings.FirstOrDefault(p => p.Nome == nomeParticipante);

            return participanteBuscado;
        }

        List<Ranking> IRanking.BuscarPelaPontuação(int pontos)
        {
            List<Ranking> participanteBuscado = ctx.Rankings.Where(r => r.Pontos == pontos).ToList() ;

            return participanteBuscado;
        }
    }
}
