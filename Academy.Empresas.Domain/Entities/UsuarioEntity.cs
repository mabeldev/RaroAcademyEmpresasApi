using Academy.Empresas.Domain.Enum;

namespace Academy.Empresas.Domain.Entities
{
    public class UsuarioEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string? Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string CPF { get; set; }
        public DateTime DataDeNascimento { get; set; }

        //Enum
        public RoleEnum Role { get; set; }

        //FK
        public int EnderecoId { get; set; }
        public EnderecoEntity Endereco { get; set; }
    }
}