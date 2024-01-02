using System;
using System.Collections.Generic;

namespace webapi_desktop2020.Domains;

public partial class Rodada
{
    public int Id { get; set; }

    public DateTime DataInicio { get; set; }

    public virtual ICollection<Jogo> Jogos { get; set; } = new List<Jogo>();
}
