using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academy.Empresas.Domain.Interfaces.Service
{
    public interface IAutenticacaoService
    {
        Task<string> Login(string usuario, string senha);
    }
}