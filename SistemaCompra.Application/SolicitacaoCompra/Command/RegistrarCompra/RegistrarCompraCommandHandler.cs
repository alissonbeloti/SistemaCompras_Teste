using MediatR;
using SistemaCompra.Infra.Data.UoW;
using System;
using System.Threading;
using System.Threading.Tasks;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly SolicitacaoCompraAgg.ISolicitacaoCompraRepository _solicitacaoCompraRepository;
        private readonly ProdutoAgg.IProdutoRepository _produtoRepository;

        public RegistrarCompraCommandHandler(SolicitacaoCompraAgg.ISolicitacaoCompraRepository solicitacaoCompraRepository, ProdutoAgg.IProdutoRepository produtoRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            this._solicitacaoCompraRepository = solicitacaoCompraRepository;
            this._produtoRepository = produtoRepository;
        }

        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var solicitacaoCompra = new SolicitacaoCompraAgg.SolicitacaoCompra(request.UsuarioSolicitante, request.NomeFornecedor);

            if (request.Itens != null)
            {
                foreach(var t in request.Itens)
                {
                    solicitacaoCompra.AdicionarItem(this._produtoRepository.Obter(t.ProdutoId), t.Quantidade);
                }
            }

            solicitacaoCompra.RegistrarCompra(solicitacaoCompra.Itens);

            this._solicitacaoCompraRepository.RegistrarCompra(solicitacaoCompra);

            Commit();
            PublishEvents(solicitacaoCompra.Events);

            return Task.FromResult(true);
        }
    }
}

