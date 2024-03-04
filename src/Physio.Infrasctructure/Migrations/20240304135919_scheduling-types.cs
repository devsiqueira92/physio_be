using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physio.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class schedulingtypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_SCHEDULING_TB_CLINIC_COD_CLINIC",
                table: "TB_SCHEDULING");

            migrationBuilder.DropIndex(
                name: "IX_TB_SCHEDULING_COD_CLINIC",
                table: "TB_SCHEDULING");

            migrationBuilder.DropColumn(
                name: "COD_CLINIC",
                table: "TB_SCHEDULING");

            migrationBuilder.AlterColumn<Guid>(
                name: "COD_SCHEDULING_TYPE",
                table: "TB_SCHEDULING",
                type: "uniqueidentifier",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 4, 13, 59, 18, 201, DateTimeKind.Utc).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 4, 13, 59, 18, 201, DateTimeKind.Utc).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 4, 13, 59, 18, 201, DateTimeKind.Utc).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 4, 13, 59, 18, 201, DateTimeKind.Utc).AddTicks(2205));

            migrationBuilder.CreateIndex(
                name: "IX_TB_SCHEDULING_COD_SCHEDULING_TYPE",
                table: "TB_SCHEDULING",
                column: "COD_SCHEDULING_TYPE");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_SCHEDULING_TB_SCHEDULING_TYPE_COD_SCHEDULING_TYPE",
                table: "TB_SCHEDULING",
                column: "COD_SCHEDULING_TYPE",
                principalTable: "TB_SCHEDULING_TYPE",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_SCHEDULING_TB_SCHEDULING_TYPE_COD_SCHEDULING_TYPE",
                table: "TB_SCHEDULING");

            migrationBuilder.DropIndex(
                name: "IX_TB_SCHEDULING_COD_SCHEDULING_TYPE",
                table: "TB_SCHEDULING");

            migrationBuilder.AlterColumn<string>(
                name: "COD_SCHEDULING_TYPE",
                table: "TB_SCHEDULING",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldMaxLength: 36);

            migrationBuilder.AddColumn<Guid>(
                name: "COD_CLINIC",
                table: "TB_SCHEDULING",
                type: "uniqueidentifier",
                maxLength: 36,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 4, 13, 48, 18, 109, DateTimeKind.Utc).AddTicks(7805));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 4, 13, 48, 18, 109, DateTimeKind.Utc).AddTicks(7810));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 4, 13, 48, 18, 109, DateTimeKind.Utc).AddTicks(7808));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 4, 13, 48, 18, 109, DateTimeKind.Utc).AddTicks(7812));

            migrationBuilder.CreateIndex(
                name: "IX_TB_SCHEDULING_COD_CLINIC",
                table: "TB_SCHEDULING",
                column: "COD_CLINIC");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_SCHEDULING_TB_CLINIC_COD_CLINIC",
                table: "TB_SCHEDULING",
                column: "COD_CLINIC",
                principalTable: "TB_CLINIC",
                principalColumn: "ID");
        }
    }
}
