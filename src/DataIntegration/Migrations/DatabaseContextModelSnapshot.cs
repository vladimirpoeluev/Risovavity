﻿// <auto-generated />
using DataIntegration.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataIntegration.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MainVersionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("MainVersionId")
                        .IsUnique();

                    b.HasIndex("StatusId");

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
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("IdRole");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("DomainModel.Model.VersionProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorOfVersionId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ParentOfVersionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorOfVersionId");

                    b.HasIndex("ParentOfVersionId");

                    b.ToTable("VersionsProjects");
                });

            modelBuilder.Entity("DomainModel.Model.Canvas", b =>
                {
                    b.HasOne("DomainModel.Model.User", "Author")
                        .WithMany("Canvas")
                        .HasForeignKey("AuthorId")
                        .IsRequired()
                        .HasConstraintName("FK_Canvas_User");

                    b.HasOne("DomainModel.Model.VersionProject", "MainVersion")
                        .WithOne("Canvas")
                        .HasForeignKey("DomainModel.Model.Canvas", "MainVersionId")
                        .IsRequired()
                        .HasConstraintName("FK_Canvas_VersionProject");

                    b.HasOne("DomainModel.Model.Status", "Status")
                        .WithMany("Canvas")
                        .HasForeignKey("StatusId")
                        .IsRequired()
                        .HasConstraintName("FK_Canvas_Status");

                    b.Navigation("Author");

                    b.Navigation("MainVersion");

                    b.Navigation("Status");
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

            modelBuilder.Entity("DomainModel.Model.VersionProject", b =>
                {
                    b.HasOne("DomainModel.Model.User", "AuthorOfVersion")
                        .WithMany("VersionsProjects")
                        .HasForeignKey("AuthorOfVersionId")
                        .IsRequired()
                        .HasConstraintName("FK_VersionProject_User");

                    b.HasOne("DomainModel.Model.VersionProject", "ParentOfVersion")
                        .WithMany("DescendantsVersionProject")
                        .HasForeignKey("ParentOfVersionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_VersionProject_VersionProject");

                    b.Navigation("AuthorOfVersion");

                    b.Navigation("ParentOfVersion");
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

                    b.Navigation("VersionsProjects");
                });

            modelBuilder.Entity("DomainModel.Model.VersionProject", b =>
                {
                    b.Navigation("Canvas")
                        .IsRequired();

                    b.Navigation("DescendantsVersionProject");
                });
#pragma warning restore 612, 618
        }
    }
}
