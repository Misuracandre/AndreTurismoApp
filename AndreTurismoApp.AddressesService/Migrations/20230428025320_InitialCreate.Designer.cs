﻿// <auto-generated />
using System;
using AndreTurismoApp.AddressesService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AndreTurismoApp.AddressesService.Migrations
{
    [DbContext(typeof(AndreTurismoAppAddressesServiceContext))]
    [Migration("20230428025320_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AndreTurismoApp.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCityId")
                        .HasColumnType("int");

                    b.Property<string>("Neighborhood")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Number")
                        .HasColumnType("int");

                    b.Property<DateTime>("Registration_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCityId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("AndreTurismoApp.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Registration_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("AndreTurismoApp.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdAddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Registration_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdAddressId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("AndreTurismoApp.Models.DTO.ViaCepAddressDto", b =>
                {
                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("ViaCepAddresses");
                });

            modelBuilder.Entity("AndreTurismoApp.Models.Address", b =>
                {
                    b.HasOne("AndreTurismoApp.Models.City", "IdCity")
                        .WithMany()
                        .HasForeignKey("IdCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdCity");
                });

            modelBuilder.Entity("AndreTurismoApp.Models.Client", b =>
                {
                    b.HasOne("AndreTurismoApp.Models.Address", "IdAddress")
                        .WithMany()
                        .HasForeignKey("IdAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdAddress");
                });
#pragma warning restore 612, 618
        }
    }
}