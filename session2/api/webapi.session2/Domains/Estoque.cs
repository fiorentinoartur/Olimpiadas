﻿using System;
using System.Collections.Generic;

namespace webapi.session2;

public partial class Estoque
{
    public int Id { get; set; }

    public int? ProdutoId { get; set; }

    public int? LojaId { get; set; }

    public double? Quantidade { get; set; }

    public virtual Loja? Loja { get; set; }

    public virtual Produto? Produto { get; set; }
}
