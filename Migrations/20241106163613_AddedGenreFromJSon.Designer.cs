﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MyFrstMVCApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241106163613_AddedGenreFromJSon")]
    partial class AddedGenreFromJSon
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            GenreId = -1,
                            Name = "GenreFromJsonFile1"
                        },
                        new
                        {
                            GenreId = -2,
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
                });

            modelBuilder.Entity("MyFrstMVCApp.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Movies");
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
