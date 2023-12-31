﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoMusical.Database;

#nullable disable

namespace ProjetoMusical.Migrations
{
    [DbContext(typeof(ProjetoMusicalDBContext))]
    [Migration("20230820012013_RelacionamentoTitularObra")]
    partial class RelacionamentoTitularObra
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjetoMusical.Models.ObraModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("TitularId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TitularId");

                    b.ToTable("Obras");
                });

            modelBuilder.Entity("ProjetoMusical.Models.TitularModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nacionalidade")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Titulares");
                });

            modelBuilder.Entity("ProjetoMusical.Models.ObraModel", b =>
                {
                    b.HasOne("ProjetoMusical.Models.TitularModel", "Titular")
                        .WithMany()
                        .HasForeignKey("TitularId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Titular");
                });
#pragma warning restore 612, 618
        }
    }
}
