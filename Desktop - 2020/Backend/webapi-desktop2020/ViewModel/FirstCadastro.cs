namespace webapi_desktop2020.ViewModel
{
    public class FirstCadastro
    {
        public string Nome { get; set; }
        
        public string Sexo { get; set; }
        
        public int? TimeFavoritoId { get; set; }
        
        public DateTime Nascimento { get; set; }

        public IFormFile? Foto { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Perfil { get; set; }
        
    }
}
