using System;
using System.Collections.Generic;

namespace webapi.session2.Domains;

public partial class TipoEvento
{
    public int Id { get; set; }

    public string? Tipoevento1 { get; set; }

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}
