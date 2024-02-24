using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physio.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class professionaluserisunique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_PROFESSIONAL_COD_USER",
                table: "TB_PROFESSIONAL");

            migrationBuilder.RenameColumn(
                name: "isRegistred",
                table: "AspNetUsers",
                newName: "IsRegistred");

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 14, 32, 50, 912, DateTimeKind.Utc).AddTicks(1987));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 14, 32, 50, 912, DateTimeKind.Utc).AddTicks(2003));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 14, 32, 50, 912, DateTimeKind.Utc).AddTicks(1991));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 14, 32, 50, 912, DateTimeKind.Utc).AddTicks(2005));

            migrationBuilder.CreateIndex(
                name: "IX_TB_PROFESSIONAL_COD_USER",
                table: "TB_PROFESSIONAL",
                column: "COD_USER",
                unique: true,
                filter: "[COD_USER] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_PROFESSIONAL_COD_USER",
                table: "TB_PROFESSIONAL");

            migrationBuilder.RenameColumn(
                name: "IsRegistred",
                table: "AspNetUsers",
                newName: "isRegistred");

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 13, 40, 1, 435, DateTimeKind.Utc).AddTicks(8951));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 13, 40, 1, 435, DateTimeKind.Utc).AddTicks(8956));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 13, 40, 1, 435, DateTimeKind.Utc).AddTicks(8954));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 13, 40, 1, 435, DateTimeKind.Utc).AddTicks(8958));

            migrationBuilder.CreateIndex(
                name: "IX_TB_PROFESSIONAL_COD_USER",
                table: "TB_PROFESSIONAL",
                column: "COD_USER");
        }
    }
}
