﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RecipeApi.Data;

#nullable disable

namespace RecipeApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250506022535_AddPermissionSeederForAllController")]
    partial class AddPermissionSeederForAllController
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RecipeApi.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("687efa72-305a-4fd6-a5df-2fc838ffa837"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Email = "super@admin.com",
                            FullName = "Super Admin",
                            Password = "$2a$12$A2HSfL89FCvuX6uHixiVBuGrl2eKDvPwjDFxbX2yr12.0JDVVZoqi",
                            RoleId = new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                            Username = "superadmin"
                        });
                });

            modelBuilder.Entity("RecipeApi.Entities.DataType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CustomRegex")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ParseType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("DataTypes");
                });

            modelBuilder.Entity("RecipeApi.Entities.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ControllerName")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("56b71bb1-3b72-4086-ac48-e326ddd55ce0"),
                            ControllerName = "recipe",
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Name = "Recipe Management",
                            Order = 1
                        },
                        new
                        {
                            Id = new Guid("01ce2ff6-31d0-4b70-a3f2-2d37bf897a5b"),
                            ControllerName = "data-type",
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Name = "Data Type Management",
                            Order = 2
                        },
                        new
                        {
                            Id = new Guid("40b29d47-acff-47f5-9575-58e2fd403342"),
                            ControllerName = "step-parameter-template",
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Name = "Step Parameter Template Management",
                            Order = 3
                        },
                        new
                        {
                            Id = new Guid("8a000102-7cdd-4793-b489-a19f747fc356"),
                            ControllerName = "step-parameter",
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Name = "Step Parameter Management",
                            Order = 4
                        },
                        new
                        {
                            Id = new Guid("2341db7d-68c5-4803-bdd9-3ac658adc3cf"),
                            ControllerName = "step",
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Name = "Step Management",
                            Order = 5
                        });
                });

            modelBuilder.Entity("RecipeApi.Entities.PermissionMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.ToTable("PermissionMethods");

                    b.HasData(
                        new
                        {
                            Id = new Guid("03d8802c-964f-4746-9e01-00b2c05a2760"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Method = "view",
                            PermissionId = new Guid("56b71bb1-3b72-4086-ac48-e326ddd55ce0")
                        },
                        new
                        {
                            Id = new Guid("f64920a7-a2f1-41db-a2ca-5533ba6f7c77"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Method = "create",
                            PermissionId = new Guid("56b71bb1-3b72-4086-ac48-e326ddd55ce0")
                        },
                        new
                        {
                            Id = new Guid("a4113f70-5a36-4414-91c1-e4e7c56a365e"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Method = "update",
                            PermissionId = new Guid("56b71bb1-3b72-4086-ac48-e326ddd55ce0")
                        },
                        new
                        {
                            Id = new Guid("5a66f224-ee08-4d1e-abb7-a401def4e518"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Method = "delete",
                            PermissionId = new Guid("56b71bb1-3b72-4086-ac48-e326ddd55ce0")
                        },
                        new
                        {
                            Id = new Guid("45342144-0ea0-4f90-8f38-79a9fada204d"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Method = "view",
                            PermissionId = new Guid("01ce2ff6-31d0-4b70-a3f2-2d37bf897a5b")
                        },
                        new
                        {
                            Id = new Guid("b7d87f92-f7a9-44b2-87d3-338e7c09aeab"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Method = "create",
                            PermissionId = new Guid("01ce2ff6-31d0-4b70-a3f2-2d37bf897a5b")
                        },
                        new
                        {
                            Id = new Guid("82590f0b-801c-4e2b-af47-0f2c909956e1"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Method = "update",
                            PermissionId = new Guid("01ce2ff6-31d0-4b70-a3f2-2d37bf897a5b")
                        },
                        new
                        {
                            Id = new Guid("61ba3aee-c817-4d6e-8e63-d16f7c016f59"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Method = "delete",
                            PermissionId = new Guid("01ce2ff6-31d0-4b70-a3f2-2d37bf897a5b")
                        },
                        new
                        {
                            Id = new Guid("63b12386-2e20-447a-b37e-0c64ea78a054"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Method = "view",
                            PermissionId = new Guid("40b29d47-acff-47f5-9575-58e2fd403342")
                        },
                        new
                        {
                            Id = new Guid("46c94db3-8577-4b3b-9d67-82c4c18670ff"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Method = "create",
                            PermissionId = new Guid("40b29d47-acff-47f5-9575-58e2fd403342")
                        },
                        new
                        {
                            Id = new Guid("9dd645be-5df5-45f1-b0de-20edd8567b67"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Method = "update",
                            PermissionId = new Guid("40b29d47-acff-47f5-9575-58e2fd403342")
                        },
                        new
                        {
                            Id = new Guid("ade0a4ac-4ef6-4dec-b879-913d85b50e9a"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Method = "delete",
                            PermissionId = new Guid("40b29d47-acff-47f5-9575-58e2fd403342")
                        },
                        new
                        {
                            Id = new Guid("c8a5f344-cb5c-472a-810a-cd3d7996c6c4"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Method = "view",
                            PermissionId = new Guid("8a000102-7cdd-4793-b489-a19f747fc356")
                        },
                        new
                        {
                            Id = new Guid("db9b09e3-3cae-4260-832c-3a76315716e6"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Method = "create",
                            PermissionId = new Guid("8a000102-7cdd-4793-b489-a19f747fc356")
                        },
                        new
                        {
                            Id = new Guid("73e05eec-9c99-428c-a2c9-ca92511f0b2e"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Method = "update",
                            PermissionId = new Guid("8a000102-7cdd-4793-b489-a19f747fc356")
                        },
                        new
                        {
                            Id = new Guid("24983b14-b063-4190-a9a3-592bd77d3f33"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Method = "delete",
                            PermissionId = new Guid("8a000102-7cdd-4793-b489-a19f747fc356")
                        },
                        new
                        {
                            Id = new Guid("b231eb02-403c-4899-b0fb-8cba7c8d8de3"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Method = "view",
                            PermissionId = new Guid("2341db7d-68c5-4803-bdd9-3ac658adc3cf")
                        },
                        new
                        {
                            Id = new Guid("296589c1-c103-4ac1-8ff0-8b05c9efdc02"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Method = "create",
                            PermissionId = new Guid("2341db7d-68c5-4803-bdd9-3ac658adc3cf")
                        },
                        new
                        {
                            Id = new Guid("ba4e2ff1-1782-4492-bda8-836792a3208c"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Method = "update",
                            PermissionId = new Guid("2341db7d-68c5-4803-bdd9-3ac658adc3cf")
                        },
                        new
                        {
                            Id = new Guid("93d792d4-3bf2-4c25-ac19-14a599a132ba"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Method = "delete",
                            PermissionId = new Guid("2341db7d-68c5-4803-bdd9-3ac658adc3cf")
                        });
                });

            modelBuilder.Entity("RecipeApi.Entities.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("RecipeApi.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Description = "Super admin access",
                            RoleName = "Super Admin"
                        },
                        new
                        {
                            Id = new Guid("21b67a56-7c4a-4b13-b14a-1eb9c643d09c"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Description = "Admin access",
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = new Guid("b4bd8623-5fb5-42d7-8b6f-6ff58813a3b0"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            Description = "Regular user",
                            RoleName = "User"
                        });
                });

            modelBuilder.Entity("RecipeApi.Entities.RolePermissionMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PermissionMethodId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("PermissionMethodId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissionMethods");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f62ca36f-5322-44cb-9772-18bf9661f6e1"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            PermissionMethodId = new Guid("03d8802c-964f-4746-9e01-00b2c05a2760"),
                            RoleId = new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8")
                        },
                        new
                        {
                            Id = new Guid("1afe0146-3bd7-44d1-b27b-08a8254c2f19"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            PermissionMethodId = new Guid("f64920a7-a2f1-41db-a2ca-5533ba6f7c77"),
                            RoleId = new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8")
                        },
                        new
                        {
                            Id = new Guid("9204ca4e-5b38-44b8-8d8e-3f43607fe047"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            PermissionMethodId = new Guid("a4113f70-5a36-4414-91c1-e4e7c56a365e"),
                            RoleId = new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8")
                        },
                        new
                        {
                            Id = new Guid("1e2cf7b9-e149-4a1c-bace-70e91bc3bcb0"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            PermissionMethodId = new Guid("5a66f224-ee08-4d1e-abb7-a401def4e518"),
                            RoleId = new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8")
                        },
                        new
                        {
                            Id = new Guid("0e4d6661-ec76-4d44-8756-a29625e87d59"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            PermissionMethodId = new Guid("45342144-0ea0-4f90-8f38-79a9fada204d"),
                            RoleId = new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8")
                        },
                        new
                        {
                            Id = new Guid("e3fd57ca-beda-4cca-bbe2-2b27a44fcd74"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            PermissionMethodId = new Guid("b7d87f92-f7a9-44b2-87d3-338e7c09aeab"),
                            RoleId = new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8")
                        },
                        new
                        {
                            Id = new Guid("124c34ea-8ef7-4947-a480-78fd8024e50c"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            PermissionMethodId = new Guid("82590f0b-801c-4e2b-af47-0f2c909956e1"),
                            RoleId = new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8")
                        },
                        new
                        {
                            Id = new Guid("3d6699b7-e9b1-4dcf-b9d9-fcf5389fb453"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            PermissionMethodId = new Guid("61ba3aee-c817-4d6e-8e63-d16f7c016f59"),
                            RoleId = new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8")
                        },
                        new
                        {
                            Id = new Guid("c7d2b7f6-f374-4cf9-bfb7-b7e4c0982368"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            PermissionMethodId = new Guid("63b12386-2e20-447a-b37e-0c64ea78a054"),
                            RoleId = new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8")
                        },
                        new
                        {
                            Id = new Guid("39f98d20-177d-4189-b4c4-aabd44dbaf35"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            PermissionMethodId = new Guid("46c94db3-8577-4b3b-9d67-82c4c18670ff"),
                            RoleId = new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8")
                        },
                        new
                        {
                            Id = new Guid("62fecdbe-9d4e-422b-9bba-7bac6d39ef1a"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            PermissionMethodId = new Guid("9dd645be-5df5-45f1-b0de-20edd8567b67"),
                            RoleId = new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8")
                        },
                        new
                        {
                            Id = new Guid("4034baa4-22b0-41d2-9387-05b694f1a825"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            PermissionMethodId = new Guid("ade0a4ac-4ef6-4dec-b879-913d85b50e9a"),
                            RoleId = new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8")
                        },
                        new
                        {
                            Id = new Guid("3b11bfc9-23f3-4a31-9d1b-f771571cb3b2"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            PermissionMethodId = new Guid("c8a5f344-cb5c-472a-810a-cd3d7996c6c4"),
                            RoleId = new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8")
                        },
                        new
                        {
                            Id = new Guid("7d1883b3-dab3-443f-a53d-97242c23878d"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            PermissionMethodId = new Guid("db9b09e3-3cae-4260-832c-3a76315716e6"),
                            RoleId = new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8")
                        },
                        new
                        {
                            Id = new Guid("f0887fed-67f3-4d57-9254-73eaa8375c6f"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            PermissionMethodId = new Guid("73e05eec-9c99-428c-a2c9-ca92511f0b2e"),
                            RoleId = new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8")
                        },
                        new
                        {
                            Id = new Guid("24d4c214-5a59-45bc-b732-37ab3109359b"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            PermissionMethodId = new Guid("24983b14-b063-4190-a9a3-592bd77d3f33"),
                            RoleId = new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8")
                        },
                        new
                        {
                            Id = new Guid("ad9acc02-aba5-40e8-9fd0-e11747380463"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            PermissionMethodId = new Guid("b231eb02-403c-4899-b0fb-8cba7c8d8de3"),
                            RoleId = new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8")
                        },
                        new
                        {
                            Id = new Guid("5c21bfe3-8f7a-41b4-986f-ac331763f31b"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            PermissionMethodId = new Guid("296589c1-c103-4ac1-8ff0-8b05c9efdc02"),
                            RoleId = new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8")
                        },
                        new
                        {
                            Id = new Guid("8d431802-fa55-4225-946b-9178c6f8096d"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            PermissionMethodId = new Guid("ba4e2ff1-1782-4492-bda8-836792a3208c"),
                            RoleId = new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8")
                        },
                        new
                        {
                            Id = new Guid("274fbda2-6f2a-4a1e-92e4-4fd895e6a8cb"),
                            Created = new DateTime(2025, 5, 5, 18, 13, 46, 418, DateTimeKind.Utc).AddTicks(6150),
                            PermissionMethodId = new Guid("93d792d4-3bf2-4c25-ac19-14a599a132ba"),
                            RoleId = new Guid("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8")
                        });
                });

            modelBuilder.Entity("RecipeApi.Entities.Step", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Depth")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("RecipeApi.Entities.StepParameter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<Guid>("StepId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StepParameterTemplateId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("StepId");

                    b.HasIndex("StepParameterTemplateId");

                    b.ToTable("StepParameters");
                });

            modelBuilder.Entity("RecipeApi.Entities.StepParameterTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DataTypeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DataTypeId");

                    b.ToTable("StepParameterTemplates");
                });

            modelBuilder.Entity("RecipeApi.Entities.Account", b =>
                {
                    b.HasOne("RecipeApi.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("RecipeApi.Entities.PermissionMethod", b =>
                {
                    b.HasOne("RecipeApi.Entities.Permission", "Permission")
                        .WithMany("PermissionMethods")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("RecipeApi.Entities.RolePermissionMethod", b =>
                {
                    b.HasOne("RecipeApi.Entities.PermissionMethod", "PermissionMethod")
                        .WithMany()
                        .HasForeignKey("PermissionMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecipeApi.Entities.Role", "Role")
                        .WithMany("RolePermissionMethods")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PermissionMethod");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("RecipeApi.Entities.Step", b =>
                {
                    b.HasOne("RecipeApi.Entities.Step", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("RecipeApi.Entities.Recipe", "Recipe")
                        .WithMany("Steps")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("RecipeApi.Entities.StepParameter", b =>
                {
                    b.HasOne("RecipeApi.Entities.Step", "Step")
                        .WithMany("StepParameters")
                        .HasForeignKey("StepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecipeApi.Entities.StepParameterTemplate", "StepParameterTemplate")
                        .WithMany()
                        .HasForeignKey("StepParameterTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Step");

                    b.Navigation("StepParameterTemplate");
                });

            modelBuilder.Entity("RecipeApi.Entities.StepParameterTemplate", b =>
                {
                    b.HasOne("RecipeApi.Entities.DataType", "DataType")
                        .WithMany()
                        .HasForeignKey("DataTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataType");
                });

            modelBuilder.Entity("RecipeApi.Entities.Permission", b =>
                {
                    b.Navigation("PermissionMethods");
                });

            modelBuilder.Entity("RecipeApi.Entities.Recipe", b =>
                {
                    b.Navigation("Steps");
                });

            modelBuilder.Entity("RecipeApi.Entities.Role", b =>
                {
                    b.Navigation("RolePermissionMethods");
                });

            modelBuilder.Entity("RecipeApi.Entities.Step", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("StepParameters");
                });
#pragma warning restore 612, 618
        }
    }
}
