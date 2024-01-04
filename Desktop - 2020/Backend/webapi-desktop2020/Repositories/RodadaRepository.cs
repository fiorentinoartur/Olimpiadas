using webapi_desktop2020.Contexts;
using webapi_desktop2020.Domains;
using webapi_desktop2020.Interfaces;
using webapi_desktop2020.ViewModel;

namespace webapi_desktop2020.Repositories
{
    public class RodadaRepository : IRodada
    {
        DesktopContext ctx = new DesktopContext();
        public List<Rodada> Listar()
        {
            return ctx.Rodadas.ToList();
        }
    }
}
