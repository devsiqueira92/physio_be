using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physio.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class professionalclinictable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClinicEntity",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FLG_IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    DAT_UPDATED_ON = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COD_UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DAT_CREATED_ON = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COD_CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicEntity", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_PROFESSIONAL_CLINIC",
                columns: table => new
                {
                    COD_PROFESSIONAL = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_CLINIC = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PROFESSIONAL_CLINIC", x => new { x.COD_PROFESSIONAL, x.COD_CLINIC });
                    table.ForeignKey(
                        name: "FK_TB_PROFESSIONAL_CLINIC_ClinicEntity_COD_CLINIC",
                        column: x => x.COD_CLINIC,
                        principalTable: "ClinicEntity",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PROFESSIONAL_CLINIC_TB_PROFESSIONAL_COD_PROFESSIONAL",
                        column: x => x.COD_PROFESSIONAL,
                        principalTable: "TB_PROFESSIONAL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_TB_PROFESSIONAL_CLINIC_COD_CLINIC",
                table: "TB_PROFESSIONAL_CLINIC",
                column: "COD_CLINIC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PROFESSIONAL_CLINIC");

            migrationBuilder.DropTable(
                name: "ClinicEntity");

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 14, 32, 50, 912, DateTimeKind.Utc).AddTicks(1987));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 14, 32, 50, 912, DateTimeKind.Utc).AddTicks(2003));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 14, 32, 50, 912, DateTimeKind.Utc).AddTicks(1991));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 14, 32, 50, 912, DateTimeKind.Utc).AddTicks(2005));
        }
    }
}
