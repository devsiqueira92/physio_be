using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physio.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class newschedulingtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_SCHEDULING_TYPE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TXT_DATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FLG_IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    DAT_UPDATED_ON = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COD_UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DAT_CREATED_ON = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COD_CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SCHEDULING_TYPE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_CLINIC_SCHEDULING",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DAT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COD_SCHEDULING_TYPE = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    COD_PATIENT = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    COD_PROFESSIONAL = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    COD_SCHEDULING_STATUS = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    COD_CLINIC = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    FLG_IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    DAT_UPDATED_ON = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COD_UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DAT_CREATED_ON = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COD_CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLINIC_SCHEDULING", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_CLINIC_SCHEDULING_TB_CLINIC_COD_CLINIC",
                        column: x => x.COD_CLINIC,
                        principalTable: "TB_CLINIC",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_CLINIC_SCHEDULING_TB_PATIENT_COD_PATIENT",
                        column: x => x.COD_PATIENT,
                        principalTable: "TB_PATIENT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_CLINIC_SCHEDULING_TB_PROFESSIONAL_COD_PROFESSIONAL",
                        column: x => x.COD_PROFESSIONAL,
                        principalTable: "TB_PROFESSIONAL",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_CLINIC_SCHEDULING_TB_SCHEDULING_STATUS_COD_SCHEDULING_STATUS",
                        column: x => x.COD_SCHEDULING_STATUS,
                        principalTable: "TB_SCHEDULING_STATUS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_CLINIC_SCHEDULING_TB_SCHEDULING_TYPE_COD_SCHEDULING_TYPE",
                        column: x => x.COD_SCHEDULING_TYPE,
                        principalTable: "TB_SCHEDULING_TYPE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TB_PROFESSIONAL_SCHEDULING",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DAT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COD_SCHEDULING_TYPE = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    COD_PATIENT = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    COD_PROFESSIONAL = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    COD_SCHEDULING_STATUS = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    FLG_IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    DAT_UPDATED_ON = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COD_UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DAT_CREATED_ON = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COD_CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PROFESSIONAL_SCHEDULING", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_PROFESSIONAL_SCHEDULING_TB_PATIENT_COD_PATIENT",
                        column: x => x.COD_PATIENT,
                        principalTable: "TB_PATIENT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_PROFESSIONAL_SCHEDULING_TB_PROFESSIONAL_COD_PROFESSIONAL",
                        column: x => x.COD_PROFESSIONAL,
                        principalTable: "TB_PROFESSIONAL",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_PROFESSIONAL_SCHEDULING_TB_SCHEDULING_STATUS_COD_SCHEDULING_STATUS",
                        column: x => x.COD_SCHEDULING_STATUS,
                        principalTable: "TB_SCHEDULING_STATUS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_PROFESSIONAL_SCHEDULING_TB_SCHEDULING_TYPE_COD_SCHEDULING_TYPE",
                        column: x => x.COD_SCHEDULING_TYPE,
                        principalTable: "TB_SCHEDULING_TYPE",
                        principalColumn: "ID");
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CLINIC_SCHEDULING");

            migrationBuilder.DropTable(
                name: "TB_PROFESSIONAL_SCHEDULING");

            migrationBuilder.DropTable(
                name: "TB_SCHEDULING_TYPE");

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
        }
    }
}
