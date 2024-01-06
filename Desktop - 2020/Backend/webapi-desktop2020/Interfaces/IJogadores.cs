using webapi_desktop2020.Domains;
using webapi_desktop2020.ViewModel;

namespace webapi_desktop2020.Interfaces
{
    public interface IJogadores
    {
        List<Jogadore> GetJogadores();

        List<JogadoresViewModal> GetById(int idSelecao);
    }
}
