using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }
        public IList<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }
        public Money TotalGeral { get; private set; }
        public Situacao Situacao { get; private set; }
        public CondicaoPagamento CondicaoPagamento { get; private set; }

        private SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;

            Itens = new List<Item>();
        }

        public void AdicionarItem(Produto produto, int quantidade)
        {
            if (produto == null) throw new BusinessRuleException("Produto inválido.");

            if (quantidade <= 0) throw new BusinessRuleException("Quantidade deve ser maior que zero.");

            Itens.Add(new Item(produto, quantidade));
        }

        public void RegistrarCompra(IEnumerable<Item> itens)
        {
            if (!itens.Any()) throw new BusinessRuleException("A compra deve possuir itens.");

            var total = itens.Sum(s => (s.Qtde * s.Produto.Preco.Value));

            TotalGeral = new Money(total);

            if (total >= 50000)
            {
                CondicaoPagamento = new CondicaoPagamento(30);
            }
            else
            {
                CondicaoPagamento = new CondicaoPagamento(0);
            }
        }
    }
}
