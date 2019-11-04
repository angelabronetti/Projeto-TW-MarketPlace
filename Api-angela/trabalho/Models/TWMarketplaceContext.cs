using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace trabalho.Models
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
        public virtual DbSet<Situacao> Situacao { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=TWMarketplace;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__CD54BC5A8B18910A");

                entity.Property(e => e.CategoriaProduto).IsUnicode(false);
            });

            modelBuilder.Entity<Interesse>(entity =>
            {
                entity.HasKey(e => e.IdInteresse)
                    .HasName("PK__Interess__9AA7BC1A65CD7B04");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Interesse)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__Interesse__id_pr__45F365D3");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Interesse)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Interesse__id_us__44FF419A");
            });

            modelBuilder.Entity<Permissao>(entity =>
            {
                entity.HasKey(e => e.IdPermissao)
                    .HasName("PK__Permissa__F9E467D55968E8C8");

                entity.Property(e => e.TipoUsuario).IsUnicode(false);
            });

            modelBuilder.Entity<Produtos>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK__Produtos__BA38A6B831A59750");

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Produtos__id_cat__412EB0B6");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacao)
                    .HasName("PK__Situacao__6EC302317F1AB030");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__4E3E04AD999F0000");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__AB6E6164B0978E92")
                    .IsUnique();

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Senha).IsUnicode(false);

                entity.HasOne(d => d.IdPermissaoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdPermissao)
                    .HasConstraintName("FK__Usuario__id_perm__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
