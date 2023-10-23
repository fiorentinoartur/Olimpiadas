using webapi.session2.Domains;

namespace webapi.session2.Interfaces
{
    public interface IRanking
    {
        Ranking BuscarPeloNome(string nomeParticipante);
        List<Ranking> BuscarPelaPontuação(int pontos);
    }
}
