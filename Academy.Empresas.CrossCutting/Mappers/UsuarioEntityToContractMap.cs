using Academy.Empresas.Domain.Contracts.Usuario;
using Academy.Empresas.Domain.Entities;
using AutoMapper;

namespace Academy.Empresas.CrossCutting.Mappers
{
    public class UsuarioEntityToContractMap : Profile
    {
        public UsuarioEntityToContractMap()
        {
            CreateMap<UsuarioEntity, UsuarioRequest>().ReverseMap();
            CreateMap<UsuarioEntity, UsuarioCadastroRequest>().ReverseMap();
            CreateMap<UsuarioEntity, UsuarioResponse>().ReverseMap();
            CreateMap<UsuarioEntity, AdminUsuarioResponse>().ReverseMap();
        }
    }
}