﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VPP.Infrastructure.Context;

#nullable disable

namespace VPP.Infrastructure.Migrations
{
    [DbContext(typeof(VPPDBContext))]
    [Migration("20240328032459_VPPOnline")]
    partial class VPPOnline
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VPP.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryImg")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar");

                    b.Property<string>("CategoryName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("CategoryId");

                    b.HasIndex("CategoryGroupId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("VPP.Domain.Entities.CategoryGroup", b =>
                {
                    b.Property<Guid>("CategoryGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryGroupName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("CategoryGroupId");

                    b.ToTable("CategoryGroup", (string)null);
                });

            modelBuilder.Entity("VPP.Domain.Entities.CompanySupplier", b =>
                {
                    b.Property<Guid>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Comune")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("District")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar");

                    b.Property<string>("SupplierName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar");

                    b.HasKey("SupplierId");

                    b.ToTable("CompanySupplier", (string)null);
                });

            modelBuilder.Entity("VPP.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar");

                    b.Property<string>("OrderCode")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar");

                    b.Property<int?>("PaymentType")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<float?>("TotalAmount")
                        .HasColumnType("real");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("VPP.Domain.Entities.OrderDetail", b =>
                {
                    b.Property<Guid>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float?>("Price")
                        .HasColumnType("real");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<float?>("Total")
                        .HasColumnType("real");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetail", (string)null);
                });

            modelBuilder.Entity("VPP.Domain.Entities.Post", b =>
                {
                    b.Property<Guid>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LContent")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar");

                    b.Property<string>("PostImg")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar");

                    b.Property<string>("PostName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar");

                    b.Property<string>("SContent")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Post", (string)null);
                });

            modelBuilder.Entity("VPP.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LDescription")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar");

                    b.Property<string>("ProductImage")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar");

                    b.Property<string>("ProductName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar");

                    b.Property<float?>("ProductPrice")
                        .HasColumnType("real");

                    b.Property<string>("SDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("VPP.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("RoleDescription")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar");

                    b.Property<string>("RoleName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar");

                    b.HasKey("RoleId");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("VPP.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Avartar")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar");

                    b.Property<DateTime?>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Comune")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("District")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Email")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar");

                    b.Property<string>("FullName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar");

                    b.Property<string>("UserName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("VPP.Domain.Entities.UserRole", b =>
                {
                    b.Property<Guid>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserRoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole", (string)null);
                });

            modelBuilder.Entity("VPP.Domain.Entities.WareHouse", b =>
                {
                    b.Property<Guid>("WareHouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("WareHouseName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar");

                    b.HasKey("WareHouseId");

                    b.ToTable("WareHouse", (string)null);
                });

            modelBuilder.Entity("VPP.Domain.Entities.WareHouseDetail", b =>
                {
                    b.Property<Guid>("WareHouseDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float?>("Quantity")
                        .HasColumnType("real");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WareHouseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("WareHouseDetailId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("WareHouseId");

                    b.ToTable("WareHouseDetail", (string)null);
                });

            modelBuilder.Entity("VPP.Domain.Entities.Category", b =>
                {
                    b.HasOne("VPP.Domain.Entities.CategoryGroup", "CategoryGroups")
                        .WithMany("Categorys")
                        .HasForeignKey("CategoryGroupId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("CategoryGroups");
                });

            modelBuilder.Entity("VPP.Domain.Entities.Order", b =>
                {
                    b.HasOne("VPP.Domain.Entities.User", "Users")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("VPP.Domain.Entities.OrderDetail", b =>
                {
                    b.HasOne("VPP.Domain.Entities.Order", "Orders")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VPP.Domain.Entities.Product", "Products")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("VPP.Domain.Entities.Post", b =>
                {
                    b.HasOne("VPP.Domain.Entities.User", "Users")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Users");
                });

            modelBuilder.Entity("VPP.Domain.Entities.Product", b =>
                {
                    b.HasOne("VPP.Domain.Entities.Category", "Categorys")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Categorys");
                });

            modelBuilder.Entity("VPP.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("VPP.Domain.Entities.Role", "Roles")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VPP.Domain.Entities.User", "Users")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("VPP.Domain.Entities.WareHouseDetail", b =>
                {
                    b.HasOne("VPP.Domain.Entities.Product", "Products")
                        .WithMany("WareHouseDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VPP.Domain.Entities.CompanySupplier", "CompanySuppliers")
                        .WithMany("WareHouseDetails")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VPP.Domain.Entities.WareHouse", "WareHouses")
                        .WithMany("WareHouseDetails")
                        .HasForeignKey("WareHouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanySuppliers");

                    b.Navigation("Products");

                    b.Navigation("WareHouses");
                });

            modelBuilder.Entity("VPP.Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("VPP.Domain.Entities.CategoryGroup", b =>
                {
                    b.Navigation("Categorys");
                });

            modelBuilder.Entity("VPP.Domain.Entities.CompanySupplier", b =>
                {
                    b.Navigation("WareHouseDetails");
                });

            modelBuilder.Entity("VPP.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("VPP.Domain.Entities.Product", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("WareHouseDetails");
                });

            modelBuilder.Entity("VPP.Domain.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("VPP.Domain.Entities.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Posts");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("VPP.Domain.Entities.WareHouse", b =>
                {
                    b.Navigation("WareHouseDetails");
                });
#pragma warning restore 612, 618
        }
    }
}