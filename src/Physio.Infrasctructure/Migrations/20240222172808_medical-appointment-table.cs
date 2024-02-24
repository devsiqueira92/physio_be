using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physio.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class medicalappointmenttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_MEDICAL_APPOINTMENT",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TXT_BEATS_MINUTE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    TXT_BLOOD_PRESSURE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TXT_BLOOD_OXYGENATION = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TXT_EVOLUTION = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    TXT_NOTES = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    DBL_WEIGHT = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    COD_SCHEDULING = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FLG_IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    DAT_UPDATED_ON = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COD_UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DAT_CREATED_ON = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COD_CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MEDICAL_APPOINTMENT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_MEDICAL_APPOINTMENT_TB_SCHEDULING_COD_SCHEDULING",
                        column: x => x.COD_SCHEDULING,
                        principalTable: "TB_SCHEDULING",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_MEDICAL_APPOINTMENT_COD_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT",
                column: "COD_SCHEDULING");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_MEDICAL_APPOINTMENT");
        }
    }
}
