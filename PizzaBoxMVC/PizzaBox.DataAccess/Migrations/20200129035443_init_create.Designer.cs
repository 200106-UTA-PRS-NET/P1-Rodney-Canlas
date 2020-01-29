﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaBox.DataAccess.Entities;

namespace PizzaBox.DataAccess.Migrations
{
    [DbContext(typeof(PizzaBoxDbContext))]
    [Migration("20200129035443_init_create")]
    partial class init_create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PizzaBox.DataAccess.Entities.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnName("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnName("Store Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Zipcode")
                        .HasColumnName("Zipcode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Store","PizzaBox");
                });

            modelBuilder.Entity("PizzaBox.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("First Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("Last Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passphrase")
                        .IsRequired()
                        .HasColumnName("Passphrase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User","PizzaBox");
                });

            modelBuilder.Entity("PizzaBox.DataAccess.Entities.UserOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OrderContent")
                        .IsRequired()
                        .HasColumnName("Order Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDateTime")
                        .HasColumnName("Order Date/Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("StoreId")
                        .HasColumnName("Store ID")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCost")
                        .HasColumnName("Total Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnName("User ID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserOrder","PizzaBox");
                });
#pragma warning restore 612, 618
        }
    }
}
