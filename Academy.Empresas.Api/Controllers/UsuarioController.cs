using Academy.Empresas.Domain.Contracts.Usuario;
using Academy.Empresas.Domain.Enum;
using Academy.Empresas.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Empresas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        //Respostas de informação (100-199),
        //Respostas de sucesso (200-299),
        //Redirecionamentos (300-399)
        //Erros do cliente (400-499)
        //Erros do servidor (500-599).

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        
        /// <summary>
        /// Através dessa rota você será capaz de se cadastrar na API.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna uma parte de suas informações cadastradas</response>
        [HttpPost]
        public async Task<UsuarioResponse> Post(UsuarioCadastroRequest usuarioRequest)
        {
            return await _usuarioService.Post(usuarioRequest);
        }

        /// <summary>
        /// Através dessa rota você será capaz de buscar, caso você seja um cliente, a lista de usuarios disponíveis no banco.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna uma lista de elementos</response>
        [HttpGet]
        [Authorize(Roles = "Cliente")]
        public async Task<IEnumerable<UsuarioResponse>> Get()
        {
            return await _usuarioService.Get();
        }

        /// <summary>
        /// Através dessa rota você será capaz de buscar, caso você seja um cliente, a lista de usuarios disponíveis no banco, incluindo CPF.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna uma lista de elementos</response>
        [HttpGet("Admin")]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<AdminUsuarioResponse>> AdminGet()
        {
            return await _usuarioService.AdminGet();
        }

        /// <summary>
        /// Através dessa rota você será capaz de buscar um usuário pelo Id do mesmo.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna um elemento</response>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Cliente")]
        public async Task<UsuarioResponse> GetById(int id)
        {
            return await _usuarioService.GetById(id);
        }

        /// <summary>
        /// Através dessa rota você será capaz de atualizar os dados de um usuário.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna algumas informações do elemento</response>
        [HttpPut("{id}")]
        public async Task<UsuarioResponse> Put(int id, UsuarioRequest usuarioRequest)
        {
            return await _usuarioService.Put(usuarioRequest, id);
        }

        /// <summary>
        /// Através dessa rota você será capaz de deletar um usuário.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Sucesso</response>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _usuarioService.Delete(id);
        }
    }
}