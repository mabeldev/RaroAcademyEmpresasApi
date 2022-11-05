using Academy.Empresas.Domain.Contracts.Empresa;
using Bogus;

namespace Academy.Empresas.Testes.Fakers.EmpresaFaker
{
    public class EmpresaContractFaker
    {
        private static readonly Faker Fake = new Faker();

        public static int GetId()
        {
            return Fake.IndexFaker;
        }
        
        public static async Task<IEnumerable<EmpresaResponse>> EmpresaResponseAsync()
        {
            var minhaLista = new List<EmpresaResponse>();

            for (int i = 0; i < 5; i++)
            {
                minhaLista.Add(new EmpresaResponse()
                {
                    Id = i,
                    Nome = Fake.Name.FirstName(),
                    NomeFantasia = Fake.Name.FirstName()
                });
            }

            return minhaLista;
        }

        public static async Task<EmpresaResponse> EmpresaResponseAsync(int id)
        {
            return new EmpresaResponse()
            {
                Id = id,
                Nome = Fake.Name.FirstName(),
                NomeFantasia = Fake.Name.FirstName()
            };
        }

        public static EmpresaRequest EmpresaRequest()
        {
            return new EmpresaRequest
            {
                Nome = Fake.Name.FirstName(),
                NomeFantasia = Fake.Name.FirstName(),
                Endereco = EnderecoFaker.EnderecoFaker.EnderecoRequest()
            };
        }

        public static async Task<EmpresaResponse> EmpresaResponseBaseRequestAsync(string nome)
        {
            return new EmpresaResponse()
            {
                Id = Fake.IndexFaker,
                Nome = Fake.Name.FirstName(),
                NomeFantasia = nome,
            };
        }
    }
}