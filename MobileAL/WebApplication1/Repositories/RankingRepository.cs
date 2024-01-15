using Microsoft.EntityFrameworkCore;
using WebApplication1.Contexts;
using WebApplication1.ViewModels;

namespace WebApplication1.Repositories
{
    public class RankingRepository
    {
        ALContext ctx = new ALContext();

        public List<PersonModel> CalculateRanking()
        {
            var lista = ctx.Participantes
                .Include(x => x.Venda)
                .ThenInclude(x => x.Produto)
                .Include(x => x.Cidade)
                .ThenInclude(x => x.Estado)
                .Where(x => x.Venda.Count() > 0).ToList()
                .Select(x => new PersonModel
                {
                    Id= x.Id,
                    Nome = x.Nome,
                    Idade = x.Idade,
                    cidadenome = x.Cidade.Cidade1,
                    estadonome = x.Cidade.Estado.Sigla,
                    Genero = x.Genero,
                     pontos = x.Venda.Count() * 12 + (int)x.Venda.Sum(v => (v.Produto.Valor) * v.Quantidade) * 24
                }).OrderByDescending(x => x.pontos).ToList();

            return lista;
        }
    }
}
