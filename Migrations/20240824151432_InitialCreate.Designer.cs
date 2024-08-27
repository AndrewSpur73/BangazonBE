﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BangazonBE.Migrations
{
    [DbContext(typeof(BangazonBEDbContext))]
    [Migration("20240824151432_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BangazonBE.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.Property<bool>("OrderComplete")
                        .HasColumnType("boolean");

                    b.Property<int?>("PaymentTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("OrderId");

                    b.HasIndex("PaymentTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            OrderComplete = true,
                            PaymentTypeId = 1,
                            Uid = "UddDl9yg9Nhq28kdu0SQyjjstkr2"
                        },
                        new
                        {
                            OrderId = 2,
                            OrderComplete = false,
                            PaymentTypeId = 2,
                            Uid = "UddDl9yg9Nhq28kdu0SQyjjstkr2"
                        },
                        new
                        {
                            OrderId = 3,
                            OrderComplete = true,
                            PaymentTypeId = 2,
                            Uid = "UddDl9yg9Nhq28kdu0SQyjjstkr2"
                        });
                });

            modelBuilder.Entity("BangazonBE.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Credit Card"
                        },
                        new
                        {
                            Id = 2,
                            Category = "PayPal"
                        });
                });

            modelBuilder.Entity("BangazonBE.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int?>("ProductTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("SellerId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Description = "A nice laptop",
                            ImageUrl = "https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RW16TLP?ver=5c8b&q=90&m=6&h=705&w=1253&b=%23FFFFFFFF&f=jpg&o=f&p=140&aim=true",
                            Price = 999.99m,
                            ProductTypeId = 1,
                            Quantity = 10,
                            SellerId = 2,
                            Title = "Laptop"
                        },
                        new
                        {
                            ProductId = 2,
                            Description = "A nice t-shirt",
                            ImageUrl = "https://media.istockphoto.com/id/684650726/photo/blank-t-shirt-color-orange.jpg?s=612x612&w=0&k=20&c=8WUYvzOBuouKdW6t3snwCEnU8mHPiqOjokvbIgZJlXA=",
                            Price = 19.99m,
                            ProductTypeId = 2,
                            Quantity = 20,
                            SellerId = 2,
                            Title = "T-shirt"
                        });
                });

            modelBuilder.Entity("BangazonBE.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Accessories"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Tops"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Shoes"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Bottoms"
                        });
                });

            modelBuilder.Entity("BangazonBE.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool?>("Seller")
                        .HasColumnType("boolean");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St",
                            Email = "aspurlock@coding.com",
                            FirstName = "Andyroo",
                            LastName = "Spurlock",
                            Seller = false,
                            Uid = "firebase_key_1",
                            UserName = "TalkingLunchbox"
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Elm St",
                            Email = "scribblekathy@example.com",
                            FirstName = "Kathleen",
                            LastName = "Byrd",
                            Seller = true,
                            Uid = "firebase_key_2",
                            UserName = "WildthornBerry"
                        });
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<int>("OrdersOrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductsProductId")
                        .HasColumnType("integer");

                    b.HasKey("OrdersOrderId", "ProductsProductId");

                    b.HasIndex("ProductsProductId");

                    b.ToTable("OrderProduct", (string)null);
                });

            modelBuilder.Entity("BangazonBE.Models.Order", b =>
                {
                    b.HasOne("BangazonBE.Models.PaymentType", "PaymentType")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentTypeId");

                    b.HasOne("BangazonBE.Models.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

                    b.Navigation("PaymentType");
                });

            modelBuilder.Entity("BangazonBE.Models.Product", b =>
                {
                    b.HasOne("BangazonBE.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("BangazonBE.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BangazonBE.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BangazonBE.Models.PaymentType", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BangazonBE.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
