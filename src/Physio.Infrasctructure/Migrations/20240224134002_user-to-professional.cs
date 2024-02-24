using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physio.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class usertoprofessional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "COD_USER",
                table: "TB_PROFESSIONAL",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isRegistred",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PROFESSIONAL_AspNetUsers_COD_USER",
                table: "TB_PROFESSIONAL",
                column: "COD_USER",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PROFESSIONAL_AspNetUsers_COD_USER",
                table: "TB_PROFESSIONAL");

            migrationBuilder.DropIndex(
                name: "IX_TB_PROFESSIONAL_COD_USER",
                table: "TB_PROFESSIONAL");

            migrationBuilder.DropColumn(
                name: "COD_USER",
                table: "TB_PROFESSIONAL");

            migrationBuilder.DropColumn(
                name: "isRegistred",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 23, 0, 51, 9, 684, DateTimeKind.Utc).AddTicks(5786));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 23, 0, 51, 9, 684, DateTimeKind.Utc).AddTicks(5793));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 23, 0, 51, 9, 684, DateTimeKind.Utc).AddTicks(5791));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 23, 0, 51, 9, 684, DateTimeKind.Utc).AddTicks(5840));
        }
    }
}
