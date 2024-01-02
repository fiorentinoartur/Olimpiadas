using System;
using System.Collections.Generic;

namespace webapi_desktop2020.Domains;

public partial class Jogadore
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public int NumeroCamisa { get; set; }

    public int? SelecaoId { get; set; }

    public int? PosicaoId { get; set; }

    public virtual Posico? Posicao { get; set; }

    public virtual Seleco? Selecao { get; set; }
}
