namespace Academy.Empresas.Domain.Entities
{
    public class EnderecoEntity : BaseEntity
    {
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Numero { get; set; }
    }
}