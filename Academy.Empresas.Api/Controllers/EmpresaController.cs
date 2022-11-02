using Academy.Empresas.Domain.Contracts.Empresa;
using Academy.Empresas.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Empresas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : Controller
    {
        private readonly IEmpresaService _empresaService;

        //Respostas de informação (100-199),
        //Respostas de sucesso (200-299),
        //Redirecionamentos (300-399)
        //Erros do cliente (400-499)
        //Erros do servidor (500-599).

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpPost]
        public async Task<EmpresaResponse> Post(EmpresaRequest empresaRequest)
        {
            return await _empresaService.Post(empresaRequest);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<EmpresaResponse>> Get()
        {
            return await _empresaService.Get();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<EmpresaResponse> GetById(int id)
        {
            return await _empresaService.GetById(id);
        }

        [HttpPut("{id}")]
        public async Task<EmpresaResponse> Put(int id, EmpresaRequest empresaRequest)
        {
            return await _empresaService.Put(empresaRequest, id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _empresaService.Delete(id);
        }
    }
}