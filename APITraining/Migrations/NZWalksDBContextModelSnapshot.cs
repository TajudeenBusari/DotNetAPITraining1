﻿// <auto-generated />
using System;
using APITraining.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APITraining.Migrations
{
    [DbContext(typeof(NZWalksDBContext))]
    partial class NZWalksDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.2.24128.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APITraining.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9f480a29-56d8-48fb-859c-96321fcce1a3"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("8506a759-6f16-457d-9da7-b75b17cb45c6"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("b48ba3a6-d095-4b13-8226-5e6a8739f000"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("APITraining.Models.Domain.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("APITraining.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("57f83532-2774-4349-b56a-70a21ca41b54"),
                            Code = "LAG",
                            Name = "Lagos",
                            RegionImageUrl = "https://www.istockphoto.com/fi/valokuva/afrikkalainen-megakaupunki-lagos-nigeria-gm1320231994-406863542"
                        },
                        new
                        {
                            Id = new Guid("e1e558cf-26db-4961-9b51-effecc874f97"),
                            Code = "OSU",
                            Name = "Osun",
                            RegionImageUrl = "https://c8.alamy.com/comp/E8WAKE/streets-of-oshogbo-a-city-in-osun-state-nigeria-E8WAKE.jpg"
                        },
                        new
                        {
                            Id = new Guid("e661ea9e-6cb4-47cd-bade-04c8017fea1e"),
                            Code = "OYO",
                            Name = "Oyo",
                            RegionImageUrl = "https://c8.alamy.com/comp/E8W8H1/streets-of-the-city-of-ibadan-oyo-state-nigeria-E8W8H1.jpg"
                        },
                        new
                        {
                            Id = new Guid("f5d9c0b1-32fa-4e61-b705-1ae097e109f1"),
                            Code = "OGU",
                            Name = "Ogun",
                            RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/e/ef/The_First_Overhead_Bridge_in_Abeokuta_Ogun_State.jpg"
                        },
                        new
                        {
                            Id = new Guid("269166c9-b4ca-4a63-b865-edccee3ab03f"),
                            Code = "OND",
                            Name = "Ondo",
                            RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/82/Idanre_Hills_Ondo_State.jpg/2560px-Idanre_Hills_Ondo_State.jpg"
                        },
                        new
                        {
                            Id = new Guid("e39156e2-4672-4e38-a61f-bcd20af31397"),
                            Code = "EKT",
                            Name = "Ekiti",
                            RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/5/5c/The_Iworoko_mountain_05.jpg"
                        },
                        new
                        {
                            Id = new Guid("019505d6-1c17-4372-83ab-1711030957ab"),
                            Code = "KWR",
                            Name = "Kwara",
                            RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/cb/Kwarastatedrummers.jpg/220px-Kwarastatedrummers.jpg"
                        });
                });

            modelBuilder.Entity("APITraining.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("APITraining.Models.Domain.Walk", b =>
                {
                    b.HasOne("APITraining.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APITraining.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
