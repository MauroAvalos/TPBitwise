﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TPBitwise.DAL.DataContext;

#nullable disable

namespace TPBitwise.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230929213023_ActualizacionTablaUsuario")]
    partial class ActualizacionTablaUsuario
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TPBitwise.Models.Etiqueta", b =>
                {
                    b.Property<int>("EtiquetaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EtiquetaId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EtiquetaId");

                    b.ToTable("Etiquetas");
                });

            modelBuilder.Entity("TPBitwise.Models.Proyecto", b =>
                {
                    b.Property<int>("ProyectoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProyectoId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("ProyectoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Proyectos");
                });

            modelBuilder.Entity("TPBitwise.Models.Tarea", b =>
                {
                    b.Property<int>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TareaId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProyectoId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TareaId");

                    b.HasIndex("ProyectoId");

                    b.ToTable("Tareas");
                });

            modelBuilder.Entity("TPBitwise.Models.TareaEtiqueta", b =>
                {
                    b.Property<int>("TareaId")
                        .HasColumnType("int");

                    b.Property<int>("EtiquetaId")
                        .HasColumnType("int");

                    b.HasKey("TareaId", "EtiquetaId");

                    b.HasIndex("EtiquetaId");

                    b.ToTable("TareaEtiquetas");
                });

            modelBuilder.Entity("TPBitwise.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("TPBitwise.Models.Proyecto", b =>
                {
                    b.HasOne("TPBitwise.Models.Usuario", "Usuario")
                        .WithMany("Proyectos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TPBitwise.Models.Tarea", b =>
                {
                    b.HasOne("TPBitwise.Models.Proyecto", "Proyecto")
                        .WithMany("Tareas")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyecto");
                });

            modelBuilder.Entity("TPBitwise.Models.TareaEtiqueta", b =>
                {
                    b.HasOne("TPBitwise.Models.Etiqueta", "Etiqueta")
                        .WithMany("TareaEtiquetas")
                        .HasForeignKey("EtiquetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPBitwise.Models.Tarea", "Tarea")
                        .WithMany("TareaEtiquetas")
                        .HasForeignKey("TareaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Etiqueta");

                    b.Navigation("Tarea");
                });

            modelBuilder.Entity("TPBitwise.Models.Etiqueta", b =>
                {
                    b.Navigation("TareaEtiquetas");
                });

            modelBuilder.Entity("TPBitwise.Models.Proyecto", b =>
                {
                    b.Navigation("Tareas");
                });

            modelBuilder.Entity("TPBitwise.Models.Tarea", b =>
                {
                    b.Navigation("TareaEtiquetas");
                });

            modelBuilder.Entity("TPBitwise.Models.Usuario", b =>
                {
                    b.Navigation("Proyectos");
                });
#pragma warning restore 612, 618
        }
    }
}
