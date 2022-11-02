using Academy.Empresas.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Empresas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoService _autenticacaoService;

        public AutenticacaoController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

        [HttpPost]
        public async Task<string> Login(string email, string senha)
        {
            return await _autenticacaoService.Login(email, senha);
        }
    }
}
