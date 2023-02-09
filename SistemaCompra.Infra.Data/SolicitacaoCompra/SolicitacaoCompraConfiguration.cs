using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraConfiguration : IEntityTypeConfiguration<SolicitacaoCompraAgg.SolicitacaoCompra>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoCompraAgg.SolicitacaoCompra> builder)
        {
            builder.ToTable("SolicitacaoCompra");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).IsRequired().HasColumnType("uniqueidentifier").HasDefaultValueSql("NEWID()");
            builder.Property(c => c.Data).IsRequired().HasColumnType("datetime");
            builder.Property(c => c.Situacao).IsRequired().HasConversion(v => v, v => (Situacao)Enum.Parse(typeof(Situacao), v.ToString()));
            builder.Property(c => c.CondicaoPagamento).IsRequired().HasColumnType("int").HasConversion(v => v.Valor, v => new CondicaoPagamento(v));
            builder.Property(c => c.NomeFornecedor).IsRequired().HasColumnType("varchar(MAX)").HasConversion(v => v.Nome, v => new NomeFornecedor(v));
            builder.Property(c => c.UsuarioSolicitante).IsRequired().HasColumnType("varchar(MAX)").HasConversion(v => v.Nome, v => new UsuarioSolicitante(v));
            builder.Property(c => c.TotalGeral).IsRequired().HasColumnType("decimal(10,2)").HasConversion(v => v.Value, v => new Money(v));
        }
    }
}
