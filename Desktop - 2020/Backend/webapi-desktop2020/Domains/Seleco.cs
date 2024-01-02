using System;
using System.Collections.Generic;

namespace webapi_desktop2020.Domains;

public partial class Seleco
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Jogadore> Jogadores { get; set; } = new List<Jogadore>();

    public virtual ICollection<Jogo> JogoSelecaoCasas { get; set; } = new List<Jogo>();

    public virtual ICollection<Jogo> JogoSelecaoVisitantes { get; set; } = new List<Jogo>();

    public virtual ICollection<Notificaco> Notificacos { get; set; } = new List<Notificaco>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
