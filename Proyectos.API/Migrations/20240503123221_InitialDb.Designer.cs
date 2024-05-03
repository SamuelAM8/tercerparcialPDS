﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyectos.API.Data;

#nullable disable

namespace Proyectos.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240503123221_InitialDb")]
    partial class InitialDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proyectos.Shared.Entities.ActividadesdeInvestigacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("FechadeInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fechafinalizacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("RecursosEspecializadosId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecursosEspecializadosId");

                    b.ToTable("actividadesde_Investigaciones");
                });

            modelBuilder.Entity("Proyectos.Shared.Entities.Investigadores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Afiliacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Investigadoress");
                });

            modelBuilder.Entity("Proyectos.Shared.Entities.ProyectodeInvestigacionCientifica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("FechaEstimadaFinalización")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechadeInicio")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InvestigadoressId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("PublicacionessId")
                        .HasColumnType("int");

                    b.Property<int?>("actividadesde_InvestigacionesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvestigadoressId");

                    b.HasIndex("PublicacionessId");

                    b.HasIndex("actividadesde_InvestigacionesId");

                    b.ToTable("proyectoDeInvestigacionCientificas");
                });

            modelBuilder.Entity("Proyectos.Shared.Entities.Publicaciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Autores")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("Fechapublicacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("publicacioness");
                });

            modelBuilder.Entity("Proyectos.Shared.Entities.RecursosEspecializados", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidadrequerida")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<DateTime>("Fechadeentrega")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Proveedor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("RecursosEspecializadoss");
                });

            modelBuilder.Entity("Proyectos.Shared.Entities.ActividadesdeInvestigacion", b =>
                {
                    b.HasOne("Proyectos.Shared.Entities.RecursosEspecializados", "RecursosEspecializados")
                        .WithMany("ActividadesdeInvestigacions")
                        .HasForeignKey("RecursosEspecializadosId");

                    b.Navigation("RecursosEspecializados");
                });

            modelBuilder.Entity("Proyectos.Shared.Entities.ProyectodeInvestigacionCientifica", b =>
                {
                    b.HasOne("Proyectos.Shared.Entities.Investigadores", "Investigadoress")
                        .WithMany("ProyectodeInvestigacionCientificas")
                        .HasForeignKey("InvestigadoressId");

                    b.HasOne("Proyectos.Shared.Entities.Publicaciones", "Publicacioness")
                        .WithMany("ProyectodeInvestigacionCientificas")
                        .HasForeignKey("PublicacionessId");

                    b.HasOne("Proyectos.Shared.Entities.ActividadesdeInvestigacion", "actividadesde_Investigaciones")
                        .WithMany("ProyectodeInvestigacionCientificas")
                        .HasForeignKey("actividadesde_InvestigacionesId");

                    b.Navigation("Investigadoress");

                    b.Navigation("Publicacioness");

                    b.Navigation("actividadesde_Investigaciones");
                });

            modelBuilder.Entity("Proyectos.Shared.Entities.ActividadesdeInvestigacion", b =>
                {
                    b.Navigation("ProyectodeInvestigacionCientificas");
                });

            modelBuilder.Entity("Proyectos.Shared.Entities.Investigadores", b =>
                {
                    b.Navigation("ProyectodeInvestigacionCientificas");
                });

            modelBuilder.Entity("Proyectos.Shared.Entities.Publicaciones", b =>
                {
                    b.Navigation("ProyectodeInvestigacionCientificas");
                });

            modelBuilder.Entity("Proyectos.Shared.Entities.RecursosEspecializados", b =>
                {
                    b.Navigation("ActividadesdeInvestigacions");
                });
#pragma warning restore 612, 618
        }
    }
}