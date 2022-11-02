using Academy.Empresas.Domain.Contracts.Endereco;

namespace Academy.Empresas.Domain.Contracts.Empresa
{
    public class EmpresaRequest
    {
        public string? Nome { get; set; }
        public string NomeFantasia { get; set; }
        public EnderecoRequest Endereco { get; set; }
    }
}