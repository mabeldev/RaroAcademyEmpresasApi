using Academy.Empresas.Domain.Contracts.Usuario;
using Academy.Empresas.Domain.Interfaces.Service;

namespace Academy.Empresas.Service
{
    public class UsuarioService : IUsuarioService
    {
        public Task Delete(int request)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioResponse>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioResponse> Post(UsuarioCadastroRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioResponse> Post(UsuarioRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioResponse> Put(UsuarioRequest request, int? id)
        {
            throw new NotImplementedException();
        }
    }
}