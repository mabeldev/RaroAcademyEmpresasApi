using Academy.Empresas.Domain.Contracts.Endereco;
using Academy.Empresas.Domain.Enum;

namespace Academy.Empresas.Domain.Contracts.Usuario
{
    public class UsuarioRequest
    {
        public string Nome { get; set; }
        public string? Telefone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public RoleEnum Role { get; set; }
        public string DataDeNascimento { get; set; }
        public EnderecoRequest Endereco { get; set; }
    }
}