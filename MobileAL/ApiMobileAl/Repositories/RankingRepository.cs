using ApiMobileAl.Contexts;
using ApiMobileAl.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApiMobileAl.Repositories
{
    public class RankingRepository
    {
        MobileContext ctx = new MobileContext();

        public List<PersonModel> CalculateRanking()
        {
            var lista = ctx.Participantes
                .Include(x => x.Venda)
                .ThenInclude(x => x.Produto)
                .Include(x => x.Cidade)
                .ThenInclude(x => x.Estado)
                .Where(x => x.Venda.Count() > 0).ToList()
                .Select(x => new  PersonModel
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Idade = x.Idade,
                    CidadeNome = x.Cidade.Cidade1,
                    EstadoNome = x.Cidade.Estado.Sigla,
                    Genero = x.Genero,
                    Pontos = x.Venda.Count() * 12 + (int)x.Venda.Sum(v =>(v.Produto.Valor) * v.Quantidade) * 24
                }).OrderByDescending(x => x.Pontos).ToList();

            return lista;
        }
    }
}
