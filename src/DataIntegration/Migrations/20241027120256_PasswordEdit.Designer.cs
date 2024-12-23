﻿// <auto-generated />
using DataIntegration.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataIntegration.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20241027120256_PasswordEdit")]
    partial class PasswordEdit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DomainModel.Model.Canvas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdAuthor")
                        .HasColumnType("int");

                    b.Property<int>("IdStatus")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdAuthor");

                    b.HasIndex("IdStatus");

                    b.ToTable("Canvas");
                });

            modelBuilder.Entity("DomainModel.Model.InteractiveCanvas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Author")
                        .HasColumnType("int");

                    b.Property<string>("ConnectionString")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdStatus")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Author");

                    b.HasIndex("IdStatus");

                    b.ToTable("InteractiveCanvas");
                });

            modelBuilder.Entity("DomainModel.Model.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("DomainModel.Model.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Status", (string)null);
                });

            modelBuilder.Entity("DomainModel.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<byte[]>("Icon")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("IdRole")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("IdRole");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("DomainModel.Model.Canvas", b =>
                {
                    b.HasOne("DomainModel.Model.User", "IdAuthorNavigation")
                        .WithMany("Canvas")
                        .HasForeignKey("IdAuthor")
                        .IsRequired()
                        .HasConstraintName("FK_Canvas_User");

                    b.HasOne("DomainModel.Model.Status", "IdStatusNavigation")
                        .WithMany("Canvas")
                        .HasForeignKey("IdStatus")
                        .IsRequired()
                        .HasConstraintName("FK_Canvas_Status");

                    b.Navigation("IdAuthorNavigation");

                    b.Navigation("IdStatusNavigation");
                });

            modelBuilder.Entity("DomainModel.Model.InteractiveCanvas", b =>
                {
                    b.HasOne("DomainModel.Model.User", "AuthorNavigation")
                        .WithMany("InteractiveCanvas")
                        .HasForeignKey("Author")
                        .IsRequired()
                        .HasConstraintName("FK_InteractiveCanvas_User");

                    b.HasOne("DomainModel.Model.Status", "IdStatusNavigation")
                        .WithMany("InteractiveCanvas")
                        .HasForeignKey("IdStatus")
                        .IsRequired()
                        .HasConstraintName("FK_InteractiveCanvas_Status");

                    b.Navigation("AuthorNavigation");

                    b.Navigation("IdStatusNavigation");
                });

            modelBuilder.Entity("DomainModel.Model.User", b =>
                {
                    b.HasOne("DomainModel.Model.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("IdRole")
                        .IsRequired()
                        .HasConstraintName("FK_User_Role");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DomainModel.Model.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("DomainModel.Model.Status", b =>
                {
                    b.Navigation("Canvas");

                    b.Navigation("InteractiveCanvas");
                });

            modelBuilder.Entity("DomainModel.Model.User", b =>
                {
                    b.Navigation("Canvas");

                    b.Navigation("InteractiveCanvas");
                });
#pragma warning restore 612, 618
        }
    }
}
