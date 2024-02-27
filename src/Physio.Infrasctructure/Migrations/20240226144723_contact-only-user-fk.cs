using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physio.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class contactonlyuserfk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CONTACT_TB_CLINIC_COD_CLINIC",
                table: "TB_CONTACT");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_CONTACT_TB_PATIENT_COD_PATIENT",
                table: "TB_CONTACT");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_CONTACT_TB_PROFESSIONAL_COD_PROFESSIONAL",
                table: "TB_CONTACT");

            migrationBuilder.DropIndex(
                name: "IX_TB_CONTACT_COD_CLINIC",
                table: "TB_CONTACT");

            migrationBuilder.DropIndex(
                name: "IX_TB_CONTACT_COD_PATIENT",
                table: "TB_CONTACT");

            migrationBuilder.DropIndex(
                name: "IX_TB_CONTACT_COD_PROFESSIONAL",
                table: "TB_CONTACT");

            migrationBuilder.DropColumn(
                name: "COD_CLINIC",
                table: "TB_CONTACT");

            migrationBuilder.DropColumn(
                name: "COD_PATIENT",
                table: "TB_CONTACT");

            migrationBuilder.DropColumn(
                name: "COD_PROFESSIONAL",
                table: "TB_CONTACT");

            migrationBuilder.AddColumn<string>(
                name: "COD_USER",
                table: "TB_CONTACT",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 26, 14, 47, 22, 713, DateTimeKind.Utc).AddTicks(9109));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 26, 14, 47, 22, 713, DateTimeKind.Utc).AddTicks(9117));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 26, 14, 47, 22, 713, DateTimeKind.Utc).AddTicks(9114));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 26, 14, 47, 22, 713, DateTimeKind.Utc).AddTicks(9131));

            migrationBuilder.CreateIndex(
                name: "IX_TB_CONTACT_COD_USER",
                table: "TB_CONTACT",
                column: "COD_USER");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CONTACT_AspNetUsers_COD_USER",
                table: "TB_CONTACT",
                column: "COD_USER",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CONTACT_AspNetUsers_COD_USER",
                table: "TB_CONTACT");

            migrationBuilder.DropIndex(
                name: "IX_TB_CONTACT_COD_USER",
                table: "TB_CONTACT");

            migrationBuilder.DropColumn(
                name: "COD_USER",
                table: "TB_CONTACT");

            migrationBuilder.AddColumn<Guid>(
                name: "COD_CLINIC",
                table: "TB_CONTACT",
                type: "uniqueidentifier",
                maxLength: 36,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "COD_PATIENT",
                table: "TB_CONTACT",
                type: "uniqueidentifier",
                maxLength: 36,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "COD_PROFESSIONAL",
                table: "TB_CONTACT",
                type: "uniqueidentifier",
                maxLength: 36,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 25, 1, 9, 49, 754, DateTimeKind.Utc).AddTicks(942));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 25, 1, 9, 49, 754, DateTimeKind.Utc).AddTicks(948));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 25, 1, 9, 49, 754, DateTimeKind.Utc).AddTicks(946));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 25, 1, 9, 49, 754, DateTimeKind.Utc).AddTicks(950));

            migrationBuilder.CreateIndex(
                name: "IX_TB_CONTACT_COD_CLINIC",
                table: "TB_CONTACT",
                column: "COD_CLINIC");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CONTACT_COD_PATIENT",
                table: "TB_CONTACT",
                column: "COD_PATIENT");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CONTACT_COD_PROFESSIONAL",
                table: "TB_CONTACT",
                column: "COD_PROFESSIONAL");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CONTACT_TB_CLINIC_COD_CLINIC",
                table: "TB_CONTACT",
                column: "COD_CLINIC",
                principalTable: "TB_CLINIC",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CONTACT_TB_PATIENT_COD_PATIENT",
                table: "TB_CONTACT",
                column: "COD_PATIENT",
                principalTable: "TB_PATIENT",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CONTACT_TB_PROFESSIONAL_COD_PROFESSIONAL",
                table: "TB_CONTACT",
                column: "COD_PROFESSIONAL",
                principalTable: "TB_PROFESSIONAL",
                principalColumn: "ID");
        }
    }
}
