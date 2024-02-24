using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Physio.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class addingroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_UserEntityId",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_UserEntityId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "AspNetRoles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f75bc70-66e9-4360-a5f5-60cd4d60dbee", null, "RoleEntity", "Patient", "PATIENT" },
                    { "645eb3bb-ab2a-4542-a3e1-8bd8ef945bda", null, "RoleEntity", "Professional", "PROFESSIONAL" },
                    { "ca29a123-1a4b-4d75-84eb-6f39dd886f70", null, "RoleEntity", "Clinic", "CLINIC" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f75bc70-66e9-4360-a5f5-60cd4d60dbee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "645eb3bb-ab2a-4542-a3e1-8bd8ef945bda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca29a123-1a4b-4d75-84eb-6f39dd886f70");

            migrationBuilder.AddColumn<string>(
                name: "UserEntityId",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_UserEntityId",
                table: "AspNetRoles",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_UserEntityId",
                table: "AspNetRoles",
                column: "UserEntityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
