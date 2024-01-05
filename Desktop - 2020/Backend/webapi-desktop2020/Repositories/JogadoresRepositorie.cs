using webapi_desktop2020.Contexts;
using webapi_desktop2020.Domains;
using webapi_desktop2020.Interfaces;

namespace webapi_desktop2020.Repositories
{
    public class JogadoresRepositorie : IJogadores
    {
        DesktopContext ctx = new DesktopContext();

        public List<Jogadore> GetById(int idSelecao)
        {


          return  ctx.Jogadores.Select(
                x => new Jogadore { 
                Id = x.Id,
                Nome = x.Nome,
                NumeroCamisa = x.NumeroCamisa,
                SelecaoId = x.SelecaoId,
                PosicaoId = x.PosicaoId,
                
                }
                ).Where(x =>  x.SelecaoId == idSelecao).ToList();
        }

        public List<Jogadore> GetJogadores()
        {
            return ctx.Jogadores.ToList();  
        }
    }
}
