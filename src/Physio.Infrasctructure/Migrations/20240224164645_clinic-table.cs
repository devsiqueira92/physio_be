using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physio.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class clinictable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PROFESSIONAL_CLINIC_ClinicEntity_COD_CLINIC",
                table: "TB_PROFESSIONAL_CLINIC");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClinicEntity",
                table: "ClinicEntity");

            migrationBuilder.RenameTable(
                name: "ClinicEntity",
                newName: "TB_CLINIC");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TB_CLINIC",
                newName: "TXT_NAME");

            migrationBuilder.RenameColumn(
                name: "IdentificationNumber",
                table: "TB_CLINIC",
                newName: "TXT_IDENTIFICATION_NUMBER");

            migrationBuilder.RenameColumn(
                name: "Contact",
                table: "TB_CLINIC",
                newName: "TXT_CONTACT");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "TB_CLINIC",
                newName: "TXT_ADDRESS");

            migrationBuilder.AddColumn<Guid>(
                name: "COD_CREATED_BY",
                table: "TB_PROFESSIONAL_CLINIC",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "COD_UPDATED_BY",
                table: "TB_PROFESSIONAL_CLINIC",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DAT_CREATED_ON",
                table: "TB_PROFESSIONAL_CLINIC",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DAT_UPDATED_ON",
                table: "TB_PROFESSIONAL_CLINIC",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FLG_IS_DELETED",
                table: "TB_PROFESSIONAL_CLINIC",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ID",
                table: "TB_PROFESSIONAL_CLINIC",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "TXT_NAME",
                table: "TB_CLINIC",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TXT_IDENTIFICATION_NUMBER",
                table: "TB_CLINIC",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TXT_CONTACT",
                table: "TB_CLINIC",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TXT_ADDRESS",
                table: "TB_CLINIC",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_CLINIC",
                table: "TB_CLINIC",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 16, 46, 45, 556, DateTimeKind.Utc).AddTicks(7460));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 16, 46, 45, 556, DateTimeKind.Utc).AddTicks(7474));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 16, 46, 45, 556, DateTimeKind.Utc).AddTicks(7463));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 16, 46, 45, 556, DateTimeKind.Utc).AddTicks(7476));

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLINIC_TXT_IDENTIFICATION_NUMBER",
                table: "TB_CLINIC",
                column: "TXT_IDENTIFICATION_NUMBER",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PROFESSIONAL_CLINIC_TB_CLINIC_COD_CLINIC",
                table: "TB_PROFESSIONAL_CLINIC",
                column: "COD_CLINIC",
                principalTable: "TB_CLINIC",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PROFESSIONAL_CLINIC_TB_CLINIC_COD_CLINIC",
                table: "TB_PROFESSIONAL_CLINIC");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_CLINIC",
                table: "TB_CLINIC");

            migrationBuilder.DropIndex(
                name: "IX_TB_CLINIC_TXT_IDENTIFICATION_NUMBER",
                table: "TB_CLINIC");

            migrationBuilder.DropColumn(
                name: "COD_CREATED_BY",
                table: "TB_PROFESSIONAL_CLINIC");

            migrationBuilder.DropColumn(
                name: "COD_UPDATED_BY",
                table: "TB_PROFESSIONAL_CLINIC");

            migrationBuilder.DropColumn(
                name: "DAT_CREATED_ON",
                table: "TB_PROFESSIONAL_CLINIC");

            migrationBuilder.DropColumn(
                name: "DAT_UPDATED_ON",
                table: "TB_PROFESSIONAL_CLINIC");

            migrationBuilder.DropColumn(
                name: "FLG_IS_DELETED",
                table: "TB_PROFESSIONAL_CLINIC");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "TB_PROFESSIONAL_CLINIC");

            migrationBuilder.RenameTable(
                name: "TB_CLINIC",
                newName: "ClinicEntity");

            migrationBuilder.RenameColumn(
                name: "TXT_NAME",
                table: "ClinicEntity",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TXT_IDENTIFICATION_NUMBER",
                table: "ClinicEntity",
                newName: "IdentificationNumber");

            migrationBuilder.RenameColumn(
                name: "TXT_CONTACT",
                table: "ClinicEntity",
                newName: "Contact");

            migrationBuilder.RenameColumn(
                name: "TXT_ADDRESS",
                table: "ClinicEntity",
                newName: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ClinicEntity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IdentificationNumber",
                table: "ClinicEntity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Contact",
                table: "ClinicEntity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "ClinicEntity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClinicEntity",
                table: "ClinicEntity",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 15, 37, 20, 830, DateTimeKind.Utc).AddTicks(4213));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 15, 37, 20, 830, DateTimeKind.Utc).AddTicks(4277));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 15, 37, 20, 830, DateTimeKind.Utc).AddTicks(4216));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 15, 37, 20, 830, DateTimeKind.Utc).AddTicks(4292));

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PROFESSIONAL_CLINIC_ClinicEntity_COD_CLINIC",
                table: "TB_PROFESSIONAL_CLINIC",
                column: "COD_CLINIC",
                principalTable: "ClinicEntity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
