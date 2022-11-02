using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academy.Empresas.Domain.Interfaces.Service;

namespace Academy.Empresas.Service
{
    public class AutenticacaoService : IAutenticacaoService
    {
        public Task<string> Login(string usuario, string senha)
        {
            throw new NotImplementedException();
        }
    }
}