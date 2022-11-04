using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academy.Empresas.Domain.Contracts.Endereco
{
    public class EnderecoResponse
    {
        public int Id { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}