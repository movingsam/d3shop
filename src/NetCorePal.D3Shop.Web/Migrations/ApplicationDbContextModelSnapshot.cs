﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetCorePal.D3Shop.Infrastructure;

#nullable disable

namespace NetCorePal.D3Shop.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("NetCorePal.D3Shop.Domain.AggregatesModel.DeliverAggregate.DeliverRecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("deliverrecord", (string)null);
                });

            modelBuilder.Entity("NetCorePal.D3Shop.Domain.AggregatesModel.Identity.AdminUserAggregate.AdminUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LoginExpiryDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("adminUsers", (string)null);
                });

            modelBuilder.Entity("NetCorePal.D3Shop.Domain.AggregatesModel.Identity.AdminUserAggregate.AdminUserPermission", b =>
                {
                    b.Property<long>("AdminUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("PermissionCode")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PermissionRemark")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SourceRoleIds")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AdminUserId", "PermissionCode");

                    b.ToTable("adminUserPermissions", (string)null);
                });

            modelBuilder.Entity("NetCorePal.D3Shop.Domain.AggregatesModel.Identity.AdminUserAggregate.AdminUserRole", b =>
                {
                    b.Property<long>("AdminUserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AdminUserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("adminUserRoles", (string)null);
                });

            modelBuilder.Entity("NetCorePal.D3Shop.Domain.AggregatesModel.Identity.RoleAggregate.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("NetCorePal.D3Shop.Domain.AggregatesModel.Identity.RoleAggregate.RolePermission", b =>
                {
                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<string>("PermissionCode")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PermissionRemark")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RoleId", "PermissionCode");

                    b.ToTable("rolePermissions", (string)null);
                });

            modelBuilder.Entity("NetCorePal.D3Shop.Domain.AggregatesModel.OrderAggregate.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Paid")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("order", (string)null);
                });

            modelBuilder.Entity("NetCorePal.D3Shop.Domain.AggregatesModel.Identity.AdminUserAggregate.AdminUserPermission", b =>
                {
                    b.HasOne("NetCorePal.D3Shop.Domain.AggregatesModel.Identity.AdminUserAggregate.AdminUser", null)
                        .WithMany("Permissions")
                        .HasForeignKey("AdminUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NetCorePal.D3Shop.Domain.AggregatesModel.Identity.AdminUserAggregate.AdminUserRole", b =>
                {
                    b.HasOne("NetCorePal.D3Shop.Domain.AggregatesModel.Identity.AdminUserAggregate.AdminUser", null)
                        .WithMany("Roles")
                        .HasForeignKey("AdminUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetCorePal.D3Shop.Domain.AggregatesModel.Identity.RoleAggregate.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NetCorePal.D3Shop.Domain.AggregatesModel.Identity.RoleAggregate.RolePermission", b =>
                {
                    b.HasOne("NetCorePal.D3Shop.Domain.AggregatesModel.Identity.RoleAggregate.Role", null)
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NetCorePal.D3Shop.Domain.AggregatesModel.Identity.AdminUserAggregate.AdminUser", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("NetCorePal.D3Shop.Domain.AggregatesModel.Identity.RoleAggregate.Role", b =>
                {
                    b.Navigation("Permissions");
                });
#pragma warning restore 612, 618
        }
    }
}
