using ApiMobileAl.Domains;

namespace ApiMobileAl.ViewModels
{
    public class PersonModel : Participante
    {
        public int? Pontos { get; set; }
        public string CidadeNome { get; set; }
        public string EstadoNome { get; set; }
    }
}
