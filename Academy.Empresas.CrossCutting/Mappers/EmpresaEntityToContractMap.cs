using Academy.Empresas.Domain.Contracts.Empresa;
using Academy.Empresas.Domain.Entities;
using AutoMapper;

namespace Academy.Empresas.CrossCutting.Mappers
{
    public class EmpresaEntityToContractMap : Profile
    {
        public EmpresaEntityToContractMap()
        {
            CreateMap<EmpresaEntity, EmpresaRequest>().ReverseMap();
            CreateMap<EmpresaEntity, EmpresaResponse>().ReverseMap();
        }
    }
}