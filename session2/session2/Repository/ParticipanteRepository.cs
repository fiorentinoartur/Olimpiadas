using Microsoft.EntityFrameworkCore;
using session2.Contexts;
using session2.Domains;
using session2.Interfaces;

namespace session2.Repository
{
    public class ParticipanteRepository : IParticipante
    {
        private readonly SessionContext ctx;

        public ParticipanteRepository()
        {
                ctx = new SessionContext();
        }
        public Participante Listar(string nome)
        {
            Participante participanteBuscado = ctx.Participantes.FirstOrDefault(p => p.Nome == nome);

            /*    Participante participanteBuscado = ctx.Participantes
                    .Select(p => new Participante
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        Idade = p.Idade,
                        Genero = p.Genero,
                        CidadeId = p.CidadeId
                    }).FirstOrDefault(p => p.Nome == nome);
            */
            return participanteBuscado;
            
        }
    }
}
