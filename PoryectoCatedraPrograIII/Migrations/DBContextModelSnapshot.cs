﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PoryectoCatedraPrograIII.Data;

#nullable disable

namespace PoryectoCatedraPrograIII.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PoryectoCatedraPrograIII.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoLugar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HoraFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("PrecioEntrada")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("PoryectoCatedraPrograIII.Models.EventoNegocio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<int>("TiendaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("TiendaId");

                    b.ToTable("EventosNegocios");
                });

            modelBuilder.Entity("PoryectoCatedraPrograIII.Models.Favorito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EventoId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int?>("TiendaId")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("ProductoId");

                    b.HasIndex("TiendaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Favoritos");
                });

            modelBuilder.Entity("PoryectoCatedraPrograIII.Models.HistorialBusqueda", b =>
                {
                    b.Property<int>("HistorialBusquedaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HistorialBusquedaId"));

                    b.Property<DateTime>("FechaBusqueda")
                        .HasColumnType("datetime2");

                    b.Property<string>("PalabraClave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("HistorialBusquedaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("HistorialBusqueda");
                });

            modelBuilder.Entity("PoryectoCatedraPrograIII.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("TiendaId")
                        .HasColumnType("int");

                    b.Property<int?>("TiendaId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TiendaId");

                    b.HasIndex("TiendaId1");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("PoryectoCatedraPrograIII.Models.Promocion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Descuento")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("TiendaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TiendaId");

                    b.ToTable("Promociones");
                });

            modelBuilder.Entity("PoryectoCatedraPrograIII.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Calificacion")
                        .HasColumnType("int");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int?>("TiendaId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.HasIndex("TiendaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("PoryectoCatedraPrograIII.Models.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AreaServicio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("TiempoEstimado")
                        .HasColumnType("int");

                    b.Property<int>("TiendaId")
                        .HasColumnType("int");

                    b.Property<string>("TipoMateriales")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TiendaId");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("PoryectoCatedraPrograIII.Models.Tienda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FacebookContacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoFachada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("NumeroContacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaginaWeb")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slogan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TieneEnvio")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Tiendas");
                });

            modelBuilder.Entity("PoryectoCatedraPrograIII.Models.TipoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TipoUsuarios");
                });

            modelBuilder.Entity("PoryectoCatedraPrograIII.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("FotoPerfil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetodoRegistro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TipoUsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoUsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PoryectoCatedraPrograIII.Models.EventoNegocio", b =>
                {
                    b.HasOne("PoryectoCatedraPrograIII.Models.Evento", "Evento")
                        .WithMany("NegociosParticipantes")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PoryectoCatedraPrograIII.Models.Tienda", "Tienda")
                        .WithMany("EventosAsociados")
                        .HasForeignKey("TiendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Tienda");
                });

            modelBuilder.Entity("PoryectoCatedraPrograIII.Models.Favorito", b =>
                {
                    b.HasOne("PoryectoCatedraPrograIII.Models.Evento", "Evento")
                        .WithMany()
                        .HasForeignKey("EventoId");

                    b.HasOne("PoryectoCatedraPrograIII.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId");

                    b.HasOne("PoryectoCatedraPrograIII.Models.Tienda", "Tienda")
                        .WithMany()
                        .HasForeignKey("TiendaId");

                    b.HasOne("PoryectoCatedraPrograIII.Models.Usuario", "Usuario")
                        .WithMany("Favoritos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Producto");

                    b.Navigation("Tienda");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PoryectoCatedraPrograIII.Models.HistorialBusqueda", b =>
                {
                    b.HasOne("PoryectoCatedraPrograIII.Models.Usuario", "Usuario")
                        .WithMany("HistorialBusquedas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PoryectoCatedraPrograIII.Models.Producto", b =>
                {
                    b.HasOne("PoryectoCatedraPrograIII.Models.Tienda", "Tienda")
                        .WithMany()
                        .HasForeignKey("TiendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PoryectoCatedraPrograIII.Models.Tienda", null)
                        .WithMany("Productos")
                        .HasForeignKey("TiendaId1");

                    b.Navigation("Tienda");
                });

            modelBuilder.Entity("PoryectoCatedraPrograIII.Models.Promocion", b =>
                {
                    b.HasOne("PoryectoCatedraPrograIII.Models.Tienda", "Tienda")
                        .WithMany()
                        .HasForeignKey("TiendaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Tienda");
                });

            modelBuilder.Entity("PoryectoCatedraPrograIII.Models.Review", b =>
                {
                    b.HasOne("PoryectoCatedraPrograIII.Models.Producto", "Producto")
                        .WithMany("reviews")
                        .HasForeignKey("ProductoId");

                    b.HasOne("PoryectoCatedraPrograIII.Models.Tienda", "Tienda")
                        .WithMany()
                        .HasForeignKey("TiendaId");

                    b.HasOne("PoryectoCatedraPrograIII.Models.Usuario", "Usuario")
                        .WithMany("reviews")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Tienda");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PoryectoCatedraPrograIII.Models.Servicio", b =>
                {
                    b.HasOne("PoryectoCatedraPrograIII.Models.Tienda", "Tienda")
                        .WithMany("Servicios")
                        .HasForeignKey("TiendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tienda");
                });

            modelBuilder.Entity("PoryectoCatedraPrograIII.Models.Usuario", b =>
                {
                    b.HasOne("PoryectoCatedraPrograIII.Models.TipoUsuario", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("TipoUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoUsuario");
                });

            modelBuilder.Entity("PoryectoCatedraPrograIII.Models.Evento", b =>
                {
                    b.Navigation("NegociosParticipantes");
                });

            modelBuilder.Entity("PoryectoCatedraPrograIII.Models.Producto", b =>
                {
                    b.Navigation("reviews");
                });

            modelBuilder.Entity("PoryectoCatedraPrograIII.Models.Tienda", b =>
                {
                    b.Navigation("EventosAsociados");

                    b.Navigation("Productos");

                    b.Navigation("Servicios");
                });

            modelBuilder.Entity("PoryectoCatedraPrograIII.Models.Usuario", b =>
                {
                    b.Navigation("Favoritos");

                    b.Navigation("HistorialBusquedas");

                    b.Navigation("reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
