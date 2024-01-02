using System;
using System.Collections.Generic;

namespace webapi_desktop2020.Domains;

public partial class NotificacoesUsuario
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public int? UsuarioId { get; set; }

    public int? NotificacaoId { get; set; }

    public virtual Notificaco? Notificacao { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
