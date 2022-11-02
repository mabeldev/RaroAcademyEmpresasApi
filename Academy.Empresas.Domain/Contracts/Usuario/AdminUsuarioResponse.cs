using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academy.Empresas.Domain.Contracts.Endereco;

namespace Academy.Empresas.Domain.Contracts.Usuario
{
    public class AdminUsuarioResponse
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public EnderecoResponse Endereco { get; set; }
        public string Cpf {get; set; }
    }
}