﻿// <auto-generated />
using System;
using CentralErros.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CentralErros.Migrations
{
    [DbContext(typeof(CentralErroContexto))]
    partial class CentralErroContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CentralErros.Models.Environment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("ENVIRONMENT");
                });

            modelBuilder.Entity("CentralErros.Models.ErrorOccurrence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnName("DETAILS");

                    b.Property<int>("EnvironmentId");

                    b.Property<string>("EnvironmentName");

                    b.Property<bool>("Filed")
                        .HasColumnName("FILED");

                    b.Property<int>("IdEvent")
                        .HasColumnName("ID_EVENTS");

                    b.Property<int>("LevelId");

                    b.Property<string>("LevelName");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnName("ORIGIN");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnName("REGISTRATION_DATE");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("TITLE");

                    b.Property<string>("TokenUser");

                    b.Property<int>("UserId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("EnvironmentId");

                    b.HasIndex("LevelId");

                    b.HasIndex("UserId");

                    b.ToTable("ERROR_OCURRENCE");
                });

            modelBuilder.Entity("CentralErros.Models.Level", b =>
                {
                    b.Property<int>("IdLevel")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LevelName")
                        .IsRequired()
                        .HasColumnName("LEVEL")
                        .HasMaxLength(50);

                    b.HasKey("IdLevel");

                    b.ToTable("LEVEL");
                });

            modelBuilder.Entity("CentralErros.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasMaxLength(100);

                    b.Property<DateTime>("Expiration")
                        .HasColumnName("EXPIRATION");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("PASSWORD")
                        .HasMaxLength(255);

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnName("TOKEN");

                    b.HasKey("Id");

                    b.ToTable("USER");
                });

            modelBuilder.Entity("CentralErros.Models.ErrorOccurrence", b =>
                {
                    b.HasOne("CentralErros.Models.Environment", "Environment")
                        .WithMany("ErrorOccurrences")
                        .HasForeignKey("EnvironmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CentralErros.Models.Level", "Level")
                        .WithMany("ErrorOccurrences")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CentralErros.Models.User", "User")
                        .WithMany("ErrorOccurrences")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
