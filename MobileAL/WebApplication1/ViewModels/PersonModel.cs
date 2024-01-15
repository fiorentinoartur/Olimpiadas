using WebApplication1.Domains;

namespace WebApplication1.ViewModels
{
    public class PersonModel : Participante
    {
        public int? pontos { get; set; }
        public string cidadenome { get; set; }
        public string estadonome { get; set; }
    }
}
