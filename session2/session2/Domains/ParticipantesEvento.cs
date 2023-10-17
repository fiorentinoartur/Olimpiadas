using System;
using System.Collections.Generic;

namespace session2.Domains;

public partial class ParticipantesEvento
{
    public int Id { get; set; }

    public int? EventoId { get; set; }

    public int? ParticipanteId { get; set; }
}
