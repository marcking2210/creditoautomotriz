using System;
using creditoautomotriz.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace creditoautomotriz.Infrastructure
{
    public partial class DbCreditoAutomotrizContext : DbContext
    {
        public DbCreditoAutomotrizContext()
        {
        }

        public DbCreditoAutomotrizContext(DbContextOptions<DbCreditoAutomotrizContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Ejecutivo> Ejecutivos { get; set; }
        public virtual DbSet<Patio> Patios { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<ClientePatio> ClientePatios { get; set; }
        public virtual DbSet<SolicitudCredito> SolicitudesCreditos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.ClienteId)
                    .HasName("Clientes_pkey");

                entity.Property(e => e.ClienteId).UseIdentityAlwaysColumn();

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ApellidosConyugue).HasMaxLength(20);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Edad)
                    .IsRequired();

                entity.Property(e => e.EstadoCivil)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime")
                    .IsRequired();

                entity.Property(e => e.Identificacion)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.IdentificacionConyugue).HasMaxLength(13);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.NombresConyugue).HasMaxLength(20);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.SujetoCredito)
                    .IsRequired();
            });

            modelBuilder.Entity<Patio>(entity =>
            {

                entity.HasKey(e => e.PatioId)
                    .HasName("Patios_pkey");

                entity.Property(e => e.PatioId).UseIdentityAlwaysColumn();

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NumeroPuntoVenta)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.VehiculoId)
                    .HasName("Vehiculos_pkey");

                entity.Property(e => e.VehiculoId).UseIdentityAlwaysColumn();

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NumeroChasis)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Tipo).HasMaxLength(50);

                entity.Property(e => e.Cilindraje)
                    .IsRequired();

                entity.Property(e => e.Avaluo)
                    .IsRequired();
            });

            modelBuilder.Entity<Ejecutivo>(entity =>
            {
                entity.HasKey(e => e.EjecutivoId)
                    .HasName("Ejecutivos_pkey");
                entity.Property(e => e.EjecutivoId).UseIdentityAlwaysColumn();

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Edad)
                    .IsRequired();

                entity.Property(e => e.Identificacion)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TelefonoCelular)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TelefonoConvencional).HasMaxLength(20);

                entity.HasOne(d => d.Patio)
                    .WithMany(p => p.Ejecutivos)
                    .HasForeignKey(d => d.PatioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Patios");
            });
            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.MarcaId)
                    .HasName("Marcas_pkey");
                entity.Property(e => e.MarcaId).UseIdentityAlwaysColumn();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ClientePatio>(entity =>
            {
                entity.ToTable("ClientePatio");

                entity.HasKey(e => e.ClientePatioId)
                    .HasName("ClientePatios_pkey");
                entity.Property(e => e.ClientePatioId).UseIdentityAlwaysColumn();

                entity.Property(e => e.FechaAsignacion).HasColumnType("date");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.ClientePatios)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Clientes_ClientePatio");

                entity.HasOne(d => d.Patio)
                    .WithMany(p => p.ClientePatios)
                    .HasForeignKey(d => d.PatioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Patio_ClientesPatio");
            });

            modelBuilder.Entity<SolicitudCredito>(entity =>
            {
                entity.ToTable("SolicitudesCredito");

                entity.HasKey(e => e.SolicitudCreditoId)
                    .HasName("SolicitudesCredito_pkey");

                entity.Property(e => e.SolicitudCreditoId).UseIdentityAlwaysColumn();

                entity.Property(e => e.MesesPlazo)
                   .IsRequired();

                entity.Property(e => e.ValorCuota)
                   .IsRequired();

                entity.Property(e => e.ValorEntrada)
                   .IsRequired();

                entity.Property(e => e.Estado).HasMaxLength(20);

                entity.Property(e => e.Observaciones).HasMaxLength(200);

                entity.HasOne(d => d.ClientePatio)
                    .WithMany(p => p.SolicitudesCreditos)
                    .HasForeignKey(d => d.ClientePatioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ClientePatio_SolicitudCredito");

                entity.HasOne(d => d.Ejecutivo)
                    .WithMany(p => p.SolicitudesCredito)
                    .HasForeignKey(d => d.EjecutivoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ejecutivos_SolicitudCredito");

                entity.HasOne(d => d.Vehiculo)
                   .WithMany(p => p.SolicitudesCredito)
                   .HasForeignKey(d => d.VehiculoId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("Vehiculos_SolicitudCredito");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
