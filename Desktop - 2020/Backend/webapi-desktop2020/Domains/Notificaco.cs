using System;
using System.Collections.Generic;

namespace webapi_desktop2020.Domains;

public partial class Notificaco
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public DateTime DataHoraCadastro { get; set; }

    public DateTime? DataHoraEnvio { get; set; }

    public string Importancia { get; set; } = null!;

    public int? SelecaoId { get; set; }

    public virtual ICollection<NotificacoesUsuario> NotificacoesUsuarios { get; set; } = new List<NotificacoesUsuario>();

    public virtual Seleco? Selecao { get; set; }
}
