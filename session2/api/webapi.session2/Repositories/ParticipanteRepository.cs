using webapi.session2.Contexts;
using webapi.session2.Domains;
using webapi.session2.Interfaces;

namespace webapi.session2.Repositories
{
    public class ParticipanteRepository : IParticipante
    {
        private readonly SessionContext ctx;

        public ParticipanteRepository()
        {
            ctx = new SessionContext();
        }

        public Participante BuscarPeloNome(string nomeParticipante)
        {
            Participante participanteBuscado = ctx.Participantes
        .Select(p => new Participante
        {
            Id = p.Id,
            Nome = p.Nome,
            Idade = p.Idade,
            Genero = p.Genero,
            CidadeId = p.CidadeId,
            Cidade = new Cidade
            {
                Cidade1 = p.Cidade.Cidade1
            }
        }).FirstOrDefault(p => p.Nome == nomeParticipante);

            return participanteBuscado;
        }

    }
}
