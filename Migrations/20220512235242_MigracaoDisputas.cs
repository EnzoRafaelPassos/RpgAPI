using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApi.Migrations
{
    public partial class MigracaoDisputas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Disputas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDisputa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtacanteId = table.Column<int>(type: "int", nullable: false),
                    OponenteId = table.Column<int>(type: "int", nullable: false),
                    Narracao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disputas", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 46, 178, 83, 118, 64, 110, 116, 115, 5, 240, 247, 46, 54, 234, 59, 128, 237, 22, 30, 177, 138, 137, 17, 142, 35, 40, 240, 139, 69, 198, 247, 7, 79, 87, 136, 144, 138, 250, 8, 50, 203, 255, 115, 85, 181, 107, 48, 77, 245, 49, 180, 91, 140, 119, 209, 122, 12, 184, 83, 201, 134, 171, 195, 49 }, new byte[] { 3, 29, 173, 132, 206, 40, 49, 157, 247, 211, 85, 220, 42, 200, 236, 229, 231, 117, 226, 80, 201, 137, 57, 95, 120, 141, 117, 176, 34, 140, 50, 39, 212, 140, 198, 28, 174, 51, 203, 11, 115, 170, 223, 33, 177, 145, 57, 85, 168, 232, 51, 118, 110, 47, 207, 229, 74, 81, 70, 99, 70, 47, 176, 202, 153, 208, 226, 19, 224, 254, 59, 135, 96, 106, 75, 17, 207, 108, 14, 103, 225, 131, 253, 212, 242, 156, 196, 60, 9, 219, 39, 240, 102, 145, 69, 232, 188, 198, 212, 5, 128, 27, 155, 152, 101, 42, 63, 26, 125, 226, 69, 195, 83, 241, 166, 42, 115, 36, 233, 234, 100, 230, 53, 201, 2, 29, 183, 222 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disputas");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "Personagens");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 55, 119, 38, 68, 210, 7, 109, 93, 22, 0, 24, 161, 145, 37, 47, 169, 33, 163, 44, 255, 6, 208, 227, 130, 183, 135, 57, 179, 7, 227, 19, 189, 245, 87, 140, 167, 32, 159, 227, 210, 58, 148, 40, 43, 223, 46, 83, 38, 189, 73, 82, 58, 31, 3, 34, 167, 144, 177, 101, 151, 163, 218, 64, 228 }, new byte[] { 154, 202, 108, 122, 152, 106, 189, 221, 93, 223, 11, 69, 27, 102, 170, 147, 223, 255, 223, 75, 242, 136, 113, 214, 246, 3, 16, 113, 76, 43, 44, 173, 206, 114, 41, 2, 251, 10, 57, 124, 176, 143, 9, 199, 108, 123, 120, 11, 33, 91, 153, 209, 26, 11, 196, 236, 12, 50, 210, 201, 202, 53, 219, 140, 97, 228, 92, 128, 57, 194, 201, 52, 19, 230, 107, 196, 226, 114, 142, 27, 152, 216, 27, 20, 246, 114, 240, 69, 41, 10, 141, 80, 135, 114, 79, 174, 92, 137, 51, 115, 140, 122, 72, 203, 179, 177, 176, 26, 49, 6, 40, 247, 234, 76, 86, 23, 225, 72, 195, 212, 60, 60, 123, 94, 100, 72, 54, 146 } });
        }
    }
}
