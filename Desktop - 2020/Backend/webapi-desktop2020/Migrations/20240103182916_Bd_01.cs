using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi_desktop2020.Migrations
{
    /// <inheritdoc />
    public partial class Bd_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posicoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Posicoes__3214EC0716494D87", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rodadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInicio = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rodadas__3214EC072DBACA62", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Selecoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Selecoes__3214EC0737AB6A8F", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    NumeroCamisa = table.Column<int>(type: "int", nullable: false),
                    SelecaoId = table.Column<int>(type: "int", nullable: true),
                    PosicaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Jogadore__3214EC070C973F75", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogadores_Posicoes",
                        column: x => x.PosicaoId,
                        principalTable: "Posicoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jogadores_Selecoes",
                        column: x => x.SelecaoId,
                        principalTable: "Selecoes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SelecaoCasaId = table.Column<int>(type: "int", nullable: true),
                    PlacarCasa = table.Column<int>(type: "int", nullable: true),
                    SelecaoVisitanteId = table.Column<int>(type: "int", nullable: true),
                    PlacarVisitante = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime", nullable: true),
                    RodadaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Jogos__3214EC070BF97C52", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogos_Rodadas",
                        column: x => x.RodadaId,
                        principalTable: "Rodadas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jogos_Selecoes",
                        column: x => x.SelecaoCasaId,
                        principalTable: "Selecoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jogos_Selecoes1",
                        column: x => x.SelecaoVisitanteId,
                        principalTable: "Selecoes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notificacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataHoraEnvio = table.Column<DateTime>(type: "datetime", nullable: true),
                    Importancia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    SelecaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__3214EC07FD9C086F", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notificacoes_Selecoes",
                        column: x => x.SelecaoId,
                        principalTable: "Selecoes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Senha = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Nascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Foto = table.Column<byte[]>(type: "image", nullable: true),
                    Sexo = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    TimeFavoritoId = table.Column<int>(type: "int", nullable: true),
                    perfil = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__3214EC07130AD5BE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Selecoes",
                        column: x => x.TimeFavoritoId,
                        principalTable: "Selecoes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comentario = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DataHoraComentario = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdJogo = table.Column<int>(type: "int", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentario_Jogos",
                        column: x => x.IdJogo,
                        principalTable: "Jogos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comentario_Usuarios",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NotificacoesUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    NotificacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__3214EC07A75430E3", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificacoesUsuarios_Notificacoes",
                        column: x => x.NotificacaoId,
                        principalTable: "Notificacoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotificacoesUsuarios_Usuarios",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_IdJogo",
                table: "Comentario",
                column: "IdJogo");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_IdUsuario",
                table: "Comentario",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Jogadores_PosicaoId",
                table: "Jogadores",
                column: "PosicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogadores_SelecaoId",
                table: "Jogadores",
                column: "SelecaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_RodadaId",
                table: "Jogos",
                column: "RodadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_SelecaoCasaId",
                table: "Jogos",
                column: "SelecaoCasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_SelecaoVisitanteId",
                table: "Jogos",
                column: "SelecaoVisitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacoes_SelecaoId",
                table: "Notificacoes",
                column: "SelecaoId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificacoesUsuarios_NotificacaoId",
                table: "NotificacoesUsuarios",
                column: "NotificacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificacoesUsuarios_UsuarioId",
                table: "NotificacoesUsuarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TimeFavoritoId",
                table: "Usuarios",
                column: "TimeFavoritoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Jogadores");

            migrationBuilder.DropTable(
                name: "NotificacoesUsuarios");

            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Posicoes");

            migrationBuilder.DropTable(
                name: "Notificacoes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Rodadas");

            migrationBuilder.DropTable(
                name: "Selecoes");
        }
    }
}
