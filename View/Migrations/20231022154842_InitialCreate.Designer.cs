﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sample.Core.Data;

#nullable disable

namespace View.Migrations
{
    [DbContext(typeof(SampleContext))]
    [Migration("20231022154842_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Sample.Core.Models.MovieModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("ID");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("varchar(45)")
                        .HasColumnName("GENRE");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(45)")
                        .HasColumnName("TITLE");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IDX_MOVIES_001")
                        .IsUnique();

                    b.HasIndex(new[] { "Title" }, "IDX_MOVIES_002")
                        .IsUnique();

                    b.ToTable("MOVIES", (string)null);
                });

            modelBuilder.Entity("Sample.Core.Models.PeopleMovies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("ID");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("DATE");

                    b.Property<int>("MovieId")
                        .HasColumnType("INT")
                        .HasColumnName("ID_MOVIE");

                    b.Property<int>("PersonId")
                        .HasColumnType("INT")
                        .HasColumnName("ID_PERSON");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IDX_PEOPLE_MOVIES_001")
                        .IsUnique();

                    b.HasIndex(new[] { "PersonId" }, "IND_PEOPLE_MOVIES_001");

                    b.HasIndex(new[] { "MovieId" }, "IND_PEOPLE_MOVIES_002");

                    b.ToTable("PEOPLE_MOVIES", (string)null);
                });

            modelBuilder.Entity("Sample.Core.Models.PersonModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("ID");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(45)")
                        .HasColumnName("FIRST_NAME");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(45)")
                        .HasColumnName("LAST_NAME");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IDX_PEOPLE_001")
                        .IsUnique();

                    b.ToTable("PEOPLE", (string)null);
                });

            modelBuilder.Entity("Sample.Core.Models.PeopleMovies", b =>
                {
                    b.HasOne("Sample.Core.Models.MovieModel", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PEOPLE_MOVIES_MOVIES_002");

                    b.HasOne("Sample.Core.Models.PersonModel", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PEOPLE_MOVIES_PEOPLE_001");

                    b.Navigation("Movie");

                    b.Navigation("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
