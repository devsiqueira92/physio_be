using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physio.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class updatingschedulingtypecolumnname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TXT_DATE",
                table: "TB_SCHEDULING_TYPE",
                newName: "TXT_NAME");

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 14, 10, 39, 43, 65, DateTimeKind.Utc).AddTicks(5950));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 14, 10, 39, 43, 65, DateTimeKind.Utc).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 14, 10, 39, 43, 65, DateTimeKind.Utc).AddTicks(5954));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 14, 10, 39, 43, 65, DateTimeKind.Utc).AddTicks(5958));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TXT_NAME",
                table: "TB_SCHEDULING_TYPE",
                newName: "TXT_DATE");

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 12, 16, 8, 0, 272, DateTimeKind.Utc).AddTicks(7350));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 12, 16, 8, 0, 272, DateTimeKind.Utc).AddTicks(7366));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 12, 16, 8, 0, 272, DateTimeKind.Utc).AddTicks(7354));

            migrationBuilder.UpdateData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"),
                column: "DAT_CREATED_ON",
                value: new DateTime(2024, 3, 12, 16, 8, 0, 272, DateTimeKind.Utc).AddTicks(7368));
        }
    }
}
