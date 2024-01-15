using System;
using System.Collections.Generic;

namespace WebApplication1.Domains;

public partial class Produto
{
    public int Id { get; set; }

    public string? Produto1 { get; set; }

    public int? Valor { get; set; }

    public virtual ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();

    public virtual ICollection<Venda> Venda { get; set; } = new List<Venda>();
}
