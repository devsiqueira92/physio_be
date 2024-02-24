using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Physio.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class schedulingstatusenum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "COD_STATUS",
                table: "TB_SCHEDULING_STATUS",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TXT_BLOOD_PRESSURE",
                table: "TB_MEDICAL_APPOINTMENT",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "TXT_BLOOD_OXYGENATION",
                table: "TB_MEDICAL_APPOINTMENT",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "TXT_BEATS_MINUTE",
                table: "TB_MEDICAL_APPOINTMENT",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "DBL_WEIGHT",
                table: "TB_MEDICAL_APPOINTMENT",
                type: "decimal(6,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.InsertData(
                table: "TB_SCHEDULING_STATUS",
                columns: new[] { "ID", "COD_CREATED_BY", "DAT_CREATED_ON", "FLG_IS_DELETED", "TXT_NAME", "COD_STATUS", "COD_UPDATED_BY", "DAT_UPDATED_ON" },
                values: new object[,]
                {
                    { new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 2, 23, 0, 51, 9, 684, DateTimeKind.Utc).AddTicks(5786), false, "Cancelado", 1, null, null },
                    { new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 2, 23, 0, 51, 9, 684, DateTimeKind.Utc).AddTicks(5793), false, "Remarcado", 3, null, null },
                    { new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 2, 23, 0, 51, 9, 684, DateTimeKind.Utc).AddTicks(5791), false, "Finalizado", 2, null, null },
                    { new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 2, 23, 0, 51, 9, 684, DateTimeKind.Utc).AddTicks(5840), false, "Agendado", 4, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"));

            migrationBuilder.DeleteData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"));

            migrationBuilder.DeleteData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"));

            migrationBuilder.DeleteData(
                table: "TB_SCHEDULING_STATUS",
                keyColumn: "ID",
                keyValue: new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"));

            migrationBuilder.DropColumn(
                name: "COD_STATUS",
                table: "TB_SCHEDULING_STATUS");

            migrationBuilder.AlterColumn<string>(
                name: "TXT_BLOOD_PRESSURE",
                table: "TB_MEDICAL_APPOINTMENT",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TXT_BLOOD_OXYGENATION",
                table: "TB_MEDICAL_APPOINTMENT",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TXT_BEATS_MINUTE",
                table: "TB_MEDICAL_APPOINTMENT",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DBL_WEIGHT",
                table: "TB_MEDICAL_APPOINTMENT",
                type: "decimal(6,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)",
                oldNullable: true);
        }
    }
}
