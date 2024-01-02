using webapi_desktop2020.Contexts;
using webapi_desktop2020.Domains;
using webapi_desktop2020.Interfaces;
using webapi_desktop2020.ViewModel;

namespace webapi_desktop2020.Repositories
{
    public class NotificacaoRepository : INotificacoes
    {
        DesktopContext ctx = new DesktopContext();

        public void Atualizar(int Id, NotificacaoViewModel notificaco)
        {
          
        }

        public void Cadastrar(NotificacaoViewModel notificacao)
        {
             Notificaco notificacaoBanco  = new Notificaco();


            notificacaoBanco.Titulo = notificacao.Titulo;
            notificacaoBanco.Descricao = notificacao.Descricao;
            notificacaoBanco.SelecaoId = notificacao.SelecaoId;
            notificacaoBanco.Importancia = notificacao.Importancia;
            notificacaoBanco.DataHoraCadastro = notificacao.DataNotificacao;
            notificacaoBanco.DataHoraEnvio = notificacao.HoraNotificacao;


            ctx.Notificacoes.Add(notificacaoBanco);
            ctx.SaveChanges();

        }

        public void Deletar(int Id)
        {
            var notificacao = ctx.Notificacoes.FirstOrDefault(x => x.Id == Id);

            if (notificacao != null)
            {
                ctx.Notificacoes.Remove(notificacao);

                ctx.SaveChanges();
            }
        }

        public List<Notificaco> Listar()
        {
           return ctx.Notificacoes.AsEnumerable() // Este método traz a consulta para o lado do cliente
        .OrderByDescending(notificacao => notificacao.DataHoraCadastro + (notificacao.DataHoraEnvio.HasValue ? notificacao.DataHoraEnvio.Value.TimeOfDay : TimeSpan.Zero))
        .ToList();
        }
    }
}
