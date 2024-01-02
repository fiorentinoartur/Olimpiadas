using System;
using System.Collections.Generic;

namespace webapi_desktop2020.Domains;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public DateTime Nascimento { get; set; }

    public byte[]? Foto { get; set; }

    public string Sexo { get; set; } = null!;

    public int? TimeFavoritoId { get; set; }

    public string? Perfil { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<NotificacoesUsuario> NotificacoesUsuarios { get; set; } = new List<NotificacoesUsuario>();

    public virtual Seleco? TimeFavorito { get; set; }
}
