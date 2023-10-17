using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace session2.Domains;

public partial class Participante
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public double? Idade { get; set; }

    public string? Genero { get; set; }

    public int CidadeId { get; set; }


}
