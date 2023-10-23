using System;
using System.Collections.Generic;
using webapi.session2.Domains;

namespace webapi.session2;

public partial class Loja
{
    public int Id { get; set; }

    public string? Loja1 { get; set; }

    public virtual ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();

    public virtual ICollection<Venda> Venda { get; set; } = new List<Venda>();
}
