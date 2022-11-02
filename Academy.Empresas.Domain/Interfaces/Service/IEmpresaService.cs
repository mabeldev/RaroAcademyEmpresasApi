using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academy.Empresas.Domain.Contracts.Empresa;

namespace Academy.Empresas.Domain.Interfaces.Service
{
    public interface IEmpresaService : IBaseCRUD<EmpresaRequest, EmpresaResponse>
    {
        
    }
}