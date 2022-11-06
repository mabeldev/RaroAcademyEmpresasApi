using Academy.Empresas.Domain.Contracts.Endereco;
using Academy.Empresas.Domain.Entities;
using Bogus;

namespace Academy.Empresas.Testes.Fakers.EnderecoFaker
{
    public static class EnderecoFaker
    {
        private static readonly Faker Fake = new Faker();

        public static EnderecoRequest EnderecoRequest()
        {
            return new EnderecoRequest()
            {
                Rua = Fake.Address.StreetName(),
                Bairro = Fake.Address.City(),
                Cep = Fake.Address.ZipCode("#########"),
                Cidade = Fake.Address.City(),
                Estado = Fake.Address.State(),
                Numero = Fake.Random.Int(1,999).ToString()
            };
        }
        public static EnderecoEntity EnderecoEntity()
        {
            return new EnderecoEntity()
            {
                Id = Fake.IndexFaker,
                Rua = Fake.Address.StreetName(),
                Bairro = Fake.Address.City(),
                Cep = Fake.Address.ZipCode("#########"),
                Cidade = Fake.Address.City(),
                Estado = Fake.Address.State(),
                Numero = Fake.Random.Int(1,999).ToString()
            };
        }
    }
}