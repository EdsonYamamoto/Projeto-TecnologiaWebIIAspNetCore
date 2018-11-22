using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoTecWebAspNetCore.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Senha = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    CPF = table.Column<string>(nullable: true),
                    TipoUsuario = table.Column<string>(nullable: true),
                    Obs = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioID = table.Column<int>(nullable: false),
                    NumeroConta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Conta_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conversas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdUsuario = table.Column<int>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: true),
                    Mensagem = table.Column<string>(nullable: true),
                    Horiario = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Conversas_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Emprestimos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IDInvestidor = table.Column<int>(nullable: false),
                    InvestidorID = table.Column<int>(nullable: true),
                    IDTomador = table.Column<int>(nullable: false),
                    TomadorID = table.Column<int>(nullable: true),
                    Valor = table.Column<double>(nullable: false),
                    Parcela = table.Column<double>(nullable: false),
                    QuantidadeParcela = table.Column<int>(nullable: false),
                    Horario = table.Column<DateTime>(nullable: false),
                    Autorizacao = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Emprestimos_Usuario_InvestidorID",
                        column: x => x.InvestidorID,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emprestimos_Usuario_TomadorID",
                        column: x => x.TomadorID,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Balanco",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContaID = table.Column<int>(nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    TipoGasto = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balanco", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Balanco_Conta_ContaID",
                        column: x => x.ContaID,
                        principalTable: "Conta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Balanco_ContaID",
                table: "Balanco",
                column: "ContaID");

            migrationBuilder.CreateIndex(
                name: "IX_Conta_UsuarioID",
                table: "Conta",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Conversas_UsuarioID",
                table: "Conversas",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_InvestidorID",
                table: "Emprestimos",
                column: "InvestidorID");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_TomadorID",
                table: "Emprestimos",
                column: "TomadorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balanco");

            migrationBuilder.DropTable(
                name: "Conversas");

            migrationBuilder.DropTable(
                name: "Emprestimos");

            migrationBuilder.DropTable(
                name: "Conta");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
