﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieDetails.DBContexts;

namespace MovieDetails.Migrations
{
    [DbContext(typeof(MovieContext))]
    partial class MovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieDetails.Model.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DateAndTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoviePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Movie_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Movie_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateAndTime = "21/11/2020",
                            MoviePicture = "###",
                            Movie_Description = "THis is a action movie",
                            Movie_Name = "James Bond"
                        },
                        new
                        {
                            Id = 2,
                            DateAndTime = "22/11/2020",
                            MoviePicture = "###",
                            Movie_Description = "This is a adventures movie",
                            Movie_Name = "Jumanji"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
