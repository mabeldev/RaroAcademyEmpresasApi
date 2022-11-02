using Academy.Empresas.Domain.Contracts.Endereco;

namespace Academy.Empresas.Domain.Entities
{
    public class EmpresaEntity : BaseEntity
    {
        public string? Nome { get; set; }
        public string NomeFantasia { get; set; }
        
        //FK
        public int EnderecoId { get; set; }
        public EnderecoEntity Endereco { get; set; }
    }
}