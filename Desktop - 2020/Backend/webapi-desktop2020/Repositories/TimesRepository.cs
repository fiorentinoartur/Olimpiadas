using webapi_desktop2020.Contexts;
using webapi_desktop2020.Domains;
using webapi_desktop2020.Interfaces;

namespace webapi_desktop2020.Repositories
{
    public class TimesRepository : ITimes
    {
        DesktopContext ctx = new DesktopContext();
        public List<Seleco> Listar()
        {
           return ctx.Selecoes.ToList();
        }
    }
}
