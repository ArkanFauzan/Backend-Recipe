using Microsoft.EntityFrameworkCore;
using RecipeApi.Entities;

namespace RecipeApi.Seeders;

public static class PermissionMethodSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PermissionMethod>().HasData(
            new PermissionMethod {
                Id = Guid.Parse("03d8802c-964f-4746-9e01-00b2c05a2760"),
                Method = "view",
                PermissionId = Guid.Parse("56b71bb1-3b72-4086-ac48-e326ddd55ce0"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new PermissionMethod {
                Id = Guid.Parse("f64920a7-a2f1-41db-a2ca-5533ba6f7c77"),
                Method = "create",
                PermissionId = Guid.Parse("56b71bb1-3b72-4086-ac48-e326ddd55ce0"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new PermissionMethod {
                Id = Guid.Parse("a4113f70-5a36-4414-91c1-e4e7c56a365e"),
                Method = "update",
                PermissionId = Guid.Parse("56b71bb1-3b72-4086-ac48-e326ddd55ce0"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new PermissionMethod {
                Id = Guid.Parse("5a66f224-ee08-4d1e-abb7-a401def4e518"),
                Method = "delete",
                PermissionId = Guid.Parse("56b71bb1-3b72-4086-ac48-e326ddd55ce0"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new PermissionMethod {
                Id = Guid.Parse("45342144-0ea0-4f90-8f38-79a9fada204d"),
                Method = "view",
                PermissionId = Guid.Parse("01ce2ff6-31d0-4b70-a3f2-2d37bf897a5b"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new PermissionMethod {
                Id = Guid.Parse("b7d87f92-f7a9-44b2-87d3-338e7c09aeab"),
                Method = "create",
                PermissionId = Guid.Parse("01ce2ff6-31d0-4b70-a3f2-2d37bf897a5b"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new PermissionMethod {
                Id = Guid.Parse("82590f0b-801c-4e2b-af47-0f2c909956e1"),
                Method = "update",
                PermissionId = Guid.Parse("01ce2ff6-31d0-4b70-a3f2-2d37bf897a5b"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new PermissionMethod {
                Id = Guid.Parse("61ba3aee-c817-4d6e-8e63-d16f7c016f59"),
                Method = "delete",
                PermissionId = Guid.Parse("01ce2ff6-31d0-4b70-a3f2-2d37bf897a5b"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new PermissionMethod {
                Id = Guid.Parse("63b12386-2e20-447a-b37e-0c64ea78a054"),
                Method = "view",
                PermissionId = Guid.Parse("40b29d47-acff-47f5-9575-58e2fd403342"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new PermissionMethod {
                Id = Guid.Parse("46c94db3-8577-4b3b-9d67-82c4c18670ff"),
                Method = "create",
                PermissionId = Guid.Parse("40b29d47-acff-47f5-9575-58e2fd403342"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new PermissionMethod {
                Id = Guid.Parse("9dd645be-5df5-45f1-b0de-20edd8567b67"),
                Method = "update",
                PermissionId = Guid.Parse("40b29d47-acff-47f5-9575-58e2fd403342"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new PermissionMethod {
                Id = Guid.Parse("ade0a4ac-4ef6-4dec-b879-913d85b50e9a"),
                Method = "delete",
                PermissionId = Guid.Parse("40b29d47-acff-47f5-9575-58e2fd403342"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new PermissionMethod {
                Id = Guid.Parse("c8a5f344-cb5c-472a-810a-cd3d7996c6c4"),
                Method = "view",
                PermissionId = Guid.Parse("8a000102-7cdd-4793-b489-a19f747fc356"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new PermissionMethod {
                Id = Guid.Parse("db9b09e3-3cae-4260-832c-3a76315716e6"),
                Method = "create",
                PermissionId = Guid.Parse("8a000102-7cdd-4793-b489-a19f747fc356"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new PermissionMethod {
                Id = Guid.Parse("73e05eec-9c99-428c-a2c9-ca92511f0b2e"),
                Method = "update",
                PermissionId = Guid.Parse("8a000102-7cdd-4793-b489-a19f747fc356"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new PermissionMethod {
                Id = Guid.Parse("24983b14-b063-4190-a9a3-592bd77d3f33"),
                Method = "delete",
                PermissionId = Guid.Parse("8a000102-7cdd-4793-b489-a19f747fc356"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new PermissionMethod {
                Id = Guid.Parse("b231eb02-403c-4899-b0fb-8cba7c8d8de3"),
                Method = "view",
                PermissionId = Guid.Parse("2341db7d-68c5-4803-bdd9-3ac658adc3cf"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new PermissionMethod {
                Id = Guid.Parse("296589c1-c103-4ac1-8ff0-8b05c9efdc02"),
                Method = "create",
                PermissionId = Guid.Parse("2341db7d-68c5-4803-bdd9-3ac658adc3cf"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new PermissionMethod {
                Id = Guid.Parse("ba4e2ff1-1782-4492-bda8-836792a3208c"),
                Method = "update",
                PermissionId = Guid.Parse("2341db7d-68c5-4803-bdd9-3ac658adc3cf"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new PermissionMethod {
                Id = Guid.Parse("93d792d4-3bf2-4c25-ac19-14a599a132ba"),
                Method = "delete",
                PermissionId = Guid.Parse("2341db7d-68c5-4803-bdd9-3ac658adc3cf"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new PermissionMethod {
                Id = Guid.Parse("2c964ec8-73a7-4df1-a5f2-8719b98d1f66"),
                Method = "view",
                PermissionId = Guid.Parse("8e83d27f-f32a-4ce3-a649-5dbdd0f65492"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new PermissionMethod {
                Id = Guid.Parse("f152c922-aeba-4b0d-8905-a4d9c4933f2f"),
                Method = "create",
                PermissionId = Guid.Parse("8e83d27f-f32a-4ce3-a649-5dbdd0f65492"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new PermissionMethod {
                Id = Guid.Parse("71a8a751-be7f-43e9-898d-7c90c005162b"),
                Method = "update",
                PermissionId = Guid.Parse("8e83d27f-f32a-4ce3-a649-5dbdd0f65492"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            },
            new PermissionMethod {
                Id = Guid.Parse("5c82a2ad-1379-40ae-ba63-1662c0f225aa"),
                Method = "delete",
                PermissionId = Guid.Parse("8e83d27f-f32a-4ce3-a649-5dbdd0f65492"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            }
        );
    }
}