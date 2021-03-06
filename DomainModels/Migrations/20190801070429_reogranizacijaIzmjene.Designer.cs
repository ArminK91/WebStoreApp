﻿// <auto-generated />
using DomainModels.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebStoreAPP.Common.Enumi;

namespace DomainModels.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190801070429_reogranizacijaIzmjene")]
    partial class reogranizacijaIzmjene
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DomainModels.DbModels.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users","dbo");
                });

            modelBuilder.Entity("DomainModels.DbModels.Automobil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Boja");

                    b.Property<decimal>("Cijena");

                    b.Property<string>("Godiste");

                    b.Property<bool>("GrijaciSjedista");

                    b.Property<decimal>("Kilometri");

                    b.Property<bool>("Klima");

                    b.Property<string>("Marka");

                    b.Property<string>("Motor");

                    b.Property<string>("Opis");

                    b.Property<bool>("PodizaciStakala");

                    b.Property<int>("ProizvId");

                    b.Property<bool>("Registrovan");

                    b.Property<bool>("ServoVolan");

                    b.Property<bool>("Siber");

                    b.Property<int>("Status");

                    b.Property<bool>("Xenoni");

                    b.Property<bool>("Zastita");

                    b.HasKey("Id");

                    b.ToTable("Automobili","dbo");
                });

            modelBuilder.Entity("DomainModels.DbModels.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories","dbo");
                });

            modelBuilder.Entity("DomainModels.DbModels.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Gender");

                    b.Property<string>("IdentityId");

                    b.Property<int?>("IdentityId1");

                    b.Property<string>("Locale");

                    b.Property<string>("Location");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId1");

                    b.ToTable("Customers","dbo");
                });

            modelBuilder.Entity("DomainModels.DbModels.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Path");

                    b.HasKey("Id");

                    b.ToTable("Images","dbo");
                });

            modelBuilder.Entity("DomainModels.DbModels.ProductImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ImageId");

                    b.Property<int>("ProductId");

                    b.Property<int?>("ProductId1");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductId1");

                    b.ToTable("ProductsImages","dbo");
                });

            modelBuilder.Entity("DomainModels.DbModels.Proizvod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adress");

                    b.Property<int?>("AutoId");

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("DatumObjave");

                    b.Property<string>("Description");

                    b.Property<string>("Naziv");

                    b.Property<decimal>("Price");

                    b.Property<bool>("Status");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AutoId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Proizvodi","dbo");
                });

            modelBuilder.Entity("DomainModels.DbModels.Sifarnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Extra1");

                    b.Property<string>("Extra2");

                    b.Property<string>("Extra3");

                    b.Property<string>("Naziv");

                    b.Property<int?>("RoditeljId");

                    b.Property<int>("TipSif");

                    b.Property<int>("Vrijednost");

                    b.HasKey("Id");

                    b.ToTable("Sifarnik","dbo");
                });

            modelBuilder.Entity("DomainModels.DbModels.Slika", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumDodavanja");

                    b.Property<bool>("Glavna");

                    b.Property<string>("Opis");

                    b.Property<int>("ProizvodId");

                    b.Property<string>("PublicId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("ProizvodId");

                    b.ToTable("Slike");
                });

            modelBuilder.Entity("DomainModels.DbModels.Customer", b =>
                {
                    b.HasOne("DomainModels.DbModels.ApplicationUser", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId1");
                });

            modelBuilder.Entity("DomainModels.DbModels.ProductImages", b =>
                {
                    b.HasOne("DomainModels.DbModels.Image", "Image")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DomainModels.DbModels.Proizvod", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId1");
                });

            modelBuilder.Entity("DomainModels.DbModels.Proizvod", b =>
                {
                    b.HasOne("DomainModels.DbModels.Automobil", "Auto")
                        .WithMany()
                        .HasForeignKey("AutoId");

                    b.HasOne("DomainModels.DbModels.Category", "Category")
                        .WithMany("Proizvodi")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModels.DbModels.Slika", b =>
                {
                    b.HasOne("DomainModels.DbModels.Proizvod", "Proizvod")
                        .WithMany("Slike")
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
