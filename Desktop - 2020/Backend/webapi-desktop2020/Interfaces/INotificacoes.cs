using webapi_desktop2020.Domains;
using webapi_desktop2020.ViewModel;

namespace webapi_desktop2020.Interfaces
{
    public interface INotificacoes
    {
        void Cadastrar(NotificacaoViewModel notificacao);

        List<Notificaco> Listar();

        void Deletar(int Id);

        void Atualizar(int Id, NotificacaoViewModel notificaco);

    }
}
