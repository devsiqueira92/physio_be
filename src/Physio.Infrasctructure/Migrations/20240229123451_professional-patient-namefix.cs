using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physio.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class professionalpatientnamefix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalPatients_TB_PATIENT_PatientEntityId",
                table: "ProfessionalPatients");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalPatients_TB_PROFESSIONAL_ProfessionalEntityId",
                table: "ProfessionalPatients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessionalPatients",
                table: "ProfessionalPatients");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalPatients_PatientEntityId",
                table: "ProfessionalPatients");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalPatients_ProfessionalEntityId",
                table: "ProfessionalPatients");

            migrationBuilder.DropColumn(
                name: "PatientEntityId",
                table: "ProfessionalPatients");

            migrationBuilder.DropColumn(
                name: "ProfessionalEntityId",
                table: "ProfessionalPatients");

            migrationBuilder.RenameTable(
                name: "ProfessionalPatients",
                newName: "TB_PROFESSIONAL_PATIENT");

            migrationBuilder.RenameColumn(
                name: "ProfessionalId",
                table: "TB_PROFESSIONAL_PATIENT",
                newName: "COD_PROFESSIONAL");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "TB_PROFESSIONAL_PATIENT",
                newName: "COD_PATIENT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_PROFESSIONAL_PATIENT",
                table: "TB_PROFESSIONAL_PATIENT",
                columns: new[] { "COD_PATIENT", "COD_PROFESSIONAL" });

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 29, 12, 34, 51, 259, DateTimeKind.Utc).AddTicks(3239));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 29, 12, 34, 51, 259, DateTimeKind.Utc).AddTicks(3245));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 29, 12, 34, 51, 259, DateTimeKind.Utc).AddTicks(3243));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 29, 12, 34, 51, 259, DateTimeKind.Utc).AddTicks(3247));

            migrationBuilder.CreateIndex(
                name: "IX_TB_PROFESSIONAL_PATIENT_COD_PROFESSIONAL",
                table: "TB_PROFESSIONAL_PATIENT",
                column: "COD_PROFESSIONAL");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PROFESSIONAL_PATIENT_TB_PATIENT_COD_PATIENT",
                table: "TB_PROFESSIONAL_PATIENT",
                column: "COD_PATIENT",
                principalTable: "TB_PATIENT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PROFESSIONAL_PATIENT_TB_PROFESSIONAL_COD_PROFESSIONAL",
                table: "TB_PROFESSIONAL_PATIENT",
                column: "COD_PROFESSIONAL",
                principalTable: "TB_PROFESSIONAL",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PROFESSIONAL_PATIENT_TB_PATIENT_COD_PATIENT",
                table: "TB_PROFESSIONAL_PATIENT");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_PROFESSIONAL_PATIENT_TB_PROFESSIONAL_COD_PROFESSIONAL",
                table: "TB_PROFESSIONAL_PATIENT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_PROFESSIONAL_PATIENT",
                table: "TB_PROFESSIONAL_PATIENT");

            migrationBuilder.DropIndex(
                name: "IX_TB_PROFESSIONAL_PATIENT_COD_PROFESSIONAL",
                table: "TB_PROFESSIONAL_PATIENT");

            migrationBuilder.RenameTable(
                name: "TB_PROFESSIONAL_PATIENT",
                newName: "ProfessionalPatients");

            migrationBuilder.RenameColumn(
                name: "COD_PROFESSIONAL",
                table: "ProfessionalPatients",
                newName: "ProfessionalId");

            migrationBuilder.RenameColumn(
                name: "COD_PATIENT",
                table: "ProfessionalPatients",
                newName: "PatientId");

            migrationBuilder.AddColumn<Guid>(
                name: "PatientEntityId",
                table: "ProfessionalPatients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessionalEntityId",
                table: "ProfessionalPatients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessionalPatients",
                table: "ProfessionalPatients",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 29, 12, 33, 7, 851, DateTimeKind.Utc).AddTicks(2653));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 29, 12, 33, 7, 851, DateTimeKind.Utc).AddTicks(2659));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 29, 12, 33, 7, 851, DateTimeKind.Utc).AddTicks(2657));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 29, 12, 33, 7, 851, DateTimeKind.Utc).AddTicks(2661));

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalPatients_PatientEntityId",
                table: "ProfessionalPatients",
                column: "PatientEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalPatients_ProfessionalEntityId",
                table: "ProfessionalPatients",
                column: "ProfessionalEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalPatients_TB_PATIENT_PatientEntityId",
                table: "ProfessionalPatients",
                column: "PatientEntityId",
                principalTable: "TB_PATIENT",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalPatients_TB_PROFESSIONAL_ProfessionalEntityId",
                table: "ProfessionalPatients",
                column: "ProfessionalEntityId",
                principalTable: "TB_PROFESSIONAL",
                principalColumn: "ID");
        }
    }
}
