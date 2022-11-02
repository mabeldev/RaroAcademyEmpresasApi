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

        [HttpPost]
        public async Task<UsuarioResponse> Post(UsuarioCadastroRequest usuarioRequest)
        {
            return await _usuarioService.Post(usuarioRequest);
        }

        [HttpGet]
        [Authorize(Roles = "Cliente")]
        public async Task<IEnumerable<UsuarioResponse>> Get()
        {
            return await _usuarioService.Get();
        }

        [HttpGet("Admin")]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<AdminUsuarioResponse>> AdminGet()
        {
            return await _usuarioService.AdminGet();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Cliente")]
        public async Task<UsuarioResponse> GetById(int id)
        {
            return await _usuarioService.GetById(id);
        }

        [HttpPut("{id}")]
        public async Task<UsuarioResponse> Put(int id, UsuarioRequest usuarioRequest)
        {
            return await _usuarioService.Put(usuarioRequest, id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _usuarioService.Delete(id);
        }
    }
}