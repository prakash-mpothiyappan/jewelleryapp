﻿// <auto-generated />
using Jewellery.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Jewellery.Migrations.Migrations
{
    [DbContext(typeof(JewelleryContext))]
    partial class JewelleryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Jewellery.Enities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RoleName");

                    b.HasKey("RoleId")
                        .HasName("PK_Role_RoleId");

                    b.ToTable("Role", "dbo");
                });

            modelBuilder.Entity("Jewellery.Enities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DisplayName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserName");

                    b.HasKey("UserId")
                        .HasName("PK_User_UserId");

                    b.ToTable("User", "dbo");
                });

            modelBuilder.Entity("Jewellery.Enities.UserInRole", b =>
                {
                    b.Property<int>("UserInRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserInRoleId")
                        .HasName("PK_UserInRole_UserInRoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserInRole", "dbo");
                });

            modelBuilder.Entity("Jewellery.Enities.UserInRole", b =>
                {
                    b.HasOne("Jewellery.Enities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_UserInrole_Role_RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Jewellery.Enities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserInrole_User_UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}