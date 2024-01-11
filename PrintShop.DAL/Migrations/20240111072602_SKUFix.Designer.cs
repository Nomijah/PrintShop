﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PrintShop.DAL.Context;

#nullable disable

namespace PrintShop.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240111072602_SKUFix")]
    partial class SKUFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", (string)null);
                });

            modelBuilder.Entity("PictureTag", b =>
                {
                    b.Property<int>("PicturesId")
                        .HasColumnType("integer");

                    b.Property<string>("TagsName")
                        .HasColumnType("text");

                    b.HasKey("PicturesId", "TagsName");

                    b.HasIndex("TagsName");

                    b.ToTable("PictureTag");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CartId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("integer");

                    b.Property<int?>("PictureId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PictureId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.Favorite", b =>
                {
                    b.Property<int>("PictureId")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("PictureId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Materials");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            Description = "Direktprint på Kapa är en prisvärd utskrift som lämpar sig för skyltproduktion eller tillfälliga utställningar.",
                            IsActive = true,
                            Name = "Kapa"
                        },
                        new
                        {
                            Id = 102,
                            Description = "Direktprint på plywood är en högkvalitativ utskrift direkt på träytan.",
                            IsActive = true,
                            Name = "Plywood"
                        },
                        new
                        {
                            Id = 103,
                            Description = "Tryck dina bilder på aluminium med lång hållbarhet och hög kvalitet. Trycket i kombination med aluminiumet ger dina bilder ett metalliskt skimmer och en modern industriell känsla.",
                            IsActive = true,
                            Name = "Aluminium"
                        },
                        new
                        {
                            Id = 104,
                            Description = "Tryck dina bilder på reptåligt plexiglas i tjocklekarna 4 mm och 8 mm. Trycket är högkvalitativ och lämpligt för både inom- och utomhusbruk.",
                            IsActive = true,
                            Name = "Plexiglas"
                        });
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Head")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsShipped")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ShippingTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.OrderRow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticleNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("NetPrice")
                        .HasColumnType("numeric");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.Property<string>("PictureName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Tax")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderRows");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("numeric");

                    b.Property<string>("CreatorIdentifier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("SKUPart")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.PictureTag", b =>
                {
                    b.Property<int>("PictureId")
                        .HasColumnType("integer");

                    b.Property<int>("TagId")
                        .HasColumnType("integer");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PictureId", "TagId");

                    b.HasIndex("TagName");

                    b.ToTable("PictureTags");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.PrintSize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<string>("SKUPart")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Size")
                        .HasColumnType("text");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("PrintSizes");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            Height = 30,
                            SKUPart = "030030",
                            Size = "30x30",
                            Width = 30
                        },
                        new
                        {
                            Id = 102,
                            Height = 50,
                            SKUPart = "050050",
                            Size = "50x50",
                            Width = 50
                        },
                        new
                        {
                            Id = 103,
                            Height = 70,
                            SKUPart = "070070",
                            Size = "70x70",
                            Width = 70
                        },
                        new
                        {
                            Id = 104,
                            Height = 100,
                            SKUPart = "100100",
                            Size = "100x100",
                            Width = 100
                        },
                        new
                        {
                            Id = 105,
                            Height = 150,
                            SKUPart = "150150",
                            Size = "150x150",
                            Width = 150
                        },
                        new
                        {
                            Id = 201,
                            Height = 30,
                            SKUPart = "030045",
                            Size = "30x45",
                            Width = 45
                        },
                        new
                        {
                            Id = 202,
                            Height = 50,
                            SKUPart = "050075",
                            Size = "50x75",
                            Width = 75
                        },
                        new
                        {
                            Id = 203,
                            Height = 70,
                            SKUPart = "070105",
                            Size = "70x105",
                            Width = 105
                        },
                        new
                        {
                            Id = 204,
                            Height = 100,
                            SKUPart = "100150",
                            Size = "100x150",
                            Width = 150
                        },
                        new
                        {
                            Id = 205,
                            Height = 150,
                            SKUPart = "150225",
                            Size = "150x225",
                            Width = 225
                        },
                        new
                        {
                            Id = 301,
                            Height = 45,
                            SKUPart = "045030",
                            Size = "45x30",
                            Width = 30
                        },
                        new
                        {
                            Id = 302,
                            Height = 75,
                            SKUPart = "075050",
                            Size = "75x50",
                            Width = 50
                        },
                        new
                        {
                            Id = 303,
                            Height = 105,
                            SKUPart = "105070",
                            Size = "105x70",
                            Width = 70
                        },
                        new
                        {
                            Id = 304,
                            Height = 150,
                            SKUPart = "150100",
                            Size = "150x100",
                            Width = 100
                        },
                        new
                        {
                            Id = 305,
                            Height = 225,
                            SKUPart = "225150",
                            Size = "225x150",
                            Width = 150
                        });
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int?>("PictureId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("VariantId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PictureId");

                    b.HasIndex("VariantId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("3ee80c76-4e52-479d-a3dd-767938dee0f1"),
                            ConcurrencyStamp = "1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("878bdf23-2cc9-4028-848b-b1f45791572b"),
                            ConcurrencyStamp = "2",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        },
                        new
                        {
                            Id = new Guid("beab5cbb-876b-4b68-834e-5551f19714a8"),
                            ConcurrencyStamp = "3",
                            Name = "Creator",
                            NormalizedName = "CREATOR"
                        });
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.Shipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<string>("ShippingCompany")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ShippingDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.Tag", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.UserCreatorId", b =>
                {
                    b.Property<string>("CreatorId")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("CreatorId", "UserId");

                    b.ToTable("UserCreatorIds");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.UserOrder", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "OrderId");

                    b.ToTable("UserOrders");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.Variant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("MaterialId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("PrintSizeId")
                        .HasColumnType("integer");

                    b.Property<string>("SKUPart")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.HasIndex("PrintSizeId");

                    b.ToTable("Variants");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("PrintShop.GlobalData.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("PrintShop.GlobalData.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("PrintShop.GlobalData.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("PrintShop.GlobalData.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrintShop.GlobalData.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("PrintShop.GlobalData.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PictureTag", b =>
                {
                    b.HasOne("PrintShop.GlobalData.Models.Picture", null)
                        .WithMany()
                        .HasForeignKey("PicturesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrintShop.GlobalData.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.Cart", b =>
                {
                    b.HasOne("PrintShop.GlobalData.Models.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("PrintShop.GlobalData.Models.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.CartItem", b =>
                {
                    b.HasOne("PrintShop.GlobalData.Models.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrintShop.GlobalData.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.Category", b =>
                {
                    b.HasOne("PrintShop.GlobalData.Models.Picture", null)
                        .WithMany("Categories")
                        .HasForeignKey("PictureId");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.Favorite", b =>
                {
                    b.HasOne("PrintShop.GlobalData.Models.User", null)
                        .WithMany("Favorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.OrderRow", b =>
                {
                    b.HasOne("PrintShop.GlobalData.Models.Order", null)
                        .WithMany("OrderRows")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.Payment", b =>
                {
                    b.HasOne("PrintShop.GlobalData.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.PictureTag", b =>
                {
                    b.HasOne("PrintShop.GlobalData.Models.Picture", "Picture")
                        .WithMany()
                        .HasForeignKey("PictureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrintShop.GlobalData.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Picture");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.Product", b =>
                {
                    b.HasOne("PrintShop.GlobalData.Models.Picture", "Picture")
                        .WithMany("Products")
                        .HasForeignKey("PictureId");

                    b.HasOne("PrintShop.GlobalData.Models.Variant", "Variant")
                        .WithMany()
                        .HasForeignKey("VariantId");

                    b.Navigation("Picture");

                    b.Navigation("Variant");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.Shipment", b =>
                {
                    b.HasOne("PrintShop.GlobalData.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.UserOrder", b =>
                {
                    b.HasOne("PrintShop.GlobalData.Models.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.Variant", b =>
                {
                    b.HasOne("PrintShop.GlobalData.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrintShop.GlobalData.Models.PrintSize", "Size")
                        .WithMany()
                        .HasForeignKey("PrintSizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.Order", b =>
                {
                    b.Navigation("OrderRows");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.Picture", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("PrintShop.GlobalData.Models.User", b =>
                {
                    b.Navigation("Cart");

                    b.Navigation("Favorites");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
