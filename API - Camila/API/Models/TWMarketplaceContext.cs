using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models
{
    public partial class TWMarketplaceContext : DbContext
    {
        public TWMarketplaceContext()
        {
        }

        public TWMarketplaceContext(DbContextOptions<TWMarketplaceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Interesse> Interesse { get; set; }
        public virtual DbSet<Permissao> Permissao { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-CJ1NQH4\\SQLEXPRESS;Database=TWMarketplace;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__CD54BC5AB7C81DBC");

                entity.Property(e => e.CategoriaProduto).IsUnicode(false);
            });

            modelBuilder.Entity<Interesse>(entity =>
            {
                entity.HasKey(e => e.IdInteresse)
                    .HasName("PK__Interess__9AA7BC1AA4CC1F1E");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Interesse)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__Interesse__id_pr__440B1D61");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Interesse)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Interesse__id_us__4316F928");
            });

            modelBuilder.Entity<Permissao>(entity =>
            {
                entity.HasKey(e => e.IdPermissao)
                    .HasName("PK__Permissa__F9E467D57D4B7C8B");

                entity.Property(e => e.TipoUsuario).IsUnicode(false);
            });

            modelBuilder.Entity<Produtos>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK__Produtos__BA38A6B867840BC0");

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Produtos__id_cat__3F466844");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__4E3E04AD1676CC8E");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__AB6E61640513DC99")
                    .IsUnique();

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Senha).IsUnicode(false);

                entity.HasOne(d => d.IdPermissaoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdPermissao)
                    .HasConstraintName("FK__Usuario__id_perm__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
