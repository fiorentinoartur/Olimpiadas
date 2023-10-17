using System;
using System.Collections.Generic;

namespace session2.Domains;

public partial class Venda
{
    public int Id { get; set; }

    public int? ParticipanteId { get; set; }

    public int? ProdutoId { get; set; }

    public double? Quantidade { get; set; }

    public int? EventoId { get; set; }

    public int? LojaId { get; set; }

    public DateTime? Data { get; set; }

    public DateTime? Hora { get; set; }

    public double? Transação { get; set; }
}
