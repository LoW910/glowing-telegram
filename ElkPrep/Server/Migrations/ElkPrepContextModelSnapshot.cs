﻿// <auto-generated />
using System;
using ElkPrep.Server.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElkPrep.Server.Migrations
{
    [DbContext(typeof(ElkPrepContext))]
    partial class ElkPrepContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ElkPrep.Shared.Arrow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BowId")
                        .HasColumnType("int");

                    b.Property<string>("Broadhead")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Fletch")
                        .HasColumnType("int");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("arrows", (string)null);
                });

            modelBuilder.Entity("ElkPrep.Shared.Bow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DrawLength")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DrawWeight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("FPS")
                        .HasColumnType("int");

                    b.Property<int>("LetOff")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Range")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("bows", (string)null);
                });

            modelBuilder.Entity("ElkPrep.Shared.Shot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ArrowId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PointValue")
                        .HasColumnType("int");

                    b.Property<int?>("TargetId")
                        .HasColumnType("int");

                    b.Property<bool>("Vital")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ArrowId");

                    b.HasIndex("TargetId");

                    b.ToTable("Shot");
                });

            modelBuilder.Entity("ElkPrep.Shared.Target", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Length")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<decimal>("VitalSize")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Width")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Target");
                });

            modelBuilder.Entity("ElkPrep.Shared.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("ElkPrep.Shared.Arrow", b =>
                {
                    b.HasOne("ElkPrep.Shared.User", null)
                        .WithMany("Arrows")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ElkPrep.Shared.Bow", b =>
                {
                    b.HasOne("ElkPrep.Shared.User", null)
                        .WithMany("Bows")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ElkPrep.Shared.Shot", b =>
                {
                    b.HasOne("ElkPrep.Shared.Arrow", "Arrow")
                        .WithMany()
                        .HasForeignKey("ArrowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElkPrep.Shared.Target", null)
                        .WithMany("Shots")
                        .HasForeignKey("TargetId");

                    b.Navigation("Arrow");
                });

            modelBuilder.Entity("ElkPrep.Shared.Target", b =>
                {
                    b.HasOne("ElkPrep.Shared.User", null)
                        .WithMany("Targets")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ElkPrep.Shared.Target", b =>
                {
                    b.Navigation("Shots");
                });

            modelBuilder.Entity("ElkPrep.Shared.User", b =>
                {
                    b.Navigation("Arrows");

                    b.Navigation("Bows");

                    b.Navigation("Targets");
                });
#pragma warning restore 612, 618
        }
    }
}
