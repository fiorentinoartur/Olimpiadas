using System;
using System.Collections.Generic;

namespace webapi_desktop2020.Domains;

public partial class Comentario
{
    public int Id { get; set; }

    public string? Comentario1 { get; set; }

    public DateTime? DataHoraComentario { get; set; }

    public int? IdJogo { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Jogo? IdJogoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
