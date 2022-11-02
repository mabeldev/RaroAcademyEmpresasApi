using Academy.Empresas.Domain.Entities;

namespace Academy.Empresas.Domain.Interfaces.Repository
{
    public interface IEmpresaRepository : IBaseCRUD<EmpresaEntity, EmpresaEntity>
    {
        Task Delete(EmpresaEntity request);
    }
}