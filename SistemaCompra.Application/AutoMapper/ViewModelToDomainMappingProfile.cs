using AutoMapper;
using SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<SolicitacaoCompraAgg.Item, ItemCompraCommand>()
                .ForMember(d=> d.ProdutoId, o=> o.MapFrom(src=> src.Id))
                .ForMember(d => d.Quantidade, o => o.MapFrom(src => src.Qtde));
        }
    }
}
