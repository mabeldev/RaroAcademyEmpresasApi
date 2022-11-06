using Academy.Empresas.Domain.Contracts.Endereco;
using Academy.Empresas.Domain.Enum;

namespace Academy.Empresas.Domain.Contracts.Usuario
{
    public class UsuarioResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Telefone { get; set; }
        public string Email { get; set; }
        public string DataDeNascimento { get; set; }
        public RoleEnum Role { get; set; }
        public EnderecoResponse Endereco { get; set; }
    }
}