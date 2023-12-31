﻿using System;
using System.Collections.Generic;
using webapi.session2.Domains;

namespace webapi.session2;

public partial class Estado
{
    public int Id { get; set; }

    public string? Estado1 { get; set; }

    public string? Sigla { get; set; }

    public int? RegiaoId { get; set; }

    public virtual ICollection<Cidade> Cidades { get; set; } = new List<Cidade>();

    public virtual Regiao? Regiao { get; set; }
}
