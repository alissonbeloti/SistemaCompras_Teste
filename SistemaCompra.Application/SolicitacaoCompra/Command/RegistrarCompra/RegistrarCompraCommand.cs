﻿using MediatR;
using SistemaCompra.Application.Produto.Query.ObterProduto;
using System;
using System.Collections.Generic;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        public string UsuarioSolicitante { get; set; }
        public string NomeFornecedor { get; set; }
        public IList<ItemCompraCommand> Itens { get; set; }
    }
}
