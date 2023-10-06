﻿// <auto-generated />
using System;
using ABCCProgram;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ABCCProgram.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231006062906_CorrecionString")]
    partial class CorrecionString
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ABCCProgram.Entidades.Clase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NomClase")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clases");
                });

            modelBuilder.Entity("ABCCProgram.Entidades.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NomDepartamento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("ABCCProgram.Entidades.Familia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NomFamilia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Familias");
                });

            modelBuilder.Entity("ABCCProgram.Entidades.Productos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("Clase")
                        .HasColumnType("int");

                    b.Property<int?>("ClaseTabId")
                        .HasColumnType("int");

                    b.Property<int>("Departamento")
                        .HasColumnType("int");

                    b.Property<int?>("DepartamentoTabId")
                        .HasColumnType("int");

                    b.Property<int>("Descontinuado")
                        .HasColumnType("int");

                    b.Property<int>("Familia")
                        .HasColumnType("int");

                    b.Property<int?>("FamiliaTabId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaDeAlta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaDeBaja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreArticulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sku")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ClaseTabId");

                    b.HasIndex("DepartamentoTabId");

                    b.HasIndex("FamiliaTabId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("ABCCProgram.Entidades.Productos", b =>
                {
                    b.HasOne("ABCCProgram.Entidades.Clase", "ClaseTab")
                        .WithMany()
                        .HasForeignKey("ClaseTabId");

                    b.HasOne("ABCCProgram.Entidades.Departamento", "DepartamentoTab")
                        .WithMany()
                        .HasForeignKey("DepartamentoTabId");

                    b.HasOne("ABCCProgram.Entidades.Familia", "FamiliaTab")
                        .WithMany()
                        .HasForeignKey("FamiliaTabId");

                    b.Navigation("ClaseTab");

                    b.Navigation("DepartamentoTab");

                    b.Navigation("FamiliaTab");
                });
#pragma warning restore 612, 618
        }
    }
}
