using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Prueba_Automapper.Models
{
    public partial class biblosContext : DbContext
    {
        public biblosContext()
        {
        }

        public biblosContext(DbContextOptions<biblosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autore> Autores { get; set; }
        public virtual DbSet<Lectura> Lecturas { get; set; }
        public virtual DbSet<Mlib> Mlibs { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Url> Urls { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//              #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
              //  optionsBuilder.UseSqlServer("data source=tcp:biblos-mgm-bbdd.database.windows.net,1433;initial catalog=biblos;persist security info=True;user id=mgmartos;password=Trijaka14;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Autore>(entity =>
            {
                entity.HasKey(e => e.IdAutor);

                entity.Property(e => e.IdAutor).HasColumnName("idAutor");

                entity.Property(e => e.NombreAutor)
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Lectura>(entity =>
            {
                entity.HasKey(e => e.Titulo)
                    .HasName("PK__Lecturas__38FA640E4324FBA6");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .HasColumnName("titulo")
                    .IsFixedLength(true);

                entity.Property(e => e.Autor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("autor")
                    .IsFixedLength(true);

                entity.Property(e => e.Calificacion).HasColumnName("calificacion");

                entity.Property(e => e.Comentario)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("comentario")
                    .IsFixedLength(true);

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_Inicio");

                entity.Property(e => e.Paginas).HasColumnName("paginas");
            });

            modelBuilder.Entity<Mlib>(entity =>
            {
                entity.HasKey(e => e.IdLibro);

                entity.ToTable("mlib");

                entity.Property(e => e.IdLibro).HasColumnName("idLibro");

                entity.Property(e => e.Autor)
                    .HasMaxLength(50)
                    .HasColumnName("autor")
                    .IsFixedLength(true);

                entity.Property(e => e.Calificacion).HasColumnName("calificacion");

                entity.Property(e => e.Coleccion)
                    .HasMaxLength(25)
                    .HasColumnName("coleccion")
                    .IsFixedLength(true);

                entity.Property(e => e.Comentario)
                    .HasMaxLength(255)
                    .HasColumnName("comentario")
                    .IsFixedLength(true);

                entity.Property(e => e.Editorial)
                    .HasMaxLength(25)
                    .HasColumnName("editorial")
                    .IsFixedLength(true);

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.FechaPrestamo)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_prestamo");

                entity.Property(e => e.Numobras).HasColumnName("numobras");

                entity.Property(e => e.Origen)
                    .HasMaxLength(10)
                    .HasColumnName("origen")
                    .IsFixedLength(true);

                entity.Property(e => e.Paginas).HasColumnName("paginas");

                entity.Property(e => e.Prestamo)
                    .HasMaxLength(30)
                    .HasColumnName("prestamo")
                    .IsFixedLength(true);

                entity.Property(e => e.Tema)
                    .HasMaxLength(30)
                    .HasColumnName("tema")
                    .IsFixedLength(true);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .HasColumnName("titulo")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Url>(entity =>
            {
                entity.HasKey(e => new { e.Tipo, e.CodigoPadre, e.Direccion });

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CodigoPadre).HasColumnName("codigo_padre");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .HasColumnName("direccion");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("descripcion")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.EMail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("E_Mail");

                entity.Property(e => e.FechaAutorizado).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Password).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
