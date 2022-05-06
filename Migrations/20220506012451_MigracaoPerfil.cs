﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApi.Migrations
{
    public partial class MigracaoPerfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 12, 22, 5, 58, 118, 30, 92, 33, 233, 253, 26, 97, 33, 99, 31, 216, 121, 7, 88, 130, 33, 89, 138, 232, 12, 29, 185, 108, 64, 27, 181, 9, 132, 21, 49, 129, 80, 100, 119, 134, 77, 195, 191, 216, 250, 244, 116, 198, 53, 56, 124, 108, 207, 115, 254, 101, 242, 58, 56, 254, 121, 236, 167, 11 }, new byte[] { 95, 110, 161, 152, 93, 235, 150, 209, 155, 197, 239, 104, 92, 140, 203, 96, 228, 121, 117, 17, 211, 219, 137, 77, 190, 6, 96, 2, 168, 18, 46, 24, 244, 242, 126, 143, 25, 10, 65, 138, 150, 187, 185, 43, 220, 197, 245, 200, 10, 209, 234, 16, 159, 172, 200, 223, 146, 123, 83, 32, 125, 0, 229, 40, 67, 227, 152, 48, 89, 193, 156, 159, 211, 52, 245, 193, 29, 49, 179, 167, 83, 138, 77, 184, 83, 242, 245, 117, 203, 179, 122, 178, 212, 125, 140, 152, 158, 124, 147, 14, 13, 162, 57, 208, 43, 104, 239, 82, 87, 124, 152, 36, 41, 26, 36, 104, 163, 180, 244, 99, 87, 200, 54, 156, 61, 76, 177, 54 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 28, 53, 174, 254, 158, 87, 213, 227, 67, 107, 147, 200, 28, 132, 43, 181, 65, 82, 241, 75, 242, 62, 108, 45, 54, 139, 220, 226, 233, 80, 110, 215, 155, 148, 163, 1, 39, 47, 143, 84, 203, 3, 232, 199, 114, 244, 38, 77, 84, 132, 61, 86, 238, 197, 252, 111, 185, 243, 197, 150, 126, 232, 232, 76 }, new byte[] { 142, 243, 89, 126, 207, 52, 38, 154, 14, 10, 204, 246, 96, 207, 48, 102, 143, 249, 55, 247, 143, 254, 149, 175, 141, 203, 108, 245, 109, 29, 255, 142, 191, 173, 236, 231, 1, 94, 66, 160, 46, 78, 245, 222, 84, 178, 40, 31, 172, 204, 99, 93, 118, 225, 147, 116, 151, 115, 185, 209, 105, 196, 86, 2, 13, 95, 207, 13, 42, 212, 1, 34, 230, 21, 170, 88, 90, 189, 25, 98, 170, 163, 134, 127, 120, 203, 76, 26, 54, 125, 104, 145, 227, 13, 88, 109, 157, 96, 251, 234, 236, 222, 151, 63, 101, 125, 60, 220, 103, 162, 5, 182, 0, 86, 88, 204, 164, 20, 137, 95, 238, 71, 113, 14, 227, 54, 47, 126 } });
        }
    }
}