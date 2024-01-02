using System;
using System.Collections.Generic;

namespace webapi_desktop2020.Domains;

public partial class Jogo
{
    public int Id { get; set; }

    public int? SelecaoCasaId { get; set; }

    public int? PlacarCasa { get; set; }

    public int? SelecaoVisitanteId { get; set; }

    public int? PlacarVisitante { get; set; }

    public DateTime? Data { get; set; }

    public int? RodadaId { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual Rodada? Rodada { get; set; }

    public virtual Seleco? SelecaoCasa { get; set; }

    public virtual Seleco? SelecaoVisitante { get; set; }
}
