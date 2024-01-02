using webapi_desktop2020.Domains;

namespace webapi_desktop2020.ViewModel
{
    public class NotificacaoViewModel
    {
        public  string Titulo  { get; set; }
        public string Descricao { get; set; }
        public int? SelecaoId  { get; set; }
        public string Importancia { get; set; }
        public DateTime DataNotificacao { get; set; }
        public DateTime HoraNotificacao { get; set; }
    }
}
