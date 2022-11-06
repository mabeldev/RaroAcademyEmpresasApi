using Academy.Empresas.Domain.Interfaces.Service;
using Academy.Empresas.Domain.Interfaces.Repository;
using Academy.Empresas.Domain.Shared;

namespace Academy.Empresas.Service
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AutenticacaoService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<string> Login(string email, string senha)
        {
            var result = await _usuarioRepository.GetByEmail(email);

            var _senhaCriptografada = Cryptography.Encrypt(senha);

            if (result == null)
            {
                throw new ArgumentException("Este email não está cadastrado!");
            }
            if (_senhaCriptografada != result.Senha)
            {
                throw new ArgumentException("Senha incompatível com a cadastrada!");
            }

            return Token.GenerateToken(result);
        }
    }
}