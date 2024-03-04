using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physio.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class restartingscheduling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CLINIC_SCHEDULING_TB_CLINIC_COD_CLINIC",
                table: "TB_CLINIC_SCHEDULING");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_CLINIC_SCHEDULING_TB_PATIENT_COD_PATIENT",
                table: "TB_CLINIC_SCHEDULING");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_CLINIC_SCHEDULING_TB_PROFESSIONAL_COD_PROFESSIONAL",
                table: "TB_CLINIC_SCHEDULING");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_CLINIC_SCHEDULING_TB_SCHEDULING_STATUS_COD_SCHEDULING_STATUS",
                table: "TB_CLINIC_SCHEDULING");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_CLINIC_SCHEDULING_TB_SCHEDULING_TYPE_COD_SCHEDULING_TYPE",
                table: "TB_CLINIC_SCHEDULING");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_MEDICAL_APPOINTMENT_TB_CLINIC_SCHEDULING_COD_CLINIC_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_MEDICAL_APPOINTMENT_TB_PROFESSIONAL_SCHEDULING_COD_PROFESSIONAL_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_PROFESSIONAL_SCHEDULING_TB_PATIENT_COD_PATIENT",
                table: "TB_PROFESSIONAL_SCHEDULING");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_PROFESSIONAL_SCHEDULING_TB_PROFESSIONAL_COD_PROFESSIONAL",
                table: "TB_PROFESSIONAL_SCHEDULING");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_PROFESSIONAL_SCHEDULING_TB_SCHEDULING_STATUS_COD_SCHEDULING_STATUS",
                table: "TB_PROFESSIONAL_SCHEDULING");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_PROFESSIONAL_SCHEDULING_TB_SCHEDULING_TYPE_COD_SCHEDULING_TYPE",
                table: "TB_PROFESSIONAL_SCHEDULING");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_PROFESSIONAL_SCHEDULING",
                table: "TB_PROFESSIONAL_SCHEDULING");

            migrationBuilder.DropIndex(
                name: "IX_TB_PROFESSIONAL_SCHEDULING_COD_PATIENT",
                table: "TB_PROFESSIONAL_SCHEDULING");

            migrationBuilder.DropIndex(
                name: "IX_TB_PROFESSIONAL_SCHEDULING_COD_PROFESSIONAL",
                table: "TB_PROFESSIONAL_SCHEDULING");

            migrationBuilder.DropIndex(
                name: "IX_TB_PROFESSIONAL_SCHEDULING_COD_SCHEDULING_STATUS",
                table: "TB_PROFESSIONAL_SCHEDULING");

            migrationBuilder.DropIndex(
                name: "IX_TB_PROFESSIONAL_SCHEDULING_COD_SCHEDULING_TYPE",
                table: "TB_PROFESSIONAL_SCHEDULING");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_CLINIC_SCHEDULING",
                table: "TB_CLINIC_SCHEDULING");

            migrationBuilder.DropIndex(
                name: "IX_TB_CLINIC_SCHEDULING_COD_CLINIC",
                table: "TB_CLINIC_SCHEDULING");

            migrationBuilder.DropIndex(
                name: "IX_TB_CLINIC_SCHEDULING_COD_PATIENT",
                table: "TB_CLINIC_SCHEDULING");

            migrationBuilder.DropIndex(
                name: "IX_TB_CLINIC_SCHEDULING_COD_PROFESSIONAL",
                table: "TB_CLINIC_SCHEDULING");

            migrationBuilder.DropIndex(
                name: "IX_TB_CLINIC_SCHEDULING_COD_SCHEDULING_STATUS",
                table: "TB_CLINIC_SCHEDULING");

            migrationBuilder.DropIndex(
                name: "IX_TB_CLINIC_SCHEDULING_COD_SCHEDULING_TYPE",
                table: "TB_CLINIC_SCHEDULING");

            migrationBuilder.RenameTable(
                name: "TB_PROFESSIONAL_SCHEDULING",
                newName: "ProfessionalSchedulings");

            migrationBuilder.RenameTable(
                name: "TB_CLINIC_SCHEDULING",
                newName: "ClinicSchedulings");

            migrationBuilder.RenameColumn(
                name: "DAT_DATE",
                table: "ProfessionalSchedulings",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "COD_SCHEDULING_TYPE",
                table: "ProfessionalSchedulings",
                newName: "SchedulingTypeId");

            migrationBuilder.RenameColumn(
                name: "COD_SCHEDULING_STATUS",
                table: "ProfessionalSchedulings",
                newName: "SchedulingStatusId");

            migrationBuilder.RenameColumn(
                name: "COD_PROFESSIONAL",
                table: "ProfessionalSchedulings",
                newName: "ProfessionalId");

            migrationBuilder.RenameColumn(
                name: "COD_PATIENT",
                table: "ProfessionalSchedulings",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "DAT_DATE",
                table: "ClinicSchedulings",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "COD_SCHEDULING_TYPE",
                table: "ClinicSchedulings",
                newName: "SchedulingTypeId");

            migrationBuilder.RenameColumn(
                name: "COD_SCHEDULING_STATUS",
                table: "ClinicSchedulings",
                newName: "SchedulingStatusId");

            migrationBuilder.RenameColumn(
                name: "COD_PROFESSIONAL",
                table: "ClinicSchedulings",
                newName: "ProfessionalId");

            migrationBuilder.RenameColumn(
                name: "COD_PATIENT",
                table: "ClinicSchedulings",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "COD_CLINIC",
                table: "ClinicSchedulings",
                newName: "ClinicId");

            migrationBuilder.AddColumn<Guid>(
                name: "PatientEntityId",
                table: "ProfessionalSchedulings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessionalEntityId",
                table: "ProfessionalSchedulings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SchedulingStatusEntityId",
                table: "ProfessionalSchedulings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SchedulingTypeEntityId",
                table: "ProfessionalSchedulings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClinicEntityId",
                table: "ClinicSchedulings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PatientEntityId",
                table: "ClinicSchedulings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessionalEntityId",
                table: "ClinicSchedulings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SchedulingStatusEntityId",
                table: "ClinicSchedulings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SchedulingTypeEntityId",
                table: "ClinicSchedulings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessionalSchedulings",
                table: "ProfessionalSchedulings",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClinicSchedulings",
                table: "ClinicSchedulings",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 4, 13, 48, 18, 109, DateTimeKind.Utc).AddTicks(7805));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 4, 13, 48, 18, 109, DateTimeKind.Utc).AddTicks(7810));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 4, 13, 48, 18, 109, DateTimeKind.Utc).AddTicks(7808));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 4, 13, 48, 18, 109, DateTimeKind.Utc).AddTicks(7812));

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalSchedulings_PatientEntityId",
                table: "ProfessionalSchedulings",
                column: "PatientEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalSchedulings_ProfessionalEntityId",
                table: "ProfessionalSchedulings",
                column: "ProfessionalEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalSchedulings_SchedulingStatusEntityId",
                table: "ProfessionalSchedulings",
                column: "SchedulingStatusEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalSchedulings_SchedulingTypeEntityId",
                table: "ProfessionalSchedulings",
                column: "SchedulingTypeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicSchedulings_ClinicEntityId",
                table: "ClinicSchedulings",
                column: "ClinicEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicSchedulings_PatientEntityId",
                table: "ClinicSchedulings",
                column: "PatientEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicSchedulings_ProfessionalEntityId",
                table: "ClinicSchedulings",
                column: "ProfessionalEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicSchedulings_SchedulingStatusEntityId",
                table: "ClinicSchedulings",
                column: "SchedulingStatusEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicSchedulings_SchedulingTypeEntityId",
                table: "ClinicSchedulings",
                column: "SchedulingTypeEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicSchedulings_TB_CLINIC_ClinicEntityId",
                table: "ClinicSchedulings",
                column: "ClinicEntityId",
                principalTable: "TB_CLINIC",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicSchedulings_TB_PATIENT_PatientEntityId",
                table: "ClinicSchedulings",
                column: "PatientEntityId",
                principalTable: "TB_PATIENT",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicSchedulings_TB_PROFESSIONAL_ProfessionalEntityId",
                table: "ClinicSchedulings",
                column: "ProfessionalEntityId",
                principalTable: "TB_PROFESSIONAL",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicSchedulings_TB_SCHEDULING_STATUS_SchedulingStatusEntityId",
                table: "ClinicSchedulings",
                column: "SchedulingStatusEntityId",
                principalTable: "TB_SCHEDULING_STATUS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicSchedulings_TB_SCHEDULING_TYPE_SchedulingTypeEntityId",
                table: "ClinicSchedulings",
                column: "SchedulingTypeEntityId",
                principalTable: "TB_SCHEDULING_TYPE",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalSchedulings_TB_PATIENT_PatientEntityId",
                table: "ProfessionalSchedulings",
                column: "PatientEntityId",
                principalTable: "TB_PATIENT",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalSchedulings_TB_PROFESSIONAL_ProfessionalEntityId",
                table: "ProfessionalSchedulings",
                column: "ProfessionalEntityId",
                principalTable: "TB_PROFESSIONAL",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalSchedulings_TB_SCHEDULING_STATUS_SchedulingStatusEntityId",
                table: "ProfessionalSchedulings",
                column: "SchedulingStatusEntityId",
                principalTable: "TB_SCHEDULING_STATUS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalSchedulings_TB_SCHEDULING_TYPE_SchedulingTypeEntityId",
                table: "ProfessionalSchedulings",
                column: "SchedulingTypeEntityId",
                principalTable: "TB_SCHEDULING_TYPE",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_MEDICAL_APPOINTMENT_ClinicSchedulings_COD_CLINIC_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT",
                column: "COD_CLINIC_SCHEDULING",
                principalTable: "ClinicSchedulings",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_MEDICAL_APPOINTMENT_ProfessionalSchedulings_COD_PROFESSIONAL_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT",
                column: "COD_PROFESSIONAL_SCHEDULING",
                principalTable: "ProfessionalSchedulings",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClinicSchedulings_TB_CLINIC_ClinicEntityId",
                table: "ClinicSchedulings");

            migrationBuilder.DropForeignKey(
                name: "FK_ClinicSchedulings_TB_PATIENT_PatientEntityId",
                table: "ClinicSchedulings");

            migrationBuilder.DropForeignKey(
                name: "FK_ClinicSchedulings_TB_PROFESSIONAL_ProfessionalEntityId",
                table: "ClinicSchedulings");

            migrationBuilder.DropForeignKey(
                name: "FK_ClinicSchedulings_TB_SCHEDULING_STATUS_SchedulingStatusEntityId",
                table: "ClinicSchedulings");

            migrationBuilder.DropForeignKey(
                name: "FK_ClinicSchedulings_TB_SCHEDULING_TYPE_SchedulingTypeEntityId",
                table: "ClinicSchedulings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalSchedulings_TB_PATIENT_PatientEntityId",
                table: "ProfessionalSchedulings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalSchedulings_TB_PROFESSIONAL_ProfessionalEntityId",
                table: "ProfessionalSchedulings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalSchedulings_TB_SCHEDULING_STATUS_SchedulingStatusEntityId",
                table: "ProfessionalSchedulings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalSchedulings_TB_SCHEDULING_TYPE_SchedulingTypeEntityId",
                table: "ProfessionalSchedulings");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_MEDICAL_APPOINTMENT_ClinicSchedulings_COD_CLINIC_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_MEDICAL_APPOINTMENT_ProfessionalSchedulings_COD_PROFESSIONAL_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessionalSchedulings",
                table: "ProfessionalSchedulings");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalSchedulings_PatientEntityId",
                table: "ProfessionalSchedulings");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalSchedulings_ProfessionalEntityId",
                table: "ProfessionalSchedulings");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalSchedulings_SchedulingStatusEntityId",
                table: "ProfessionalSchedulings");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalSchedulings_SchedulingTypeEntityId",
                table: "ProfessionalSchedulings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClinicSchedulings",
                table: "ClinicSchedulings");

            migrationBuilder.DropIndex(
                name: "IX_ClinicSchedulings_ClinicEntityId",
                table: "ClinicSchedulings");

            migrationBuilder.DropIndex(
                name: "IX_ClinicSchedulings_PatientEntityId",
                table: "ClinicSchedulings");

            migrationBuilder.DropIndex(
                name: "IX_ClinicSchedulings_ProfessionalEntityId",
                table: "ClinicSchedulings");

            migrationBuilder.DropIndex(
                name: "IX_ClinicSchedulings_SchedulingStatusEntityId",
                table: "ClinicSchedulings");

            migrationBuilder.DropIndex(
                name: "IX_ClinicSchedulings_SchedulingTypeEntityId",
                table: "ClinicSchedulings");

            migrationBuilder.DropColumn(
                name: "PatientEntityId",
                table: "ProfessionalSchedulings");

            migrationBuilder.DropColumn(
                name: "ProfessionalEntityId",
                table: "ProfessionalSchedulings");

            migrationBuilder.DropColumn(
                name: "SchedulingStatusEntityId",
                table: "ProfessionalSchedulings");

            migrationBuilder.DropColumn(
                name: "SchedulingTypeEntityId",
                table: "ProfessionalSchedulings");

            migrationBuilder.DropColumn(
                name: "ClinicEntityId",
                table: "ClinicSchedulings");

            migrationBuilder.DropColumn(
                name: "PatientEntityId",
                table: "ClinicSchedulings");

            migrationBuilder.DropColumn(
                name: "ProfessionalEntityId",
                table: "ClinicSchedulings");

            migrationBuilder.DropColumn(
                name: "SchedulingStatusEntityId",
                table: "ClinicSchedulings");

            migrationBuilder.DropColumn(
                name: "SchedulingTypeEntityId",
                table: "ClinicSchedulings");

            migrationBuilder.RenameTable(
                name: "ProfessionalSchedulings",
                newName: "TB_PROFESSIONAL_SCHEDULING");

            migrationBuilder.RenameTable(
                name: "ClinicSchedulings",
                newName: "TB_CLINIC_SCHEDULING");

            migrationBuilder.RenameColumn(
                name: "SchedulingTypeId",
                table: "TB_PROFESSIONAL_SCHEDULING",
                newName: "COD_SCHEDULING_TYPE");

            migrationBuilder.RenameColumn(
                name: "SchedulingStatusId",
                table: "TB_PROFESSIONAL_SCHEDULING",
                newName: "COD_SCHEDULING_STATUS");

            migrationBuilder.RenameColumn(
                name: "ProfessionalId",
                table: "TB_PROFESSIONAL_SCHEDULING",
                newName: "COD_PROFESSIONAL");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "TB_PROFESSIONAL_SCHEDULING",
                newName: "COD_PATIENT");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "TB_PROFESSIONAL_SCHEDULING",
                newName: "DAT_DATE");

            migrationBuilder.RenameColumn(
                name: "SchedulingTypeId",
                table: "TB_CLINIC_SCHEDULING",
                newName: "COD_SCHEDULING_TYPE");

            migrationBuilder.RenameColumn(
                name: "SchedulingStatusId",
                table: "TB_CLINIC_SCHEDULING",
                newName: "COD_SCHEDULING_STATUS");

            migrationBuilder.RenameColumn(
                name: "ProfessionalId",
                table: "TB_CLINIC_SCHEDULING",
                newName: "COD_PROFESSIONAL");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "TB_CLINIC_SCHEDULING",
                newName: "COD_PATIENT");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "TB_CLINIC_SCHEDULING",
                newName: "DAT_DATE");

            migrationBuilder.RenameColumn(
                name: "ClinicId",
                table: "TB_CLINIC_SCHEDULING",
                newName: "COD_CLINIC");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_PROFESSIONAL_SCHEDULING",
                table: "TB_PROFESSIONAL_SCHEDULING",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_CLINIC_SCHEDULING",
                table: "TB_CLINIC_SCHEDULING",
                column: "ID");

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
                name: "IX_TB_PROFESSIONAL_SCHEDULING_COD_PATIENT",
                table: "TB_PROFESSIONAL_SCHEDULING",
                column: "COD_PATIENT");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PROFESSIONAL_SCHEDULING_COD_PROFESSIONAL",
                table: "TB_PROFESSIONAL_SCHEDULING",
                column: "COD_PROFESSIONAL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PROFESSIONAL_SCHEDULING_COD_SCHEDULING_STATUS",
                table: "TB_PROFESSIONAL_SCHEDULING",
                column: "COD_SCHEDULING_STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PROFESSIONAL_SCHEDULING_COD_SCHEDULING_TYPE",
                table: "TB_PROFESSIONAL_SCHEDULING",
                column: "COD_SCHEDULING_TYPE");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLINIC_SCHEDULING_COD_CLINIC",
                table: "TB_CLINIC_SCHEDULING",
                column: "COD_CLINIC");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLINIC_SCHEDULING_COD_PATIENT",
                table: "TB_CLINIC_SCHEDULING",
                column: "COD_PATIENT");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLINIC_SCHEDULING_COD_PROFESSIONAL",
                table: "TB_CLINIC_SCHEDULING",
                column: "COD_PROFESSIONAL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLINIC_SCHEDULING_COD_SCHEDULING_STATUS",
                table: "TB_CLINIC_SCHEDULING",
                column: "COD_SCHEDULING_STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLINIC_SCHEDULING_COD_SCHEDULING_TYPE",
                table: "TB_CLINIC_SCHEDULING",
                column: "COD_SCHEDULING_TYPE");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CLINIC_SCHEDULING_TB_CLINIC_COD_CLINIC",
                table: "TB_CLINIC_SCHEDULING",
                column: "COD_CLINIC",
                principalTable: "TB_CLINIC",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CLINIC_SCHEDULING_TB_PATIENT_COD_PATIENT",
                table: "TB_CLINIC_SCHEDULING",
                column: "COD_PATIENT",
                principalTable: "TB_PATIENT",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CLINIC_SCHEDULING_TB_PROFESSIONAL_COD_PROFESSIONAL",
                table: "TB_CLINIC_SCHEDULING",
                column: "COD_PROFESSIONAL",
                principalTable: "TB_PROFESSIONAL",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CLINIC_SCHEDULING_TB_SCHEDULING_STATUS_COD_SCHEDULING_STATUS",
                table: "TB_CLINIC_SCHEDULING",
                column: "COD_SCHEDULING_STATUS",
                principalTable: "TB_SCHEDULING_STATUS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CLINIC_SCHEDULING_TB_SCHEDULING_TYPE_COD_SCHEDULING_TYPE",
                table: "TB_CLINIC_SCHEDULING",
                column: "COD_SCHEDULING_TYPE",
                principalTable: "TB_SCHEDULING_TYPE",
                principalColumn: "ID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PROFESSIONAL_SCHEDULING_TB_PATIENT_COD_PATIENT",
                table: "TB_PROFESSIONAL_SCHEDULING",
                column: "COD_PATIENT",
                principalTable: "TB_PATIENT",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PROFESSIONAL_SCHEDULING_TB_PROFESSIONAL_COD_PROFESSIONAL",
                table: "TB_PROFESSIONAL_SCHEDULING",
                column: "COD_PROFESSIONAL",
                principalTable: "TB_PROFESSIONAL",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PROFESSIONAL_SCHEDULING_TB_SCHEDULING_STATUS_COD_SCHEDULING_STATUS",
                table: "TB_PROFESSIONAL_SCHEDULING",
                column: "COD_SCHEDULING_STATUS",
                principalTable: "TB_SCHEDULING_STATUS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PROFESSIONAL_SCHEDULING_TB_SCHEDULING_TYPE_COD_SCHEDULING_TYPE",
                table: "TB_PROFESSIONAL_SCHEDULING",
                column: "COD_SCHEDULING_TYPE",
                principalTable: "TB_SCHEDULING_TYPE",
                principalColumn: "ID");
        }
    }
}
