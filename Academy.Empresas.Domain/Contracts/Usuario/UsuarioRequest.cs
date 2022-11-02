
using Academy.Empresas.Domain.Contracts.Endereco;

namespace Academy.Empresas.Domain.Contracts.Usuario
{
    public class UsuarioRequest
    {
        public string Nome { get; set; }
        public string? Telefone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public EnderecoRequest Endereco { get; set; }
    }
}