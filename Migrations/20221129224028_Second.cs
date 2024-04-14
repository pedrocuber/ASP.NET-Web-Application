using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assessment.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amigo_Amigo_AmigoId1",
                table: "Amigo");

            migrationBuilder.DropIndex(
                name: "IX_Amigo_AmigoId1",
                table: "Amigo");

            migrationBuilder.DropColumn(
                name: "AmigoId1",
                table: "Amigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmigoId1",
                table: "Amigo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Amigo_AmigoId1",
                table: "Amigo",
                column: "AmigoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Amigo_Amigo_AmigoId1",
                table: "Amigo",
                column: "AmigoId1",
                principalTable: "Amigo",
                principalColumn: "AmigoId");
        }
    }
}
