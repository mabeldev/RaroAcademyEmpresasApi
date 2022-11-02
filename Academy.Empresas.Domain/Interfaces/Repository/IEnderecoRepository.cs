using Academy.Empresas.Domain.Entities;

namespace Academy.Empresas.Domain.Interfaces.Repository
{
    public interface IEnderecoRepository : IBaseCRUD<EnderecoEntity, EnderecoEntity>
    {
        Task Delete(EnderecoEntity request);
    }
}