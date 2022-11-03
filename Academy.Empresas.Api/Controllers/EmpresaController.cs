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
        
        /// <summary>
        /// Através dessa rota você será capaz de criar a sua empresa no banco de dados.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna uma lista de elementos</response>
        [HttpPost]
        public async Task<EmpresaResponse> Post(EmpresaRequest empresaRequest)
        {
            return await _empresaService.Post(empresaRequest);
        }

        /// <summary>
        /// Através dessa rota você será capaz de buscar as empresas do banco de dados.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna uma lista de elementos</response>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<EmpresaResponse>> Get()
        {
            return await _empresaService.Get();
        }

        /// <summary>
        /// Através dessa rota você será capaz de buscar a empresa por Id no banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna um elemento</response>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<EmpresaResponse> GetById(int id)
        {
            return await _empresaService.GetById(id);
        }

        /// <summary>
        /// Através dessa rota você será capaz de alterar informações da empresa no banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna algumas informações do elemento</response>
        [HttpPut("{id}")]
        public async Task<EmpresaResponse> Put(int id, EmpresaRequest empresaRequest)
        {
            return await _empresaService.Put(empresaRequest, id);
        }

        /// <summary>
        /// Através dessa rota você será capaz de deletar uma empresa no banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Sucesso</response>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _empresaService.Delete(id);
        }
    }
}