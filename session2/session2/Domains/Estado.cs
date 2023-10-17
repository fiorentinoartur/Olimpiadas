using System;
using System.Collections.Generic;

namespace session2.Domains;

public partial class Estado
{
    public int Id { get; set; }

    public string? Estado1 { get; set; }

    public string? Sigla { get; set; }

    public int? RegiaoId { get; set; }
}
