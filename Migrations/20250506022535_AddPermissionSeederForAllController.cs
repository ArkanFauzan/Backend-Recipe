using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionSeederForAllController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("adb0d599-4f9c-4c55-8d92-526590157bb4"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("beb90ff7-da87-4879-aed6-31d9a5e448d4"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("ca1fd896-d93a-4ea3-aeef-c367ef3d1864"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("fe193127-feba-4007-b760-912245e4018c"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("12bf6fa5-4aa0-4721-866a-f595c2d889ef"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("3dbbfcf0-9b23-47cd-a4dc-c4cc0987291f"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("7768fcd1-cebe-4a0f-8e62-2b8f5ce32e1e"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("fd1c7b7a-7cce-4d65-a27e-5c3b701a3484"));

            migrationBuilder.InsertData(
                table: "PermissionMethods",
                columns: new[] { "Id", "Created", "DeletedAt", "Method", "PermissionId", "Updated" },
                values: new object[,]
                {
                    { new Guid("03d8802c-964f-4746-9e01-00b2c05a2760"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "view", new Guid("56b71bb1-3b72-4086-ac48-e326ddd55ce0"), null },
                    { new Guid("5a66f224-ee08-4d1e-abb7-a401def4e518"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "delete", new Guid("56b71bb1-3b72-4086-ac48-e326ddd55ce0"), null },
                    { new Guid("a4113f70-5a36-4414-91c1-e4e7c56a365e"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "update", new Guid("56b71bb1-3b72-4086-ac48-e326ddd55ce0"), null },
                    { new Guid("f64920a7-a2f1-41db-a2ca-5533ba6f7c77"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "create", new Guid("56b71bb1-3b72-4086-ac48-e326ddd55ce0"), null }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "ControllerName", "Created", "DeletedAt", "Name", "Order", "Updated" },
                values: new object[,]
                {
                    { new Guid("01ce2ff6-31d0-4b70-a3f2-2d37bf897a5b"), "data-type", new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "Data Type Management", 2, null },
                    { new Guid("2341db7d-68c5-4803-bdd9-3ac658adc3cf"), "step", new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "Step Management", 5, null },
                    { new Guid("40b29d47-acff-47f5-9575-58e2fd403342"), "step-parameter-template", new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "Step Parameter Template Management", 3, null },
                    { new Guid("8a000102-7cdd-4793-b489-a19f747fc356"), "step-parameter", new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "Step Parameter Management", 4, null }
                });

            migrationBuilder.InsertData(
                table: "PermissionMethods",
                columns: new[] { "Id", "Created", "DeletedAt", "Method", "PermissionId", "Updated" },
                values: new object[,]
                {
                    { new Guid("24983b14-b063-4190-a9a3-592bd77d3f33"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "delete", new Guid("8a000102-7cdd-4793-b489-a19f747fc356"), null },
                    { new Guid("296589c1-c103-4ac1-8ff0-8b05c9efdc02"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "create", new Guid("2341db7d-68c5-4803-bdd9-3ac658adc3cf"), null },
                    { new Guid("45342144-0ea0-4f90-8f38-79a9fada204d"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "view", new Guid("01ce2ff6-31d0-4b70-a3f2-2d37bf897a5b"), null },
                    { new Guid("46c94db3-8577-4b3b-9d67-82c4c18670ff"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "create", new Guid("40b29d47-acff-47f5-9575-58e2fd403342"), null },
                    { new Guid("61ba3aee-c817-4d6e-8e63-d16f7c016f59"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "delete", new Guid("01ce2ff6-31d0-4b70-a3f2-2d37bf897a5b"), null },
                    { new Guid("63b12386-2e20-447a-b37e-0c64ea78a054"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "view", new Guid("40b29d47-acff-47f5-9575-58e2fd403342"), null },
                    { new Guid("73e05eec-9c99-428c-a2c9-ca92511f0b2e"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "update", new Guid("8a000102-7cdd-4793-b489-a19f747fc356"), null },
                    { new Guid("82590f0b-801c-4e2b-af47-0f2c909956e1"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "update", new Guid("01ce2ff6-31d0-4b70-a3f2-2d37bf897a5b"), null },
                    { new Guid("93d792d4-3bf2-4c25-ac19-14a599a132ba"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "delete", new Guid("2341db7d-68c5-4803-bdd9-3ac658adc3cf"), null },
                    { new Guid("9dd645be-5df5-45f1-b0de-20edd8567b67"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "update", new Guid("40b29d47-acff-47f5-9575-58e2fd403342"), null },
                    { new Guid("ade0a4ac-4ef6-4dec-b879-913d85b50e9a"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "delete", new Guid("40b29d47-acff-47f5-9575-58e2fd403342"), null },
                    { new Guid("b231eb02-403c-4899-b0fb-8cba7c8d8de3"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "view", new Guid("2341db7d-68c5-4803-bdd9-3ac658adc3cf"), null },
                    { new Guid("b7d87f92-f7a9-44b2-87d3-338e7c09aeab"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "create", new Guid("01ce2ff6-31d0-4b70-a3f2-2d37bf897a5b"), null },
                    { new Guid("ba4e2ff1-1782-4492-bda8-836792a3208c"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "update", new Guid("2341db7d-68c5-4803-bdd9-3ac658adc3cf"), null },
                    { new Guid("c8a5f344-cb5c-472a-810a-cd3d7996c6c4"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "view", new Guid("8a000102-7cdd-4793-b489-a19f747fc356"), null },
                    { new Guid("db9b09e3-3cae-4260-832c-3a76315716e6"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, "create", new Guid("8a000102-7cdd-4793-b489-a19f747fc356"), null }
                });

            migrationBuilder.InsertData(
                table: "RolePermissionMethods",
                columns: new[] { "Id", "Created", "DeletedAt", "PermissionMethodId", "RoleId", "Updated" },
                values: new object[,]
                {
                    { new Guid("1afe0146-3bd7-44d1-b27b-08a8254c2f19"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("f64920a7-a2f1-41db-a2ca-5533ba6f7c77"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("1e2cf7b9-e149-4a1c-bace-70e91bc3bcb0"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("5a66f224-ee08-4d1e-abb7-a401def4e518"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("9204ca4e-5b38-44b8-8d8e-3f43607fe047"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("a4113f70-5a36-4414-91c1-e4e7c56a365e"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("f62ca36f-5322-44cb-9772-18bf9661f6e1"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("03d8802c-964f-4746-9e01-00b2c05a2760"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("0e4d6661-ec76-4d44-8756-a29625e87d59"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("45342144-0ea0-4f90-8f38-79a9fada204d"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("124c34ea-8ef7-4947-a480-78fd8024e50c"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("82590f0b-801c-4e2b-af47-0f2c909956e1"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("24d4c214-5a59-45bc-b732-37ab3109359b"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("24983b14-b063-4190-a9a3-592bd77d3f33"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("274fbda2-6f2a-4a1e-92e4-4fd895e6a8cb"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("93d792d4-3bf2-4c25-ac19-14a599a132ba"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("39f98d20-177d-4189-b4c4-aabd44dbaf35"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("46c94db3-8577-4b3b-9d67-82c4c18670ff"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("3b11bfc9-23f3-4a31-9d1b-f771571cb3b2"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("c8a5f344-cb5c-472a-810a-cd3d7996c6c4"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("3d6699b7-e9b1-4dcf-b9d9-fcf5389fb453"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("61ba3aee-c817-4d6e-8e63-d16f7c016f59"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("4034baa4-22b0-41d2-9387-05b694f1a825"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("ade0a4ac-4ef6-4dec-b879-913d85b50e9a"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("5c21bfe3-8f7a-41b4-986f-ac331763f31b"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("296589c1-c103-4ac1-8ff0-8b05c9efdc02"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("62fecdbe-9d4e-422b-9bba-7bac6d39ef1a"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("9dd645be-5df5-45f1-b0de-20edd8567b67"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("7d1883b3-dab3-443f-a53d-97242c23878d"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("db9b09e3-3cae-4260-832c-3a76315716e6"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("8d431802-fa55-4225-946b-9178c6f8096d"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("ba4e2ff1-1782-4492-bda8-836792a3208c"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("ad9acc02-aba5-40e8-9fd0-e11747380463"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("b231eb02-403c-4899-b0fb-8cba7c8d8de3"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("c7d2b7f6-f374-4cf9-bfb7-b7e4c0982368"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("63b12386-2e20-447a-b37e-0c64ea78a054"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("e3fd57ca-beda-4cca-bbe2-2b27a44fcd74"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("b7d87f92-f7a9-44b2-87d3-338e7c09aeab"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null },
                    { new Guid("f0887fed-67f3-4d57-9254-73eaa8375c6f"), new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150), null, new Guid("73e05eec-9c99-428c-a2c9-ca92511f0b2e"), new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("0e4d6661-ec76-4d44-8756-a29625e87d59"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("124c34ea-8ef7-4947-a480-78fd8024e50c"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("1afe0146-3bd7-44d1-b27b-08a8254c2f19"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("1e2cf7b9-e149-4a1c-bace-70e91bc3bcb0"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("24d4c214-5a59-45bc-b732-37ab3109359b"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("274fbda2-6f2a-4a1e-92e4-4fd895e6a8cb"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("39f98d20-177d-4189-b4c4-aabd44dbaf35"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("3b11bfc9-23f3-4a31-9d1b-f771571cb3b2"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("3d6699b7-e9b1-4dcf-b9d9-fcf5389fb453"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("4034baa4-22b0-41d2-9387-05b694f1a825"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("5c21bfe3-8f7a-41b4-986f-ac331763f31b"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("62fecdbe-9d4e-422b-9bba-7bac6d39ef1a"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("7d1883b3-dab3-443f-a53d-97242c23878d"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("8d431802-fa55-4225-946b-9178c6f8096d"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("9204ca4e-5b38-44b8-8d8e-3f43607fe047"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("ad9acc02-aba5-40e8-9fd0-e11747380463"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("c7d2b7f6-f374-4cf9-bfb7-b7e4c0982368"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("e3fd57ca-beda-4cca-bbe2-2b27a44fcd74"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("f0887fed-67f3-4d57-9254-73eaa8375c6f"));

            migrationBuilder.DeleteData(
                table: "RolePermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("f62ca36f-5322-44cb-9772-18bf9661f6e1"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("03d8802c-964f-4746-9e01-00b2c05a2760"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("24983b14-b063-4190-a9a3-592bd77d3f33"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("296589c1-c103-4ac1-8ff0-8b05c9efdc02"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("45342144-0ea0-4f90-8f38-79a9fada204d"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("46c94db3-8577-4b3b-9d67-82c4c18670ff"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("5a66f224-ee08-4d1e-abb7-a401def4e518"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("61ba3aee-c817-4d6e-8e63-d16f7c016f59"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("63b12386-2e20-447a-b37e-0c64ea78a054"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("73e05eec-9c99-428c-a2c9-ca92511f0b2e"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("82590f0b-801c-4e2b-af47-0f2c909956e1"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("93d792d4-3bf2-4c25-ac19-14a599a132ba"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("9dd645be-5df5-45f1-b0de-20edd8567b67"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("a4113f70-5a36-4414-91c1-e4e7c56a365e"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("ade0a4ac-4ef6-4dec-b879-913d85b50e9a"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("b231eb02-403c-4899-b0fb-8cba7c8d8de3"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("b7d87f92-f7a9-44b2-87d3-338e7c09aeab"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("ba4e2ff1-1782-4492-bda8-836792a3208c"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("c8a5f344-cb5c-472a-810a-cd3d7996c6c4"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("db9b09e3-3cae-4260-832c-3a76315716e6"));

            migrationBuilder.DeleteData(
                table: "PermissionMethods",
                keyColumn: "Id",
                keyValue: new Guid("f64920a7-a2f1-41db-a2ca-5533ba6f7c77"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("01ce2ff6-31d0-4b70-a3f2-2d37bf897a5b"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("2341db7d-68c5-4803-bdd9-3ac658adc3cf"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("40b29d47-acff-47f5-9575-58e2fd403342"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("8a000102-7cdd-4793-b489-a19f747fc356"));

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
        }
    }
}
