using System;
using System.Collections.Generic;

namespace webapi.session2.Domains;

public partial class Ranking
{
    public int IdRanking { get; set; }

    public string Nome { get; set; } = null!;

    public int? Pontos { get; set; }
}
