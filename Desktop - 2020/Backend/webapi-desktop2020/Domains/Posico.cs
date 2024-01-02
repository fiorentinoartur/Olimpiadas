using System;
using System.Collections.Generic;

namespace webapi_desktop2020.Domains;

public partial class Posico
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Jogadore> Jogadores { get; set; } = new List<Jogadore>();
}
