using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physio.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class clinicscheduling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_TB_MEDICAL_APPOINTMENT_ClinicSchedulings_COD_CLINIC_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_MEDICAL_APPOINTMENT_ProfessionalSchedulings_COD_PROFESSIONAL_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT");

            migrationBuilder.DropTable(
                name: "ProfessionalSchedulings");

            migrationBuilder.DropIndex(
                name: "IX_TB_MEDICAL_APPOINTMENT_COD_CLINIC_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT");

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
                name: "COD_CLINIC_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT");

            migrationBuilder.DropColumn(
                name: "ClinicEntityId",
                table: "ClinicSchedulings");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "ClinicSchedulings");

            migrationBuilder.DropColumn(
                name: "PatientEntityId",
                table: "ClinicSchedulings");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "ClinicSchedulings");

            migrationBuilder.DropColumn(
                name: "ProfessionalEntityId",
                table: "ClinicSchedulings");

            migrationBuilder.DropColumn(
                name: "ProfessionalId",
                table: "ClinicSchedulings");

            migrationBuilder.DropColumn(
                name: "SchedulingStatusEntityId",
                table: "ClinicSchedulings");

            migrationBuilder.DropColumn(
                name: "SchedulingStatusId",
                table: "ClinicSchedulings");

            migrationBuilder.DropColumn(
                name: "SchedulingTypeEntityId",
                table: "ClinicSchedulings");

            migrationBuilder.DropColumn(
                name: "SchedulingTypeId",
                table: "ClinicSchedulings");

            migrationBuilder.RenameTable(
                name: "ClinicSchedulings",
                newName: "TB_CLINIC_SCHEDULING");

            migrationBuilder.RenameColumn(
                name: "COD_PROFESSIONAL_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT",
                newName: "COD_SCHEDULING");

            migrationBuilder.RenameIndex(
                name: "IX_TB_MEDICAL_APPOINTMENT_COD_PROFESSIONAL_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT",
                newName: "IX_TB_MEDICAL_APPOINTMENT_COD_SCHEDULING");

            migrationBuilder.RenameColumn(
                name: "ClinicId",
                table: "TB_CLINIC_SCHEDULING",
                newName: "COD_CLINIC");

            migrationBuilder.AddColumn<Guid>(
                name: "COD_SCHEDULING",
                table: "TB_CLINIC_SCHEDULING",
                type: "uniqueidentifier",
                maxLength: 36,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_CLINIC_SCHEDULING",
                table: "TB_CLINIC_SCHEDULING",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 12, 16, 8, 0, 272, DateTimeKind.Utc).AddTicks(7350));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 12, 16, 8, 0, 272, DateTimeKind.Utc).AddTicks(7366));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 12, 16, 8, 0, 272, DateTimeKind.Utc).AddTicks(7354));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 12, 16, 8, 0, 272, DateTimeKind.Utc).AddTicks(7368));

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLINIC_SCHEDULING_COD_CLINIC",
                table: "TB_CLINIC_SCHEDULING",
                column: "COD_CLINIC");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLINIC_SCHEDULING_COD_SCHEDULING",
                table: "TB_CLINIC_SCHEDULING",
                column: "COD_SCHEDULING");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CLINIC_SCHEDULING_TB_CLINIC_COD_CLINIC",
                table: "TB_CLINIC_SCHEDULING",
                column: "COD_CLINIC",
                principalTable: "TB_CLINIC",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CLINIC_SCHEDULING_TB_SCHEDULING_COD_SCHEDULING",
                table: "TB_CLINIC_SCHEDULING",
                column: "COD_SCHEDULING",
                principalTable: "TB_SCHEDULING",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_MEDICAL_APPOINTMENT_TB_SCHEDULING_COD_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT",
                column: "COD_SCHEDULING",
                principalTable: "TB_SCHEDULING",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CLINIC_SCHEDULING_TB_CLINIC_COD_CLINIC",
                table: "TB_CLINIC_SCHEDULING");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_CLINIC_SCHEDULING_TB_SCHEDULING_COD_SCHEDULING",
                table: "TB_CLINIC_SCHEDULING");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_MEDICAL_APPOINTMENT_TB_SCHEDULING_COD_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_CLINIC_SCHEDULING",
                table: "TB_CLINIC_SCHEDULING");

            migrationBuilder.DropIndex(
                name: "IX_TB_CLINIC_SCHEDULING_COD_CLINIC",
                table: "TB_CLINIC_SCHEDULING");

            migrationBuilder.DropIndex(
                name: "IX_TB_CLINIC_SCHEDULING_COD_SCHEDULING",
                table: "TB_CLINIC_SCHEDULING");

            migrationBuilder.DropColumn(
                name: "COD_SCHEDULING",
                table: "TB_CLINIC_SCHEDULING");

            migrationBuilder.RenameTable(
                name: "TB_CLINIC_SCHEDULING",
                newName: "ClinicSchedulings");

            migrationBuilder.RenameColumn(
                name: "COD_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT",
                newName: "COD_PROFESSIONAL_SCHEDULING");

            migrationBuilder.RenameIndex(
                name: "IX_TB_MEDICAL_APPOINTMENT_COD_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT",
                newName: "IX_TB_MEDICAL_APPOINTMENT_COD_PROFESSIONAL_SCHEDULING");

            migrationBuilder.RenameColumn(
                name: "COD_CLINIC",
                table: "ClinicSchedulings",
                newName: "ClinicId");

            migrationBuilder.AddColumn<Guid>(
                name: "COD_CLINIC_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT",
                type: "uniqueidentifier",
                maxLength: 36,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ClinicEntityId",
                table: "ClinicSchedulings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "ClinicSchedulings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "PatientEntityId",
                table: "ClinicSchedulings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PatientId",
                table: "ClinicSchedulings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessionalEntityId",
                table: "ClinicSchedulings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessionalId",
                table: "ClinicSchedulings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SchedulingStatusEntityId",
                table: "ClinicSchedulings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SchedulingStatusId",
                table: "ClinicSchedulings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SchedulingTypeEntityId",
                table: "ClinicSchedulings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SchedulingTypeId",
                table: "ClinicSchedulings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClinicSchedulings",
                table: "ClinicSchedulings",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "ProfessionalSchedulings",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProfessionalEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SchedulingStatusEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SchedulingTypeEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    COD_CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DAT_CREATED_ON = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FLG_IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfessionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchedulingStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchedulingTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DAT_UPDATED_ON = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalSchedulings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProfessionalSchedulings_TB_PATIENT_PatientEntityId",
                        column: x => x.PatientEntityId,
                        principalTable: "TB_PATIENT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ProfessionalSchedulings_TB_PROFESSIONAL_ProfessionalEntityId",
                        column: x => x.ProfessionalEntityId,
                        principalTable: "TB_PROFESSIONAL",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ProfessionalSchedulings_TB_SCHEDULING_STATUS_SchedulingStatusEntityId",
                        column: x => x.SchedulingStatusEntityId,
                        principalTable: "TB_SCHEDULING_STATUS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ProfessionalSchedulings_TB_SCHEDULING_TYPE_SchedulingTypeEntityId",
                        column: x => x.SchedulingTypeEntityId,
                        principalTable: "TB_SCHEDULING_TYPE",
                        principalColumn: "ID");
                });

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 4, 13, 59, 18, 201, DateTimeKind.Utc).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 4, 13, 59, 18, 201, DateTimeKind.Utc).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 4, 13, 59, 18, 201, DateTimeKind.Utc).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 4, 13, 59, 18, 201, DateTimeKind.Utc).AddTicks(2205));

            migrationBuilder.CreateIndex(
                name: "IX_TB_MEDICAL_APPOINTMENT_COD_CLINIC_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT",
                column: "COD_CLINIC_SCHEDULING");

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
    }
}
