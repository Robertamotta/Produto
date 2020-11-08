using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Estoque.WebAPI.Models
{
    public partial class EstoqueInfrastruture_dbContext : DbContext
    {
        public EstoqueInfrastruture_dbContext()
        {
        }

        public EstoqueInfrastruture_dbContext(DbContextOptions<EstoqueInfrastruture_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Movimento> Movimento { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:estoque-infrastruture-db-server.database.windows.net,1433;Initial Catalog=Estoque.Infrastruture_db;Persist Security Info=False;User ID=treinamentormp;Password=Rmp251702;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.CodCategoria);

                entity.Property(e => e.CodCategoria).ValueGeneratedNever();

                entity.Property(e => e.DataAlteracao).HasColumnType("date");

                entity.Property(e => e.DataInclusao).HasColumnType("date");

                entity.Property(e => e.NomeCategoria)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Movimento>(entity =>
            {
                entity.HasKey(e => e.IdMovimento);

                entity.Property(e => e.IdMovimento).ValueGeneratedNever();

                entity.Property(e => e.DataEntrada).HasColumnType("date");

                entity.Property(e => e.DataSaida).HasColumnType("date");

                entity.HasOne(d => d.CodProdutoNavigation)
                    .WithMany(p => p.Movimento)
                    .HasForeignKey(d => d.CodProduto)
                    .HasConstraintName("FK_Movimento_Produto");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Movimento)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Movimento_Usuario");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.CodProduto)
                    .HasName("PK__Produto__F4C40A58AEA1A90F");

                entity.Property(e => e.CodProduto).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsFixedLength();

                entity.HasOne(d => d.CodCategoriaNavigation)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.CodCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produto_Categoria");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.DataAlteracao).HasColumnType("date");

                entity.Property(e => e.DataInclusao).HasColumnType("date");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsFixedLength();

                entity.Property(e => e.SenhaUsuario)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
