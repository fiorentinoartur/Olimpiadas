namespace webapi_desktop2020.ViewModel
{
    public class JogosViewModel
    {
        public int Id { get; set; }
        public int? SelecaoCasaId { get; set; }
        public int? PlacarCasa { get; set; }
        public int? SelecaoVisitanteId { get; set; }
        public int? PlacarVisitante { get; set; }
        public DateTime? Data { get; set; }
        public int? RodadaId { get; set; }
        public DateTime? DataTerminoRodada { get; set; }

        public TimeSpan? HorarioJogo { get; set; }

        public string NomeSelecaoCasa { get; set; }
        public string NomeSelecaoVisitante { get; set; }
        public DateTime? InicioRodada { get; set; }

    }
}
