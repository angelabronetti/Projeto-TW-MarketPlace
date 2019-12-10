using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Back_End_Completo.Models
{
    public partial class TWMPContext : DbContext
    {
        public TWMPContext()
        {
        }

        public TWMPContext(DbContextOptions<TWMPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<ImgProduto> ImgProduto { get; set; }
        public virtual DbSet<Interesse> Interesse { get; set; }
        public virtual DbSet<Permissao> Permissao { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=TWMP;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.TwmpIdCategoria)
                    .HasName("PK__Categori__527C56A6FD2C7ECD");

                entity.Property(e => e.TwmpCategoriaProduto).IsUnicode(false);
            });

            modelBuilder.Entity<ImgProduto>(entity =>
            {
                entity.HasKey(e => e.TwmpIdImgProduto)
                    .HasName("PK__ImgProdu__393DB5DEA8E1FCD3");

                entity.Property(e => e.TwmpCaminhoImg).IsUnicode(false);

                entity.Property(e => e.TwmpNome).IsUnicode(false);

                entity.HasOne(d => d.TwmpIdProdutoNavigation)
                    .WithMany(p => p.ImgProduto)
                    .HasForeignKey(d => d.TwmpIdProduto)
                    .HasConstraintName("FK__ImgProdut__twmp___48CFD27E");
            });

            modelBuilder.Entity<Interesse>(entity =>
            {
                entity.HasKey(e => e.TwmpIdInteresse)
                    .HasName("PK__Interess__30DAB16E0FDEB4AA");

                entity.Property(e => e.TwmpInteresseCompra).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.TwmpIdProdutoNavigation)
                    .WithMany(p => p.Interesse)
                    .HasForeignKey(d => d.TwmpIdProduto)
                    .HasConstraintName("FK__Interesse__twmp___440B1D61");

                entity.HasOne(d => d.TwmpIdUsuarioNavigation)
                    .WithMany(p => p.Interesse)
                    .HasForeignKey(d => d.TwmpIdUsuario)
                    .HasConstraintName("FK__Interesse__twmp___4316F928");
            });

            modelBuilder.Entity<Permissao>(entity =>
            {
                entity.HasKey(e => e.TwmpIdPermissao)
                    .HasName("PK__Permissa__1D7F1FC194BF7442");

                entity.Property(e => e.TwmpTipoUsuario).IsUnicode(false);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.TwmpIdProduto)
                    .HasName("PK__Produto__3D30968B7DD187FF");

                entity.Property(e => e.TwmpDescricao).IsUnicode(false);

                entity.Property(e => e.TwmpNome).IsUnicode(false);

                entity.HasOne(d => d.TwmpIdCategoriaNavigation)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.TwmpIdCategoria)
                    .HasConstraintName("FK__Produto__twmp_Id__3F466844");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.TwmpIdUsuario)
                    .HasName("PK__Usuario__5B239EAC65BAC3D2");

                entity.HasIndex(e => e.TwmpEmail)
                    .HasName("UQ__Usuario__6524A182D54A0EF9")
                    .IsUnique();

                entity.Property(e => e.TwmpEmail).IsUnicode(false);

                entity.Property(e => e.TwmpImgUsuario).IsUnicode(false);

                entity.Property(e => e.TwmpNome).IsUnicode(false);

                entity.Property(e => e.TwmpSenha).IsUnicode(false);

                entity.HasOne(d => d.TwmpIdPermissaoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.TwmpIdPermissao)
                    .HasConstraintName("FK__Usuario__twmp_Id__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
