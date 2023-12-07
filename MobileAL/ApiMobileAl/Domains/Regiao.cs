using System;
using System.Collections.Generic;

namespace ApiMobileAl.Domains;

public partial class Regiao
{
    public int Id { get; set; }

    public string? Regiao1 { get; set; }

    public virtual ICollection<Estado> Estados { get; set; } = new List<Estado>();
}
