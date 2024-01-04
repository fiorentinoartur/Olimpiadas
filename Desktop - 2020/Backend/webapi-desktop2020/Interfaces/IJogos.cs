using webapi_desktop2020.Domains;
using webapi_desktop2020.ViewModel;

namespace webapi_desktop2020.Interfaces
{
    public interface IJogos
    {
        List<JogosViewModel> Listar(int rodada);

        void Cadastrar();

        void atulizarPlacar(int jogo, AtualizarPlacar placar);
    }
}
