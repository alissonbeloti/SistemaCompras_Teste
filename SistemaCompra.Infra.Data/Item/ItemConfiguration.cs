using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.Item
{
    public class ItemConfiguration : IEntityTypeConfiguration<SolicitacaoCompraAgg.Item>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoCompraAgg.Item> builder)
        {
            builder.ToTable("Item");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).IsRequired().HasColumnType("uniqueidentifier");
            builder.Property(c => c.Produto).IsRequired().HasColumnName("ProdutoId").HasColumnType("uniqueidentifier").HasConversion(v => v.Id, v => new ProdutoAgg.Produto(v));
            builder.Property(c => c.Qtde).IsRequired().HasColumnType("int");
        }
    }
}
