using Academy.Empresas.Domain.Entities;

namespace Academy.Empresas.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IBaseCRUD<UsuarioEntity, UsuarioEntity>
    {
        Task Delete(UsuarioEntity request);
        Task<UsuarioEntity> GetByEmail(string email);
    }
}