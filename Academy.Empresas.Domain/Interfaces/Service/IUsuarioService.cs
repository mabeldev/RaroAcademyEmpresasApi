using Academy.Empresas.Domain.Contracts.Usuario;

namespace Academy.Empresas.Domain.Interfaces.Service
{
    public interface IUsuarioService : IBaseCRUD<UsuarioRequest, UsuarioResponse>
    {
        Task<UsuarioResponse> Post(UsuarioCadastroRequest request);
        Task<UsuarioResponse> Put(UsuarioCadastroRequest usuarioRequest, int? id);
        Task<IEnumerable<AdminUsuarioResponse>> AdminGet();
    }
}