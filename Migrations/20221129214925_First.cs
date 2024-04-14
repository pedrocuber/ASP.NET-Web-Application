using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assessment.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amigo",
                columns: table => new
                {
                    AmigoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmigoNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmigoSobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmigoTelefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmigoEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AniversarioAmigo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaisAmigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoAmigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagemAmigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmigoId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amigo", x => x.AmigoId);
                    table.ForeignKey(
                        name: "FK_Amigo_Amigo_AmigoId1",
                        column: x => x.AmigoId1,
                        principalTable: "Amigo",
                        principalColumn: "AmigoId");
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    PaisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaisNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisImagem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.PaisId);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    EstadosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadosNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoImagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.EstadosId);
                    table.ForeignKey(
                        name: "FK_Estado_Pais_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Pais",
                        principalColumn: "PaisId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amigo_AmigoId1",
                table: "Amigo",
                column: "AmigoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Estado_PaisId",
                table: "Estado",
                column: "PaisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amigo");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
