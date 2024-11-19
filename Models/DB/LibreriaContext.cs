using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace App_Libreria.Models.DB
{
    public partial class LibreriaContext : DbContext
    {
        public LibreriaContext()
        {
        }

        public LibreriaContext(DbContextOptions<LibreriaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autors { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<LibAut> LibAuts { get; set; } = null!;
        public virtual DbSet<Libro> Libros { get; set; } = null!;
        public virtual DbSet<Prestamo> Prestamos { get; set; } = null!;
        public virtual DbSet<PrestamoView> PrestamoViews { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.IdAutor)
                    .HasName("PK__Autor__DD33B0318CB4D45F");

                entity.ToTable("Autor");

                entity.HasIndex(e => e.NombreAutor, "IndexAutorNombre");

                entity.Property(e => e.Nacionalidad)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreAutor)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante)
                    .HasName("PK__Estudian__B5007C244375B5A8");

                entity.ToTable("Estudiante");

                entity.Property(e => e.Carrera)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ci)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CI");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreEstudiante)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LibAut>(entity =>
            {
                entity.HasKey(e => e.IdLibAut)
                    .HasName("PK__LibAut__29BA92CF3584F2CD");

                entity.ToTable("LibAut");

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany(p => p.LibAuts)
                    .HasForeignKey(d => d.IdAutor)
                    .HasConstraintName("FK_LibAut_Autor");

                entity.HasOne(d => d.IdLibroNavigation)
                    .WithMany(p => p.LibAuts)
                    .HasForeignKey(d => d.IdLibro)
                    .HasConstraintName("FK_LibAut_Libro");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.IdLibro)
                    .HasName("PK__Libro__3E0B49ADB327CB6C");

                entity.ToTable("Libro");

                entity.HasIndex(e => e.Titulo, "IndexLibroNombre");

                entity.Property(e => e.Area)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Editorial)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(e => e.IdPrestamo)
                    .HasName("PK__Prestamo__6FF194C09DF6709E");

                entity.ToTable("Prestamo");

                entity.Property(e => e.FechaDevolucion).HasColumnType("date");

                entity.Property(e => e.FechaPrestamo).HasColumnType("date");

                entity.HasOne(d => d.IdLectorNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.IdLector)
                    .HasConstraintName("FK_Prestamo_Estudiante");

                entity.HasOne(d => d.IdLibroNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.IdLibro)
                    .HasConstraintName("FK_Prestamo_Libro");
            });

            modelBuilder.Entity<PrestamoView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PrestamoView");

                entity.Property(e => e.FechaDevolucion).HasColumnType("date");

                entity.Property(e => e.FechaPrestamo).HasColumnType("date");

                entity.Property(e => e.NombreAutor)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreEstudiante)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
