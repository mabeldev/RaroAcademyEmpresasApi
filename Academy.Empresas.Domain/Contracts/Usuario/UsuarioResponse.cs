using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academy.Empresas.Domain.Contracts.Usuario
{
    public class UsuarioResponse
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}