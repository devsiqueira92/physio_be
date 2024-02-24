using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physio.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class schedulingtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TXT_CONTACT",
                table: "TB_PROFESSIONAL",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "TB_SCHEDULING_STATUS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TXT_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FLG_IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    DAT_UPDATED_ON = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COD_UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DAT_CREATED_ON = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COD_CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SCHEDULING_STATUS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_SCHEDULING",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DAT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COD_PATIENT = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_PROFESSIONAL = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_SCHEDULING_STATUS = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FLG_IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    DAT_UPDATED_ON = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COD_UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DAT_CREATED_ON = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COD_CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SCHEDULING", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_SCHEDULING_TB_PATIENT_COD_PATIENT",
                        column: x => x.COD_PATIENT,
                        principalTable: "TB_PATIENT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_SCHEDULING_TB_PROFESSIONAL_COD_PROFESSIONAL",
                        column: x => x.COD_PROFESSIONAL,
                        principalTable: "TB_PROFESSIONAL",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_SCHEDULING_TB_SCHEDULING_STATUS_COD_SCHEDULING_STATUS",
                        column: x => x.COD_SCHEDULING_STATUS,
                        principalTable: "TB_SCHEDULING_STATUS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_SCHEDULING_COD_PATIENT",
                table: "TB_SCHEDULING",
                column: "COD_PATIENT");

            migrationBuilder.CreateIndex(
                name: "IX_TB_SCHEDULING_COD_PROFESSIONAL",
                table: "TB_SCHEDULING",
                column: "COD_PROFESSIONAL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_SCHEDULING_COD_SCHEDULING_STATUS",
                table: "TB_SCHEDULING",
                column: "COD_SCHEDULING_STATUS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_SCHEDULING");

            migrationBuilder.DropTable(
                name: "TB_SCHEDULING_STATUS");

            migrationBuilder.AlterColumn<string>(
                name: "TXT_CONTACT",
                table: "TB_PROFESSIONAL",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);
        }
    }
}
