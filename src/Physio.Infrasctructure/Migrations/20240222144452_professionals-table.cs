using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physio.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class professionalstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PROFESSIONAL",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_REGISTER_NUMBER = table.Column<short>(type: "smallint", maxLength: 10, nullable: false),
                    DEC_APPOINTMENT_VALUE = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    FLG_IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    DAT_UPDATED_ON = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COD_UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DAT_CREATED_ON = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COD_CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TXT_NAME = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    DAT_BIRTH_DATE = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PROFESSIONAL", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PROFESSIONAL_COD_REGISTER_NUMBER",
                table: "TB_PROFESSIONAL",
                column: "COD_REGISTER_NUMBER",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PROFESSIONAL");
        }
    }
}
