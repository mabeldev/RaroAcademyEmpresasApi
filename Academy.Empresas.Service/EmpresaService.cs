using Academy.Empresas.Domain.Contracts.Empresa;
using Academy.Empresas.Domain.Interfaces.Service;

namespace Academy.Empresas.Service
{
    public class EmpresaService : IEmpresaService
    {
        public Task Delete(int request)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmpresaResponse>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<EmpresaResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EmpresaResponse> Post(EmpresaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<EmpresaResponse> Put(EmpresaRequest request, int? id)
        {
            throw new NotImplementedException();
        }
    }
}