using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SernaSistemas.Jadet.Data.Models
{
    public partial class BDJadetContext : DbContext
    {
        public BDJadetContext()
        {
        }

        public BDJadetContext(string connStr): base(GetOptions(connStr))
        {

        }

        public BDJadetContext(DbContextOptions<BDJadetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Catalogo> Catalogos { get; set; }
        public virtual DbSet<Detalle> Detalles { get; set; }
        public virtual DbSet<Estatus> Estatuses { get; set; }
        public virtual DbSet<Nota> Notas { get; set; }
        public virtual DbSet<NotasComentario> NotasComentarios { get; set; }
        public virtual DbSet<NotasTicket> NotasTickets { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<TipoCatalogo> TipoCatalogos { get; set; }
        public virtual DbSet<TipoEstatus> TipoEstatuses { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=BDJadet; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Catalogo>(entity =>
            {
                entity.ToTable("Catalogo", "Administracion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoCatalogoNavigation)
                    .WithMany(p => p.Catalogos)
                    .HasForeignKey(d => d.IdTipoCatalogo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TipoCatalogo_Catalogo");
            });

            modelBuilder.Entity<Detalle>(entity =>
            {
                entity.ToTable("Detalle", "Ventas");

                entity.Property(e => e.PrecioMxn)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("PrecioMXN");

                entity.Property(e => e.PrecioUsd)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("PrecioUSD");

                entity.HasOne(d => d.IdNotaNavigation)
                    .WithMany(p => p.Detalles)
                    .HasForeignKey(d => d.IdNota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Nota_Detalle");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Detalles)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Producto_Detalle");
            });

            modelBuilder.Entity<Estatus>(entity =>
            {
                entity.ToTable("Estatus", "Administracion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoEstatusNavigation)
                    .WithMany(p => p.Estatuses)
                    .HasForeignKey(d => d.IdTipoEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tipoEstatus_Estatus");
            });

            modelBuilder.Entity<Nota>(entity =>
            {
                entity.HasKey(e => e.Folio)
                    .HasName("PK__Notas__BAB84EF6A836E3AB");

                entity.ToTable("Notas", "Ventas");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.FechaEnvio).HasColumnType("date");

                entity.Property(e => e.Guia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MontoMxn)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("MontoMXN");

                entity.Property(e => e.MontoUsd)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("MontoUSD");

                entity.Property(e => e.SaldoMxn)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("SaldoMXN");

                entity.Property(e => e.SaldoUsd)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("SaldoUSD");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuario_Notas");

                entity.HasOne(d => d.IdEstatusNavigation)
                    .WithMany(p => p.NotaIdEstatusNavigations)
                    .HasForeignKey(d => d.IdEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Catalogo_Notas_Estatus");

                entity.HasOne(d => d.IdPaqueteriaNavigation)
                    .WithMany(p => p.NotaIdPaqueteriaNavigations)
                    .HasForeignKey(d => d.IdPaqueteria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Catalogo_Notas_Paqueteria");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.NotaIdTipoNavigations)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Catalogo_Notas_Tipo");
            });

            modelBuilder.Entity<NotasComentario>(entity =>
            {
                entity.ToTable("NotasComentarios", "Ventas");

                entity.Property(e => e.Comentario).HasColumnType("text");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.IdNotaNavigation)
                    .WithMany(p => p.NotasComentarios)
                    .HasForeignKey(d => d.IdNota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Nota_Comentario");
            });

            modelBuilder.Entity<NotasTicket>(entity =>
            {
                entity.ToTable("NotasTickets", "Ventas");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.MontoMxn)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("MontoMXN");

                entity.Property(e => e.MontoUsd)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("MontoUSD");

                entity.HasOne(d => d.IdNotaNavigation)
                    .WithMany(p => p.NotasTickets)
                    .HasForeignKey(d => d.IdNota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Nota_Ticket");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto", "Ventas");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioMxn)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("PrecioMXN");

                entity.Property(e => e.PrecioUsd)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("PrecioUSD");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("sku");

                entity.HasOne(d => d.IdCatalogoNavigation)
                    .WithMany(p => p.ProductoIdCatalogoNavigations)
                    .HasForeignKey(d => d.IdCatalogo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Catalogo_Producto");

                entity.HasOne(d => d.IdEstatusNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Estatus_producto");

                entity.HasOne(d => d.IdTipoNotaNavigation)
                    .WithMany(p => p.ProductoIdTipoNotaNavigations)
                    .HasForeignKey(d => d.IdTipoNota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TipoNota_Producto");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol", "Seguridad");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoCatalogo>(entity =>
            {
                entity.ToTable("TipoCatalogo", "Administracion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoEstatus>(entity =>
            {
                entity.ToTable("TipoEstatus", "Administracion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario", "Seguridad");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Passwd).IsRequired();

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario");

                entity.HasOne(d => d.IdEstatusNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Estatus_usuario");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rol_usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        private static DbContextOptions GetOptions(string connStr)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connStr).Options;
        }
    }
}
