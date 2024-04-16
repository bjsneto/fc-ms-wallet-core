﻿// <auto-generated />
using System;
using Balance.App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Balance.App.Migrations
{
    [DbContext(typeof(BalanceDbContext))]
    [Migration("20240410221939_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Balance.App.Model.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Balance")
                        .HasColumnType("integer");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d95f9fc4-3cf4-49e9-afd9-007da4653f4a"),
                            Balance = 100000,
                            ClientId = new Guid("4cf4c747-8b7e-4520-92bd-431e64b2ab4c"),
                            CreatedAt = new DateTime(2024, 4, 10, 22, 19, 38, 146, DateTimeKind.Utc).AddTicks(6158)
                        },
                        new
                        {
                            Id = new Guid("1232b62f-5b34-4b8a-9f7a-1a349390a353"),
                            Balance = 10,
                            ClientId = new Guid("ba7f96dc-3b7a-4d78-84f6-4756ad4bfb74"),
                            CreatedAt = new DateTime(2024, 4, 10, 22, 19, 38, 146, DateTimeKind.Utc).AddTicks(6166)
                        });
                });

            modelBuilder.Entity("Balance.App.Model.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4cf4c747-8b7e-4520-92bd-431e64b2ab4c"),
                            CreatedAt = new DateTime(2024, 4, 10, 22, 19, 38, 146, DateTimeKind.Utc).AddTicks(5830),
                            Email = "belarmino@mail.com",
                            Name = "Belarmino"
                        },
                        new
                        {
                            Id = new Guid("ba7f96dc-3b7a-4d78-84f6-4756ad4bfb74"),
                            CreatedAt = new DateTime(2024, 4, 10, 22, 19, 38, 146, DateTimeKind.Utc).AddTicks(5851),
                            Email = "neto@mail.com",
                            Name = "Neto"
                        });
                });

            modelBuilder.Entity("Balance.App.Model.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AccountFromId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("AccountToId")
                        .HasColumnType("uuid");

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
