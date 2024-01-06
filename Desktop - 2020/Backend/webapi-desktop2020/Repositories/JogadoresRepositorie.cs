using webapi_desktop2020.Contexts;
using webapi_desktop2020.Domains;
using webapi_desktop2020.Interfaces;
using webapi_desktop2020.ViewModel;

namespace webapi_desktop2020.Repositories
{
    public class JogadoresRepositorie : IJogadores
    {
        DesktopContext ctx = new DesktopContext();

        public List<JogadoresViewModal> GetById(int idSelecao)
        {


          return  ctx.Jogadores.Select(
                x => new JogadoresViewModal { 
                Id = x.Id,
                NomeJogador = x.Nome,
                NumeroCamisa = x.NumeroCamisa,
                SelecaoId = x.SelecaoId,
                PosicaoId = (int)x.PosicaoId,
               NomePosicao = x.Posicao.Nome,
            
                
                }
                ).Where(x =>  x.SelecaoId == idSelecao).ToList();
        }

        public List<Jogadore> GetJogadores()
        {
            return ctx.Jogadores.ToList();  
        }
    }
}
