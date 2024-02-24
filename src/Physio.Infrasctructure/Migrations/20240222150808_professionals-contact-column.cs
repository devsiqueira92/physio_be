using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physio.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class professionalscontactcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "COD_REGISTER_NUMBER",
                table: "TB_PROFESSIONAL",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "TXT_CONTACT",
                table: "TB_PROFESSIONAL",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TXT_CONTACT",
                table: "TB_PROFESSIONAL");

            migrationBuilder.AlterColumn<short>(
                name: "COD_REGISTER_NUMBER",
                table: "TB_PROFESSIONAL",
                type: "smallint",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }
    }
}
