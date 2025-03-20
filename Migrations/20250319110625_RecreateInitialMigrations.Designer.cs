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
    [Migration("20250319110625_RecreateInitialMigrations")]
    partial class RecreateInitialMigrations
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

                    b.Property<int?>("distance")
                        .HasColumnType("integer");

                    b.Property<bool?>("dive")
                        .HasColumnType("boolean");

                    b.Property<int?>("pace")
                        .HasColumnType("integer");

                    b.Property<int?>("perceivedExertion")
                        .HasColumnType("integer");

                    b.Property<string>("stroke")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("strokeRate")
                        .HasColumnType("integer");

                    b.Property<int>("swimId")
                        .HasColumnType("integer");

                    b.Property<int?>("time")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("swimId");

                    b.ToTable("Split");
                });

            modelBuilder.Entity("SwimmingAppBackend.Models.Swim", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("distance")
                        .HasColumnType("integer");

                    b.Property<bool?>("dive")
                        .HasColumnType("boolean");

                    b.Property<int?>("heartRate")
                        .HasColumnType("integer");

                    b.Property<int?>("pace")
                        .HasColumnType("integer");

                    b.Property<int?>("perceivedExertion")
                        .HasColumnType("integer");

                    b.Property<string>("stroke")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("strokeRate")
                        .HasColumnType("integer");

                    b.Property<int>("swimmerProfileId")
                        .HasColumnType("integer");

                    b.Property<string>("time")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("swimmerProfileId");

                    b.ToTable("Swim");
                });

            modelBuilder.Entity("SwimmingAppBackend.Models.SwimmerProfile", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("userId")
                        .IsUnique();

                    b.ToTable("SwimmerProfile");
                });

            modelBuilder.Entity("SwimmingAppBackend.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int?>("age")
                        .HasColumnType("integer");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phoneNum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SwimmingAppBackend.Models.Split", b =>
                {
                    b.HasOne("SwimmingAppBackend.Models.Swim", "swim")
                        .WithMany("splits")
                        .HasForeignKey("swimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("swim");
                });

            modelBuilder.Entity("SwimmingAppBackend.Models.Swim", b =>
                {
                    b.HasOne("SwimmingAppBackend.Models.SwimmerProfile", "swimmerProfile")
                        .WithMany("swims")
                        .HasForeignKey("swimmerProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("swimmerProfile");
                });

            modelBuilder.Entity("SwimmingAppBackend.Models.SwimmerProfile", b =>
                {
                    b.HasOne("SwimmingAppBackend.Models.User", "user")
                        .WithOne("swimmerProfile")
                        .HasForeignKey("SwimmingAppBackend.Models.SwimmerProfile", "userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("SwimmingAppBackend.Models.Swim", b =>
                {
                    b.Navigation("splits");
                });

            modelBuilder.Entity("SwimmingAppBackend.Models.SwimmerProfile", b =>
                {
                    b.Navigation("swims");
                });

            modelBuilder.Entity("SwimmingAppBackend.Models.User", b =>
                {
                    b.Navigation("swimmerProfile");
                });
#pragma warning restore 612, 618
        }
    }
}
