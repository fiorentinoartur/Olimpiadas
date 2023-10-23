﻿using System;
using System.Collections.Generic;
using webapi.session2.Domains;

namespace webapi.session2;

public partial class Evento
{
    public int Id { get; set; }

    public string? Evento1 { get; set; }

    public int? TipoEventoId { get; set; }

    public virtual ICollection<ParticipantesEvento> ParticipantesEventos { get; set; } = new List<ParticipantesEvento>();

    public virtual TipoEvento? TipoEvento { get; set; }

    public virtual ICollection<Venda> Venda { get; set; } = new List<Venda>();
}
