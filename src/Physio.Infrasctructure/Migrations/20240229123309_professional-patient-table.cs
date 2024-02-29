using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physio.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class professionalpatienttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfessionalPatients",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProfessionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfessionalEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FLG_IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    DAT_UPDATED_ON = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COD_UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DAT_CREATED_ON = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COD_CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalPatients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProfessionalPatients_TB_PATIENT_PatientEntityId",
                        column: x => x.PatientEntityId,
                        principalTable: "TB_PATIENT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ProfessionalPatients_TB_PROFESSIONAL_ProfessionalEntityId",
                        column: x => x.ProfessionalEntityId,
                        principalTable: "TB_PROFESSIONAL",
                        principalColumn: "ID");
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessionalPatients");

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 26, 21, 33, 26, 560, DateTimeKind.Utc).AddTicks(3211));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 26, 21, 33, 26, 560, DateTimeKind.Utc).AddTicks(3217));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 26, 21, 33, 26, 560, DateTimeKind.Utc).AddTicks(3215));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 26, 21, 33, 26, 560, DateTimeKind.Utc).AddTicks(3219));
        }
    }
}
