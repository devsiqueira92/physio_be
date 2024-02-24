using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physio.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class useridclinictable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEntityId",
                table: "TB_CLINIC",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TB_CLINIC",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 17, 24, 18, 287, DateTimeKind.Utc).AddTicks(4708));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 17, 24, 18, 287, DateTimeKind.Utc).AddTicks(4717));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 17, 24, 18, 287, DateTimeKind.Utc).AddTicks(4714));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 17, 24, 18, 287, DateTimeKind.Utc).AddTicks(4721));

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLINIC_UserEntityId",
                table: "TB_CLINIC",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CLINIC_AspNetUsers_UserEntityId",
                table: "TB_CLINIC",
                column: "UserEntityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CLINIC_AspNetUsers_UserEntityId",
                table: "TB_CLINIC");

            migrationBuilder.DropIndex(
                name: "IX_TB_CLINIC_UserEntityId",
                table: "TB_CLINIC");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "TB_CLINIC");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TB_CLINIC");

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 16, 46, 45, 556, DateTimeKind.Utc).AddTicks(7460));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 16, 46, 45, 556, DateTimeKind.Utc).AddTicks(7474));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 16, 46, 45, 556, DateTimeKind.Utc).AddTicks(7463));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 2, 24, 16, 46, 45, 556, DateTimeKind.Utc).AddTicks(7476));
        }
    }
}
