using System;
using System.Collections.Generic;

namespace session2.Domains;

public partial class Estoque
{
    public int Id { get; set; }

    public int? ProdutoId { get; set; }

    public int? LojaId { get; set; }

    public double? Quantidade { get; set; }
}
