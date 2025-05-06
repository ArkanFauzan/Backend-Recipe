using Microsoft.EntityFrameworkCore;
using RecipeApi.Entities;

namespace RecipeApi.Seeders;

public static class RolePermissionMethodSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RolePermissionMethod>().HasData(
            new RolePermissionMethod {
                Id = Guid.Parse("f62ca36f-5322-44cb-9772-18bf9661f6e1"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("03d8802c-964f-4746-9e01-00b2c05a2760"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new RolePermissionMethod {
                Id = Guid.Parse("1afe0146-3bd7-44d1-b27b-08a8254c2f19"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("f64920a7-a2f1-41db-a2ca-5533ba6f7c77"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new RolePermissionMethod {
                Id = Guid.Parse("9204ca4e-5b38-44b8-8d8e-3f43607fe047"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("a4113f70-5a36-4414-91c1-e4e7c56a365e"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new RolePermissionMethod {
                Id = Guid.Parse("1e2cf7b9-e149-4a1c-bace-70e91bc3bcb0"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("5a66f224-ee08-4d1e-abb7-a401def4e518"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new RolePermissionMethod {
                Id = Guid.Parse("0e4d6661-ec76-4d44-8756-a29625e87d59"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("45342144-0ea0-4f90-8f38-79a9fada204d"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new RolePermissionMethod {
                Id = Guid.Parse("e3fd57ca-beda-4cca-bbe2-2b27a44fcd74"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("b7d87f92-f7a9-44b2-87d3-338e7c09aeab"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new RolePermissionMethod {
                Id = Guid.Parse("124c34ea-8ef7-4947-a480-78fd8024e50c"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("82590f0b-801c-4e2b-af47-0f2c909956e1"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new RolePermissionMethod {
                Id = Guid.Parse("3d6699b7-e9b1-4dcf-b9d9-fcf5389fb453"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("61ba3aee-c817-4d6e-8e63-d16f7c016f59"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new RolePermissionMethod {
                Id = Guid.Parse("c7d2b7f6-f374-4cf9-bfb7-b7e4c0982368"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("63b12386-2e20-447a-b37e-0c64ea78a054"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new RolePermissionMethod {
                Id = Guid.Parse("39f98d20-177d-4189-b4c4-aabd44dbaf35"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("46c94db3-8577-4b3b-9d67-82c4c18670ff"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new RolePermissionMethod {
                Id = Guid.Parse("62fecdbe-9d4e-422b-9bba-7bac6d39ef1a"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("9dd645be-5df5-45f1-b0de-20edd8567b67"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new RolePermissionMethod {
                Id = Guid.Parse("4034baa4-22b0-41d2-9387-05b694f1a825"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("ade0a4ac-4ef6-4dec-b879-913d85b50e9a"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new RolePermissionMethod {
                Id = Guid.Parse("3b11bfc9-23f3-4a31-9d1b-f771571cb3b2"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("c8a5f344-cb5c-472a-810a-cd3d7996c6c4"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new RolePermissionMethod {
                Id = Guid.Parse("7d1883b3-dab3-443f-a53d-97242c23878d"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("db9b09e3-3cae-4260-832c-3a76315716e6"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new RolePermissionMethod {
                Id = Guid.Parse("f0887fed-67f3-4d57-9254-73eaa8375c6f"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("73e05eec-9c99-428c-a2c9-ca92511f0b2e"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new RolePermissionMethod {
                Id = Guid.Parse("24d4c214-5a59-45bc-b732-37ab3109359b"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("24983b14-b063-4190-a9a3-592bd77d3f33"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new RolePermissionMethod {
                Id = Guid.Parse("ad9acc02-aba5-40e8-9fd0-e11747380463"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("b231eb02-403c-4899-b0fb-8cba7c8d8de3"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new RolePermissionMethod {
                Id = Guid.Parse("5c21bfe3-8f7a-41b4-986f-ac331763f31b"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("296589c1-c103-4ac1-8ff0-8b05c9efdc02"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new RolePermissionMethod {
                Id = Guid.Parse("8d431802-fa55-4225-946b-9178c6f8096d"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("ba4e2ff1-1782-4492-bda8-836792a3208c"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new RolePermissionMethod {
                Id = Guid.Parse("274fbda2-6f2a-4a1e-92e4-4fd895e6a8cb"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("93d792d4-3bf2-4c25-ac19-14a599a132ba"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new RolePermissionMethod {
                Id = Guid.Parse("dab5ac1e-d4f8-4e84-a574-7f46617dc2c6"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("2c964ec8-73a7-4df1-a5f2-8719b98d1f66"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new RolePermissionMethod {
                Id = Guid.Parse("be014f21-20cb-4e58-a8ed-b26e558065a1"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("f152c922-aeba-4b0d-8905-a4d9c4933f2f"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new RolePermissionMethod {
                Id = Guid.Parse("64e49d9d-c288-4fb3-aa7d-7aad3f9869e7"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("71a8a751-be7f-43e9-898d-7c90c005162b"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new RolePermissionMethod {
                Id = Guid.Parse("453f0a3a-cc2a-4d6c-9919-621bfdd3e16f"),
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                PermissionMethodId = Guid.Parse("5c82a2ad-1379-40ae-ba63-1662c0f225aa"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            }
        );
    }
}