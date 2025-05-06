using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeApi.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountAndPermissionWithInitialSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(64)", nullable: false),
                    ControllerName = table.Column<string>(type: "varchar(64)", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleName = table.Column<string>(type: "varchar(64)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Method = table.Column<string>(type: "text", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionMethods_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "varchar(150)", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", nullable: true),
                    Password = table.Column<string>(type: "varchar(150)", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissionMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionMethodId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissionMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissionMethods_PermissionMethods_PermissionMethodId",
                        column: x => x.PermissionMethodId,
                        principalTable: "PermissionMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissionMethods_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "ControllerName", "Created", "DeletedAt", "Name", "Order", "Updated" },
                values: new object[] { new Guid("56b71bb1-3b72-4086-ac48-e326ddd55ce0"), "recipe", new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "Recipe Management", 1, null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Created", "DeletedAt", "Description", "RoleName", "Updated" },
                values: new object[,]
                {
                    { new Guid("21b67a56-7c4a-4b13-b14a-1eb9c643d09c"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "Admin access", "Admin", null },
                    { new Guid("b4bd8623-5fb5-42d7-8b6f-6ff58813a3b0"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "Regular user", "User", null },
                    { new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "Super admin access", "Super Admin", null }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Created", "DeletedAt", "Email", "FullName", "Password", "RoleId", "Updated", "Username" },
                values: new object[] { new Guid("687efa72-305a-4fd6-a5df-2fc838ffa837"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "super@admin.com", "Super Admin", "$2a$12$A2HSfL89FCvuX6uHixiVBuGrl2eKDvPwjDFxbX2yr12.0JDVVZoqi", new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null, "superadmin" });

            migrationBuilder.InsertData(
                table: "PermissionMethods",
                columns: new[] { "Id", "Created", "DeletedAt", "Method", "PermissionId", "Updated" },
                values: new object[,]
                {
                    { new Guid("12bf6fa5-4aa0-4721-866a-f595c2d889ef"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "view", new Guid("56b71bb1-3b72-4086-ac48-e326ddd55ce0"), null },
                    { new Guid("3dbbfcf0-9b23-47cd-a4dc-c4cc0987291f"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "update", new Guid("56b71bb1-3b72-4086-ac48-e326ddd55ce0"), null },
                    { new Guid("7768fcd1-cebe-4a0f-8e62-2b8f5ce32e1e"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "delete", new Guid("56b71bb1-3b72-4086-ac48-e326ddd55ce0"), null },
                    { new Guid("fd1c7b7a-7cce-4d65-a27e-5c3b701a3484"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "create", new Guid("56b71bb1-3b72-4086-ac48-e326ddd55ce0"), null }
                });

            migrationBuilder.InsertData(
                table: "RolePermissionMethods",
                columns: new[] { "Id", "Created", "DeletedAt", "PermissionMethodId", "RoleId", "Updated" },
                values: new object[,]
                {
                    { new Guid("adb0d599-4f9c-4c55-8d92-526590157bb4"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("7768fcd1-cebe-4a0f-8e62-2b8f5ce32e1e"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("beb90ff7-da87-4879-aed6-31d9a5e448d4"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("fd1c7b7a-7cce-4d65-a27e-5c3b701a3484"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("ca1fd896-d93a-4ea3-aeef-c367ef3d1864"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("3dbbfcf0-9b23-47cd-a4dc-c4cc0987291f"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("fe193127-feba-4007-b760-912245e4018c"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("12bf6fa5-4aa0-4721-866a-f595c2d889ef"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleId",
                table: "Accounts",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionMethods_PermissionId",
                table: "PermissionMethods",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionMethods_PermissionMethodId",
                table: "RolePermissionMethods",
                column: "PermissionMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionMethods_RoleId",
                table: "RolePermissionMethods",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "RolePermissionMethods");

            migrationBuilder.DropTable(
                name: "PermissionMethods");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Permissions");
        }
    }
}
