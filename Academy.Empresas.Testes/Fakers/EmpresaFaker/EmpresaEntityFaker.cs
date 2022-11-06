using Academy.Empresas.Domain.Entities;
using Bogus;

namespace Academy.Empresas.Testes.Fakers.EmpresaFaker
{
    public class EmpresaEntityFaker
    {
        private static readonly Faker Fake = new Faker();

        public static int GetId()
        {
            return Fake.IndexFaker;
        }

        public static async Task<IEnumerable<EmpresaEntity>> EmpresaEntityAsync()
        {
            var minhaLista = new List<EmpresaEntity>();

            for (int i = 0; i < 5; i++)
            {
                minhaLista.Add(new EmpresaEntity()
                {
                    Id = i,
                    Nome = Fake.Name.FirstName()
                });
            }

            return minhaLista;
        }

        public static async Task<EmpresaEntity> EmpresaEntityAsync(int id)
        {
            return new EmpresaEntity()
            {
                Id = id,
                Nome = Fake.Name.FirstName(),
                NomeFantasia = Fake.Name.FirstName(),
                Endereco = EnderecoFaker.EnderecoFaker.EnderecoEntity()
            };
        }
        public static EmpresaEntity EmpresaEntity()
        {
            return new EmpresaEntity
            {
                Id = Fake.IndexFaker,
                Nome = Fake.Name.FirstName(),
                NomeFantasia = Fake.Name.FirstName(),
                Endereco = EnderecoFaker.EnderecoFaker.EnderecoEntity()
            };
        }
        public static async Task<EmpresaEntity> EmpresaEntityBaseRequestAsync(string nome)
        {
            return new EmpresaEntity()
            {
                Id = Fake.IndexFaker,
                Nome = nome,
                NomeFantasia = Fake.Name.FirstName(),
                Endereco = EnderecoFaker.EnderecoFaker.EnderecoEntity()
            };
        }
    }
}