using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi_desktop2020.Domains;

public partial class Jogo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

    public DateTime? DataTerminoRodada
    {
        get
        {
            if (Rodada != null && Rodada.DataInicio != null)
            {
                return Rodada.DataInicio.AddDays(8);
            }
            return null;
        }
    }
}
