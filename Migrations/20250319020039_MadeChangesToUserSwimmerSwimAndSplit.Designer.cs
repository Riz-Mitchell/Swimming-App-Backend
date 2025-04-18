﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SwimmingAppBackend.Context;

#nullable disable

namespace SwimmingAppBackend.Migrations
{
    [DbContext(typeof(SwimmingAppDBContext))]
    [Migration("20250319020039_MadeChangesToUserSwimmerSwimAndSplit")]
    partial class MadeChangesToUserSwimmerSwimAndSplit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SwimmingAppBackend.Models.Split", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("Distance")
                        .HasColumnType("integer");

                    b.Property<bool?>("Dive")
                        .HasColumnType("boolean");

                    b.Property<int?>("Pace")
                        .HasColumnType("integer");

                    b.Property<int?>("PerceivedExertion")
                        .HasColumnType("integer");

                    b.Property<string>("Stroke")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("StrokeRate")
                        .HasColumnType("integer");

                    b.Property<int>("SwimId")
                        .HasColumnType("integer");

                    b.Property<int?>("Time")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SwimId");

                    b.ToTable("Splits");
                });

            modelBuilder.Entity("SwimmingAppBackend.Models.Swim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Distance")
                        .HasColumnType("integer");

                    b.Property<bool?>("Dive")
                        .HasColumnType("boolean");

                    b.Property<int?>("HeartRate")
                        .HasColumnType("integer");

                    b.Property<int?>("Pace")
                        .HasColumnType("integer");

                    b.Property<int?>("PerceivedExertion")
                        .HasColumnType("integer");

                    b.Property<string>("Stroke")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("StrokeRate")
                        .HasColumnType("integer");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Swims");
                });

            modelBuilder.Entity("SwimmingAppBackend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("UserType").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SwimmingAppBackend.Models.Swimmer", b =>
                {
                    b.HasBaseType("SwimmingAppBackend.Models.User");

                    b.HasDiscriminator().HasValue("Swimer");
                });

            modelBuilder.Entity("SwimmingAppBackend.Models.Split", b =>
                {
                    b.HasOne("SwimmingAppBackend.Models.Swim", "Swim")
                        .WithMany("Splits")
                        .HasForeignKey("SwimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Swim");
                });

            modelBuilder.Entity("SwimmingAppBackend.Models.Swim", b =>
                {
                    b.HasOne("SwimmingAppBackend.Models.Swimmer", "User")
                        .WithMany("Swims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SwimmingAppBackend.Models.Swim", b =>
                {
                    b.Navigation("Splits");
                });

            modelBuilder.Entity("SwimmingAppBackend.Models.Swimmer", b =>
                {
                    b.Navigation("Swims");
                });
#pragma warning restore 612, 618
        }
    }
}
