using webapi_desktop2020.Domains;

namespace webapi_desktop2020.Interfaces
{
    public interface IJogadores
    {
        List<Jogadore> GetJogadores();

        List<Jogadore> GetById(int idSelecao);
    }
}
