using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeApi.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountCRUDPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "ControllerName", "Created", "DeletedAt", "Name", "Order", "Updated" },
                values: new object[] { new Guid("8e83d27f-f32a-4ce3-a649-5dbdd0f65492"), "account", new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "Account Management", 6, null });

            migrationBuilder.InsertData(
                table: "PermissionMethods",
                columns: new[] { "Id", "Created", "DeletedAt", "Method", "PermissionId", "Updated" },
                values: new object[,]
                {
                    { new Guid("2c964ec8-73a7-4df1-a5f2-8719b98d1f66"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "view", new Guid("8e83d27f-f32a-4ce3-a649-5dbdd0f65492"), null },
                    { new Guid("5c82a2ad-1379-40ae-ba63-1662c0f225aa"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "delete", new Guid("8e83d27f-f32a-4ce3-a649-5dbdd0f65492"), null },
                    { new Guid("71a8a751-be7f-43e9-898d-7c90c005162b"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "update", new Guid("8e83d27f-f32a-4ce3-a649-5dbdd0f65492"), null },
                    { new Guid("f152c922-aeba-4b0d-8905-a4d9c4933f2f"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "create", new Guid("8e83d27f-f32a-4ce3-a649-5dbdd0f65492"), null }
                });

            migrationBuilder.InsertData(
                table: "RolePermissionMethods",
                columns: new[] { "Id", "Created", "DeletedAt", "PermissionMethodId", "RoleId", "Updated" },
                values: new object[,]
                {
                    { new Guid("453f0a3a-cc2a-4d6c-9919-621bfdd3e16f"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("5c82a2ad-1379-40ae-ba63-1662c0f225aa"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("64e49d9d-c288-4fb3-aa7d-7aad3f9869e7"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("71a8a751-be7f-43e9-898d-7c90c005162b"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("be014f21-20cb-4e58-a8ed-b26e558065a1"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("f152c922-aeba-4b0d-8905-a4d9c4933f2f"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("dab5ac1e-d4f8-4e84-a574-7f46617dc2c6"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("2c964ec8-73a7-4df1-a5f2-8719b98d1f66"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Username",
                table: "Accounts",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Accounts_Username",
                table: "Accounts");

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("453f0a3a-cc2a-4d6c-9919-621bfdd3e16f"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("64e49d9d-c288-4fb3-aa7d-7aad3f9869e7"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("be014f21-20cb-4e58-a8ed-b26e558065a1"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("dab5ac1e-d4f8-4e84-a574-7f46617dc2c6"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("2c964ec8-73a7-4df1-a5f2-8719b98d1f66"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("5c82a2ad-1379-40ae-ba63-1662c0f225aa"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("71a8a751-be7f-43e9-898d-7c90c005162b"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("f152c922-aeba-4b0d-8905-a4d9c4933f2f"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("8e83d27f-f32a-4ce3-a649-5dbdd0f65492"));
        }
    }
}
