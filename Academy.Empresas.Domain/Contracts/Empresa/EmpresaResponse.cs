using Academy.Empresas.Domain.Contracts.Endereco;

namespace Academy.Empresas.Domain.Contracts.Empresa
{
    public class EmpresaResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public EnderecoResponse Endereco { get; set; }
    }
}