﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MyFrstMVCApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.1.24451.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            Name = "GenreFromJsonFile1"
                        },
                        new
                        {
                            GenreId = 2,
                            Name = "GenreFromJsonFile2"
                        });
                });

            modelBuilder.Entity("MembershipType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("discountRate")
                        .HasColumnType("real");

                    b.Property<int>("durationInMonths")
                        .HasColumnType("int");

                    b.Property<float>("signupFee")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("MembershipTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            discountRate = 10.5f,
                            durationInMonths = 12,
                            signupFee = 49.99f
                        },
                        new
                        {
                            Id = 2,
                            discountRate = 5f,
                            durationInMonths = 6,
                            signupFee = 29.99f
                        });
                });

            modelBuilder.Entity("MyFrstMVCApp.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MembershipTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MembershipTypeId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MembershipTypeId = 1,
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = 2,
                            MembershipTypeId = 2,
                            Name = "Jane Smith"
                        });
                });

            modelBuilder.Entity("MyFrstMVCApp.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<DateTime>("MovieAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreId = 1,
                            MovieAdded = new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Inception",
                            photo = "images/inception.jpg"
                        },
                        new
                        {
                            Id = 2,
                            GenreId = 2,
                            MovieAdded = new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Dark Knight",
                            photo = "images/dark_knight.jpg"
                        });
                });

            modelBuilder.Entity("MyFrstMVCApp.Models.MovieClient", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "ClientId");

                    b.HasIndex("ClientId");

                    b.ToTable("MovieClients");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            ClientId = 1
                        },
                        new
                        {
                            MovieId = 2,
                            ClientId = 2
                        });
                });

            modelBuilder.Entity("MyFrstMVCApp.Models.Client", b =>
                {
                    b.HasOne("MembershipType", "MembershipType")
                        .WithMany("Clients")
                        .HasForeignKey("MembershipTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MembershipType");
                });

            modelBuilder.Entity("MyFrstMVCApp.Models.Movie", b =>
                {
                    b.HasOne("Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MyFrstMVCApp.Models.MovieClient", b =>
                {
                    b.HasOne("MyFrstMVCApp.Models.Client", "Client")
                        .WithMany("MovieClients")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyFrstMVCApp.Models.Movie", "Movie")
                        .WithMany("MovieClients")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Genre", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MembershipType", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("MyFrstMVCApp.Models.Client", b =>
                {
                    b.Navigation("MovieClients");
                });

            modelBuilder.Entity("MyFrstMVCApp.Models.Movie", b =>
                {
                    b.Navigation("MovieClients");
                });
#pragma warning restore 612, 618
        }
    }
}
