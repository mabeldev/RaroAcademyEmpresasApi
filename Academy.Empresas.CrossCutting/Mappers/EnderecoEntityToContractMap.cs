using Academy.Empresas.Domain.Contracts.Endereco;
using Academy.Empresas.Domain.Entities;
using AutoMapper;

namespace Academy.Empresas.CrossCutting.Mappers
{
    public class EnderecoEntityToContractMap : Profile
    {
        public EnderecoEntityToContractMap()
        {
            CreateMap<EnderecoEntity, EnderecoRequest>().ReverseMap();
            CreateMap<EnderecoEntity, EnderecoResponse>().ReverseMap();
        }
    }
}