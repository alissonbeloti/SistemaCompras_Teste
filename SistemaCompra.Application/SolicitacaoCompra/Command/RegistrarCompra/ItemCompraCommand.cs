using System;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class ItemCompraCommand
    {
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
