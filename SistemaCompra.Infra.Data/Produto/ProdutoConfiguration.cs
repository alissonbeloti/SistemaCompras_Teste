using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using System;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;

namespace SistemaCompra.Infra.Data.Produto
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<ProdutoAgg.Produto>
    {
        public void Configure(EntityTypeBuilder<ProdutoAgg.Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).IsRequired().HasColumnType("uniqueidentifier").HasDefaultValueSql("NEWID()");
            builder.Property(c => c.Categoria).IsRequired().HasConversion(v => v, v => (Categoria)Enum.Parse(typeof(Categoria), v.ToString()));
            builder.Property(c => c.Descricao).HasColumnType("varchar(MAX)");
            builder.Property(c => c.Nome).HasColumnType("varchar(MAX)");
            builder.Property(c => c.Preco).IsRequired().HasColumnType("decimal(10,2)").HasConversion(v => v.Value, v => new Money(v));
            builder.Property(c => c.Situacao).IsRequired().HasConversion(v => v, v => (Situacao)Enum.Parse(typeof(Situacao), v.ToString()));
        }
    }
}
