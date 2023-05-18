using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public partial class BrowserTravelTestContext : DbContext, IBrowserTravelTestContext
    {
        public BrowserTravelTestContext()
        {
        }

        public BrowserTravelTestContext(DbContextOptions<BrowserTravelTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autors { get; set; }
        public virtual DbSet<Editorial> Editorials { get; set; }
        public virtual DbSet<AutorLibro> AutorLibros { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.ToTable("Autor");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasMany(e => e.autorLibro)
                    .WithOne(e => e.Autor)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<AutorLibro>(entity =>
            {
                entity.ToTable("AutorLibro");
            });

            modelBuilder.Entity<Editorial>(entity =>
            {
                entity.ToTable("Editorial");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Sede)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.ToTable("Libro");

                entity.Property(e => e.NPaginas)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("n_paginas");

                entity.Property(e => e.Sinopsis).IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEditorialNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdEditorial)
                    .HasConstraintName("FK_Libro_Editorial");

                entity.HasMany(e => e.autorLibro)
                    .WithOne(e => e.Libro)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
