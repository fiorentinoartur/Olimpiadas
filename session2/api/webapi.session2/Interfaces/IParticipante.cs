using webapi.session2.Domains;

namespace webapi.session2.Interfaces
{
    public interface IParticipante
    {
        Participante BuscarPeloNome(string nomeParticipante);
    }
}
