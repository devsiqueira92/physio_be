using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physio.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class clinicpatienttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CLINIC_PATIENT",
                columns: table => new
                {
                    COD_PATIENTS = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_CLINIC = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FLG_IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    DAT_UPDATED_ON = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COD_UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DAT_CREATED_ON = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COD_CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLINIC_PATIENT", x => new { x.COD_PATIENTS, x.COD_CLINIC });
                    table.ForeignKey(
                        name: "FK_TB_CLINIC_PATIENT_TB_CLINIC_COD_CLINIC",
                        column: x => x.COD_CLINIC,
                        principalTable: "TB_CLINIC",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CLINIC_PATIENT_TB_PATIENT_COD_PATIENTS",
                        column: x => x.COD_PATIENTS,
                        principalTable: "TB_PATIENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 20, 46, 22, 634, DateTimeKind.Utc).AddTicks(1747));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 20, 46, 22, 634, DateTimeKind.Utc).AddTicks(1753));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 20, 46, 22, 634, DateTimeKind.Utc).AddTicks(1751));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 20, 46, 22, 634, DateTimeKind.Utc).AddTicks(1755));

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLINIC_PATIENT_COD_CLINIC",
                table: "TB_CLINIC_PATIENT",
                column: "COD_CLINIC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CLINIC_PATIENT");

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 17, 25, 47, 751, DateTimeKind.Utc).AddTicks(2643));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 17, 25, 47, 751, DateTimeKind.Utc).AddTicks(2660));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 17, 25, 47, 751, DateTimeKind.Utc).AddTicks(2646));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 17, 25, 47, 751, DateTimeKind.Utc).AddTicks(2663));
        }
    }
}
