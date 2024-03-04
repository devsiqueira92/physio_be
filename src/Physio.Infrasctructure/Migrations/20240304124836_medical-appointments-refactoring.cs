using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physio.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class medicalappointmentsrefactoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_MEDICAL_APPOINTMENT_TB_SCHEDULING_COD_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT");

            migrationBuilder.RenameColumn(
                name: "COD_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT",
                newName: "COD_PROFESSIONAL_SCHEDULING");

            migrationBuilder.RenameIndex(
                name: "IX_TB_MEDICAL_APPOINTMENT_COD_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT",
                newName: "IX_TB_MEDICAL_APPOINTMENT_COD_PROFESSIONAL_SCHEDULING");

            migrationBuilder.AddColumn<Guid>(
                name: "COD_CLINIC_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT",
                type: "uniqueidentifier",
                maxLength: 36,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 4, 12, 48, 35, 330, DateTimeKind.Utc).AddTicks(9237));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 4, 12, 48, 35, 330, DateTimeKind.Utc).AddTicks(9243));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 4, 12, 48, 35, 330, DateTimeKind.Utc).AddTicks(9241));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 4, 12, 48, 35, 330, DateTimeKind.Utc).AddTicks(9244));

            migrationBuilder.CreateIndex(
                name: "IX_TB_MEDICAL_APPOINTMENT_COD_CLINIC_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT",
                column: "COD_CLINIC_SCHEDULING");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_MEDICAL_APPOINTMENT_TB_CLINIC_SCHEDULING_COD_CLINIC_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT",
                column: "COD_CLINIC_SCHEDULING",
                principalTable: "TB_CLINIC_SCHEDULING",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_MEDICAL_APPOINTMENT_TB_PROFESSIONAL_SCHEDULING_COD_PROFESSIONAL_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT",
                column: "COD_PROFESSIONAL_SCHEDULING",
                principalTable: "TB_PROFESSIONAL_SCHEDULING",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_MEDICAL_APPOINTMENT_TB_CLINIC_SCHEDULING_COD_CLINIC_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_MEDICAL_APPOINTMENT_TB_PROFESSIONAL_SCHEDULING_COD_PROFESSIONAL_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT");

            migrationBuilder.DropIndex(
                name: "IX_TB_MEDICAL_APPOINTMENT_COD_CLINIC_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT");

            migrationBuilder.DropColumn(
                name: "COD_CLINIC_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT");

            migrationBuilder.RenameColumn(
                name: "COD_PROFESSIONAL_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT",
                newName: "COD_SCHEDULING");

            migrationBuilder.RenameIndex(
                name: "IX_TB_MEDICAL_APPOINTMENT_COD_PROFESSIONAL_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT",
                newName: "IX_TB_MEDICAL_APPOINTMENT_COD_SCHEDULING");

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 29, 19, 8, 50, 218, DateTimeKind.Utc).AddTicks(1108));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 29, 19, 8, 50, 218, DateTimeKind.Utc).AddTicks(1113));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 29, 19, 8, 50, 218, DateTimeKind.Utc).AddTicks(1111));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 29, 19, 8, 50, 218, DateTimeKind.Utc).AddTicks(1115));

            migrationBuilder.AddForeignKey(
                name: "FK_TB_MEDICAL_APPOINTMENT_TB_SCHEDULING_COD_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT",
                column: "COD_SCHEDULING",
                principalTable: "TB_SCHEDULING",
                principalColumn: "ID");
        }
    }
}
