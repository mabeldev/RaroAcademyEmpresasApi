using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academy.Empresas.Domain.Contracts.Endereco;

namespace Academy.Empresas.Domain.Contracts.Usuario
{
    public class AdminUsuarioResponse : UsuarioResponse
    {
        public string Cpf {get; set; }
    }
}