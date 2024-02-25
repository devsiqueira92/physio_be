using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Physio.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class restartingmigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginType = table.Column<int>(type: "int", nullable: false),
                    IsRegistred = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PATIENT",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TXT_CONTACT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FLG_IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    DAT_UPDATED_ON = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COD_UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DAT_CREATED_ON = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COD_CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TXT_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DAT_BIRTH_DATE = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PATIENT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_PROTOCOL",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TXT_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TXT_MEMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TXT_DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FLG_IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    DAT_UPDATED_ON = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COD_UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DAT_CREATED_ON = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COD_CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PROTOCOL", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_SCHEDULING_STATUS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TXT_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COD_STATUS = table.Column<int>(type: "int", maxLength: 36, nullable: true),
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_CLINIC",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TXT_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TXT_ADDRESS = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    TXT_CONTACT = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    TXT_IDENTIFICATION_NUMBER = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    COD_USER = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FLG_IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    DAT_UPDATED_ON = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COD_UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DAT_CREATED_ON = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COD_CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLINIC", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_CLINIC_AspNetUsers_COD_USER",
                        column: x => x.COD_USER,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TB_PROFESSIONAL",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_REGISTER_NUMBER = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DEC_APPOINTMENT_VALUE = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    TXT_CONTACT = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    COD_USER = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_TB_PROFESSIONAL_AspNetUsers_COD_USER",
                        column: x => x.COD_USER,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TB_CLINIC_PATIENT",
                columns: table => new
                {
                    COD_PATIENT = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    COD_CLINIC = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FLG_IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    DAT_UPDATED_ON = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COD_UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DAT_CREATED_ON = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COD_CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLINIC_PATIENT", x => new { x.COD_PATIENT, x.COD_CLINIC });
                    table.ForeignKey(
                        name: "FK_TB_CLINIC_PATIENT_TB_CLINIC_COD_CLINIC",
                        column: x => x.COD_CLINIC,
                        principalTable: "TB_CLINIC",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CLINIC_PATIENT_TB_PATIENT_COD_PATIENT",
                        column: x => x.COD_PATIENT,
                        principalTable: "TB_PATIENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ADDRESS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TXT_STREET = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    TXT_NUMBER = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TXT_CITY = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    TXT_POSTAL_CODE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    COD_PATIENT = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: true),
                    COD_CLINIC = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: true),
                    COD_PROFESSIONAL = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: true),
                    FLG_IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    DAT_UPDATED_ON = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COD_UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DAT_CREATED_ON = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COD_CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ADDRESS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_ADDRESS_TB_CLINIC_COD_CLINIC",
                        column: x => x.COD_CLINIC,
                        principalTable: "TB_CLINIC",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_ADDRESS_TB_PATIENT_COD_PATIENT",
                        column: x => x.COD_PATIENT,
                        principalTable: "TB_PATIENT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_ADDRESS_TB_PROFESSIONAL_COD_PROFESSIONAL",
                        column: x => x.COD_PROFESSIONAL,
                        principalTable: "TB_PROFESSIONAL",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TB_CLINIC_PROFESSIONAL",
                columns: table => new
                {
                    COD_PROFESSIONAL = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    COD_CLINIC = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FLG_IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    DAT_UPDATED_ON = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COD_UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DAT_CREATED_ON = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COD_CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLINIC_PROFESSIONAL", x => new { x.COD_PROFESSIONAL, x.COD_CLINIC });
                    table.ForeignKey(
                        name: "FK_TB_CLINIC_PROFESSIONAL_TB_CLINIC_COD_CLINIC",
                        column: x => x.COD_CLINIC,
                        principalTable: "TB_CLINIC",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CLINIC_PROFESSIONAL_TB_PROFESSIONAL_COD_PROFESSIONAL",
                        column: x => x.COD_PROFESSIONAL,
                        principalTable: "TB_PROFESSIONAL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_CONTACT",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TXT_CONTACT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TXT_TYPE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    COD_PATIENT = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: true),
                    COD_CLINIC = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: true),
                    COD_PROFESSIONAL = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: true),
                    FLG_IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    DAT_UPDATED_ON = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COD_UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DAT_CREATED_ON = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COD_CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CONTACT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_CONTACT_TB_CLINIC_COD_CLINIC",
                        column: x => x.COD_CLINIC,
                        principalTable: "TB_CLINIC",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_CONTACT_TB_PATIENT_COD_PATIENT",
                        column: x => x.COD_PATIENT,
                        principalTable: "TB_PATIENT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_CONTACT_TB_PROFESSIONAL_COD_PROFESSIONAL",
                        column: x => x.COD_PROFESSIONAL,
                        principalTable: "TB_PROFESSIONAL",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TB_SCHEDULING",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DAT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COD_PATIENT = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    COD_PROFESSIONAL = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    COD_SCHEDULING_STATUS = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    COD_CLINIC = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: true),
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
                        name: "FK_TB_SCHEDULING_TB_CLINIC_COD_CLINIC",
                        column: x => x.COD_CLINIC,
                        principalTable: "TB_CLINIC",
                        principalColumn: "ID");
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

            migrationBuilder.CreateTable(
                name: "TB_MEDICAL_APPOINTMENT",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TXT_BEATS_MINUTE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    TXT_BLOOD_PRESSURE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TXT_BLOOD_OXYGENATION = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TXT_EVOLUTION = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    TXT_NOTES = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    DBL_WEIGHT = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    COD_SCHEDULING = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f75bc70-66e9-4360-a5f5-60cd4d60dbee", null, "RoleEntity", "Patient", "PATIENT" },
                    { "645eb3bb-ab2a-4542-a3e1-8bd8ef945bda", null, "RoleEntity", "Professional", "PROFESSIONAL" },
                    { "ca29a123-1a4b-4d75-84eb-6f39dd886f70", null, "RoleEntity", "Clinic", "CLINIC" }
                });

            migrationBuilder.InsertData(
                table: "TB_SCHEDULING_STATUS",
                columns: new[] { "ID", "COD_CREATED_BY", "DAT_CREATED_ON", "FLG_IS_DELETED", "TXT_NAME", "COD_STATUS", "COD_UPDATED_BY", "DAT_UPDATED_ON" },
                values: new object[,]
                {
                    { new Guid("016f13e5-e543-49f4-891d-ac2567ebf190"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 2, 25, 1, 9, 49, 754, DateTimeKind.Utc).AddTicks(942), false, "Cancelado", 1, null, null },
                    { new Guid("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 2, 25, 1, 9, 49, 754, DateTimeKind.Utc).AddTicks(948), false, "Remarcado", 3, null, null },
                    { new Guid("d3c26666-1e31-460e-ba5f-4310735358c9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 2, 25, 1, 9, 49, 754, DateTimeKind.Utc).AddTicks(946), false, "Finalizado", 2, null, null },
                    { new Guid("e0c50144-28e6-480a-b414-7ccb8c77aafe"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 2, 25, 1, 9, 49, 754, DateTimeKind.Utc).AddTicks(950), false, "Agendado", 4, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ADDRESS_COD_CLINIC",
                table: "TB_ADDRESS",
                column: "COD_CLINIC");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ADDRESS_COD_PATIENT",
                table: "TB_ADDRESS",
                column: "COD_PATIENT");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ADDRESS_COD_PROFESSIONAL",
                table: "TB_ADDRESS",
                column: "COD_PROFESSIONAL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLINIC_COD_USER",
                table: "TB_CLINIC",
                column: "COD_USER",
                unique: true,
                filter: "[COD_USER] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLINIC_TXT_IDENTIFICATION_NUMBER",
                table: "TB_CLINIC",
                column: "TXT_IDENTIFICATION_NUMBER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLINIC_PATIENT_COD_CLINIC",
                table: "TB_CLINIC_PATIENT",
                column: "COD_CLINIC");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLINIC_PROFESSIONAL_COD_CLINIC",
                table: "TB_CLINIC_PROFESSIONAL",
                column: "COD_CLINIC");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CONTACT_COD_CLINIC",
                table: "TB_CONTACT",
                column: "COD_CLINIC");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CONTACT_COD_PATIENT",
                table: "TB_CONTACT",
                column: "COD_PATIENT");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CONTACT_COD_PROFESSIONAL",
                table: "TB_CONTACT",
                column: "COD_PROFESSIONAL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MEDICAL_APPOINTMENT_COD_SCHEDULING",
                table: "TB_MEDICAL_APPOINTMENT",
                column: "COD_SCHEDULING");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PROFESSIONAL_COD_REGISTER_NUMBER",
                table: "TB_PROFESSIONAL",
                column: "COD_REGISTER_NUMBER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_PROFESSIONAL_COD_USER",
                table: "TB_PROFESSIONAL",
                column: "COD_USER",
                unique: true,
                filter: "[COD_USER] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_SCHEDULING_COD_CLINIC",
                table: "TB_SCHEDULING",
                column: "COD_CLINIC");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TB_ADDRESS");

            migrationBuilder.DropTable(
                name: "TB_CLINIC_PATIENT");

            migrationBuilder.DropTable(
                name: "TB_CLINIC_PROFESSIONAL");

            migrationBuilder.DropTable(
                name: "TB_CONTACT");

            migrationBuilder.DropTable(
                name: "TB_MEDICAL_APPOINTMENT");

            migrationBuilder.DropTable(
                name: "TB_PROTOCOL");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TB_SCHEDULING");

            migrationBuilder.DropTable(
                name: "TB_CLINIC");

            migrationBuilder.DropTable(
                name: "TB_PATIENT");

            migrationBuilder.DropTable(
                name: "TB_PROFESSIONAL");

            migrationBuilder.DropTable(
                name: "TB_SCHEDULING_STATUS");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
