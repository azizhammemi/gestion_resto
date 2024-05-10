﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gestionresto1.Models;

#nullable disable

namespace gestionresto1.Migrations
{
    [DbContext(typeof(RestoContext))]
    [Migration("20231204160513_com")]
    partial class com
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("gestionresto1.Models.Categorie", b =>
                {
                    b.Property<int>("idCategorie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCategorie"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCategorie");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("gestionresto1.Models.Commande", b =>
                {
                    b.Property<int>("idcommande")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idcommande"));

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nomproduit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nomuser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prenomuser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("prix")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("idcommande");

                    b.ToTable("Commandes");
                });

            modelBuilder.Entity("gestionresto1.Models.Produit", b =>
                {
                    b.Property<int>("idProduit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idProduit"));

                    b.Property<int?>("CategorieidCategorie")
                        .HasColumnType("int");

                    b.Property<int?>("categrieId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("prix")
                        .HasColumnType("int");

                    b.HasKey("idProduit");

                    b.HasIndex("CategorieidCategorie");

                    b.ToTable("Produits");
                });

            modelBuilder.Entity("gestionresto1.Models.User", b =>
                {
                    b.Property<int>("idusers")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idusers"));

                    b.Property<string>("cin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idusers");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("gestionresto1.Models.Produit", b =>
                {
                    b.HasOne("gestionresto1.Models.Categorie", "Categorie")
                        .WithMany()
                        .HasForeignKey("CategorieidCategorie");

                    b.Navigation("Categorie");
                });
#pragma warning restore 612, 618
        }
    }
}