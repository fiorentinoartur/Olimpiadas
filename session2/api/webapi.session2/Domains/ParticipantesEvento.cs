using System;
using System.Collections.Generic;

namespace webapi.session2;

public partial class ParticipantesEvento
{
    public int Id { get; set; }

    public int? EventoId { get; set; }

    public int? ParticipanteId { get; set; }

    public virtual Evento? Evento { get; set; }

    public virtual Participante? Participante { get; set; }
}
