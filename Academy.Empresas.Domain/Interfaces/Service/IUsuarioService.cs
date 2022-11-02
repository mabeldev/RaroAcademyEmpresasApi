using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academy.Empresas.Domain.Contracts.Usuario;

namespace Academy.Empresas.Domain.Interfaces.Service
{
    public interface IUsuarioService : IBaseCRUD<UsuarioRequest, UsuarioResponse>
    {
        Task<UsuarioResponse> Post(UsuarioCadastroRequest request);
    }
}