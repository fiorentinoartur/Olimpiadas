using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi_desktop2020.Domains;

namespace webapi_desktop2020.Contexts;

public partial class DesktopContext : DbContext
{
    public DesktopContext()
    {
    }

    public DesktopContext(DbContextOptions<DesktopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Jogadore> Jogadores { get; set; }

    public virtual DbSet<Jogo> Jogos { get; set; }

    public virtual DbSet<Notificaco> Notificacoes { get; set; }

    public virtual DbSet<NotificacoesUsuario> NotificacoesUsuarios { get; set; }

    public virtual DbSet<Posico> Posicoes { get; set; }

    public virtual DbSet<Rodada> Rodadas { get; set; }

    public virtual DbSet<Seleco> Selecoes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ARTUR; initial catalog=Sessao5; User Id = sa; Pwd = Arcos@2020; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.ToTable("Comentario");

            entity.Property(e => e.Comentario1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Comentario");
            entity.Property(e => e.DataHoraComentario).HasColumnType("datetime");

            entity.HasOne(d => d.IdJogoNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdJogo)
                .HasConstraintName("FK_Comentario_Jogos");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Comentario_Usuarios");
        });

        modelBuilder.Entity<Jogadore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Jogadore__3214EC070C973F75");

            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Posicao).WithMany(p => p.Jogadores)
                .HasForeignKey(d => d.PosicaoId)
                .HasConstraintName("FK_Jogadores_Posicoes");

            entity.HasOne(d => d.Selecao).WithMany(p => p.Jogadores)
                .HasForeignKey(d => d.SelecaoId)
                .HasConstraintName("FK_Jogadores_Selecoes");
        });

        modelBuilder.Entity<Jogo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Jogos__3214EC070BF97C52");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Data).HasColumnType("datetime");

            entity.HasOne(d => d.Rodada).WithMany(p => p.Jogos)
                .HasForeignKey(d => d.RodadaId)
                .HasConstraintName("FK_Jogos_Rodadas");

            entity.HasOne(d => d.SelecaoCasa).WithMany(p => p.JogoSelecaoCasas)
                .HasForeignKey(d => d.SelecaoCasaId)
                .HasConstraintName("FK_Jogos_Selecoes");

            entity.HasOne(d => d.SelecaoVisitante).WithMany(p => p.JogoSelecaoVisitantes)
                .HasForeignKey(d => d.SelecaoVisitanteId)
                .HasConstraintName("FK_Jogos_Selecoes1");
        });

        modelBuilder.Entity<Notificaco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3214EC07FD9C086F");

            entity.Property(e => e.DataHoraCadastro).HasColumnType("datetime");
            entity.Property(e => e.DataHoraEnvio).HasColumnType("datetime");
            entity.Property(e => e.Descricao).HasColumnType("text");
            entity.Property(e => e.Importancia)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Selecao).WithMany(p => p.Notificacos)
                .HasForeignKey(d => d.SelecaoId)
                .HasConstraintName("FK_Notificacoes_Selecoes");
        });

        modelBuilder.Entity<NotificacoesUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3214EC07A75430E3");

            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Notificacao).WithMany(p => p.NotificacoesUsuarios)
                .HasForeignKey(d => d.NotificacaoId)
                .HasConstraintName("FK_NotificacoesUsuarios_Notificacoes");

            entity.HasOne(d => d.Usuario).WithMany(p => p.NotificacoesUsuarios)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_NotificacoesUsuarios_Usuarios");
        });

        modelBuilder.Entity<Posico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Posicoes__3214EC0716494D87");

            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rodada>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rodadas__3214EC072DBACA62");

            entity.Property(e => e.DataInicio).HasColumnType("datetime");
        });

        modelBuilder.Entity<Seleco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Selecoes__3214EC0737AB6A8F");

            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC07130AD5BE");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Foto).HasColumnType("image");
            entity.Property(e => e.Nascimento).HasColumnType("date");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Perfil)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("perfil");
            entity.Property(e => e.Senha)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.TimeFavorito).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.TimeFavoritoId)
                .HasConstraintName("FK_Usuarios_Selecoes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
