using webapi.session2.Domains;

namespace webapi.session2.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório RankingRepository
    /// Definir os métodos que serão implementados pelo RankingRepository
    /// </summary>
    public interface IRanking
    {
        //TipoDeRetorno NomeMetodo(TipoParâmetro NomeParâmetro)

        /// <summary>
        /// Listar os participantes pelo Nome
        /// </summary>
        /// <param name="nomeParticipante">Nome do objeto a ser buscado</param>
        /// <returns>objeto buscado</returns>
        Ranking BuscarPeloNome(string nomeParticipante);
        /// <summary>
        /// Listar os participantes pelos pontos
        /// </summary>
        /// <param name="pontos">Nome do objeto a ser buscado</param>
        /// <returns>objeto buscado</returns>
        List<Ranking> BuscarPelaPontuação(int pontos);
    }
}
