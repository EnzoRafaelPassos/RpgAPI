using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApi.Migrations
{
    public partial class _12052022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Jogador",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Jogador");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 55, 119, 38, 68, 210, 7, 109, 93, 22, 0, 24, 161, 145, 37, 47, 169, 33, 163, 44, 255, 6, 208, 227, 130, 183, 135, 57, 179, 7, 227, 19, 189, 245, 87, 140, 167, 32, 159, 227, 210, 58, 148, 40, 43, 223, 46, 83, 38, 189, 73, 82, 58, 31, 3, 34, 167, 144, 177, 101, 151, 163, 218, 64, 228 }, new byte[] { 154, 202, 108, 122, 152, 106, 189, 221, 93, 223, 11, 69, 27, 102, 170, 147, 223, 255, 223, 75, 242, 136, 113, 214, 246, 3, 16, 113, 76, 43, 44, 173, 206, 114, 41, 2, 251, 10, 57, 124, 176, 143, 9, 199, 108, 123, 120, 11, 33, 91, 153, 209, 26, 11, 196, 236, 12, 50, 210, 201, 202, 53, 219, 140, 97, 228, 92, 128, 57, 194, 201, 52, 19, 230, 107, 196, 226, 114, 142, 27, 152, 216, 27, 20, 246, 114, 240, 69, 41, 10, 141, 80, 135, 114, 79, 174, 92, 137, 51, 115, 140, 122, 72, 203, 179, 177, 176, 26, 49, 6, 40, 247, 234, 76, 86, 23, 225, 72, 195, 212, 60, 60, 123, 94, 100, 72, 54, 146 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Jogador",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Jogador");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 12, 22, 5, 58, 118, 30, 92, 33, 233, 253, 26, 97, 33, 99, 31, 216, 121, 7, 88, 130, 33, 89, 138, 232, 12, 29, 185, 108, 64, 27, 181, 9, 132, 21, 49, 129, 80, 100, 119, 134, 77, 195, 191, 216, 250, 244, 116, 198, 53, 56, 124, 108, 207, 115, 254, 101, 242, 58, 56, 254, 121, 236, 167, 11 }, new byte[] { 95, 110, 161, 152, 93, 235, 150, 209, 155, 197, 239, 104, 92, 140, 203, 96, 228, 121, 117, 17, 211, 219, 137, 77, 190, 6, 96, 2, 168, 18, 46, 24, 244, 242, 126, 143, 25, 10, 65, 138, 150, 187, 185, 43, 220, 197, 245, 200, 10, 209, 234, 16, 159, 172, 200, 223, 146, 123, 83, 32, 125, 0, 229, 40, 67, 227, 152, 48, 89, 193, 156, 159, 211, 52, 245, 193, 29, 49, 179, 167, 83, 138, 77, 184, 83, 242, 245, 117, 203, 179, 122, 178, 212, 125, 140, 152, 158, 124, 147, 14, 13, 162, 57, 208, 43, 104, 239, 82, 87, 124, 152, 36, 41, 26, 36, 104, 163, 180, 244, 99, 87, 200, 54, 156, 61, 76, 177, 54 } });
        }
    }
}
