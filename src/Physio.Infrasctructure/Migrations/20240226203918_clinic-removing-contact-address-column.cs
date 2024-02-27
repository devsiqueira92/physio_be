using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physio.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class clinicremovingcontactaddresscolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ADDRESS_TB_CLINIC_COD_CLINIC",
                table: "TB_ADDRESS");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_ADDRESS_TB_PATIENT_COD_PATIENT",
                table: "TB_ADDRESS");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_ADDRESS_TB_PROFESSIONAL_COD_PROFESSIONAL",
                table: "TB_ADDRESS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ADDRESS_COD_CLINIC",
                table: "TB_ADDRESS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ADDRESS_COD_PATIENT",
                table: "TB_ADDRESS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ADDRESS_COD_PROFESSIONAL",
                table: "TB_ADDRESS");

            migrationBuilder.DropColumn(
                name: "TXT_ADDRESS",
                table: "TB_CLINIC");

            migrationBuilder.DropColumn(
                name: "TXT_CONTACT",
                table: "TB_CLINIC");

            migrationBuilder.DropColumn(
                name: "COD_CLINIC",
                table: "TB_ADDRESS");

            migrationBuilder.DropColumn(
                name: "COD_PATIENT",
                table: "TB_ADDRESS");

            migrationBuilder.DropColumn(
                name: "COD_PROFESSIONAL",
                table: "TB_ADDRESS");

            migrationBuilder.AddColumn<string>(
                name: "COD_SCHEDULING_TYPE",
                table: "TB_SCHEDULING",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TXT_IDENTIFICATION_NUMBER",
                table: "TB_PATIENT",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "COD_USER",
                table: "TB_ADDRESS",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 26, 20, 39, 18, 139, DateTimeKind.Utc).AddTicks(2892));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 26, 20, 39, 18, 139, DateTimeKind.Utc).AddTicks(2907));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 26, 20, 39, 18, 139, DateTimeKind.Utc).AddTicks(2896));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 26, 20, 39, 18, 139, DateTimeKind.Utc).AddTicks(2910));

            migrationBuilder.CreateIndex(
                name: "IX_TB_PATIENT_TXT_IDENTIFICATION_NUMBER",
                table: "TB_PATIENT",
                column: "TXT_IDENTIFICATION_NUMBER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_ADDRESS_COD_USER",
                table: "TB_ADDRESS",
                column: "COD_USER");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ADDRESS_AspNetUsers_COD_USER",
                table: "TB_ADDRESS",
                column: "COD_USER",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ADDRESS_AspNetUsers_COD_USER",
                table: "TB_ADDRESS");

            migrationBuilder.DropIndex(
                name: "IX_TB_PATIENT_TXT_IDENTIFICATION_NUMBER",
                table: "TB_PATIENT");

            migrationBuilder.DropIndex(
                name: "IX_TB_ADDRESS_COD_USER",
                table: "TB_ADDRESS");

            migrationBuilder.DropColumn(
                name: "COD_SCHEDULING_TYPE",
                table: "TB_SCHEDULING");

            migrationBuilder.DropColumn(
                name: "TXT_IDENTIFICATION_NUMBER",
                table: "TB_PATIENT");

            migrationBuilder.DropColumn(
                name: "COD_USER",
                table: "TB_ADDRESS");

            migrationBuilder.AddColumn<string>(
                name: "TXT_ADDRESS",
                table: "TB_CLINIC",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TXT_CONTACT",
                table: "TB_CLINIC",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "COD_CLINIC",
                table: "TB_ADDRESS",
                type: "uniqueidentifier",
                maxLength: 36,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "COD_PATIENT",
                table: "TB_ADDRESS",
                type: "uniqueidentifier",
                maxLength: 36,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "COD_PROFESSIONAL",
                table: "TB_ADDRESS",
                type: "uniqueidentifier",
                maxLength: 36,
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
                name: "IX_TB_ADDRESS_COD_CLINIC",
                table: "TB_ADDRESS",
                column: "COD_CLINIC");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ADDRESS_COD_PATIENT",
                table: "TB_ADDRESS",
                column: "COD_PATIENT");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ADDRESS_COD_PROFESSIONAL",
                table: "TB_ADDRESS",
                column: "COD_PROFESSIONAL");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ADDRESS_TB_CLINIC_COD_CLINIC",
                table: "TB_ADDRESS",
                column: "COD_CLINIC",
                principalTable: "TB_CLINIC",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ADDRESS_TB_PATIENT_COD_PATIENT",
                table: "TB_ADDRESS",
                column: "COD_PATIENT",
                principalTable: "TB_PATIENT",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ADDRESS_TB_PROFESSIONAL_COD_PROFESSIONAL",
                table: "TB_ADDRESS",
                column: "COD_PROFESSIONAL",
                principalTable: "TB_PROFESSIONAL",
                principalColumn: "ID");
        }
    }
}
