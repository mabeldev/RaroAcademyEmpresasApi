using Academy.Empresas.Domain.Entities;
using Bogus.Extensions.Brazil;
using Bogus;

namespace Academy.Empresas.Testes.Fakers.Usuario
{
    public class UsuarioEntityFaker
    {
        private static readonly Faker Fake = new Faker();

        public static int GetId()
        {
            return Fake.IndexFaker;
        }

        public static async Task<IEnumerable<UsuarioEntity>> UsuarioEntityAsync()
        {
            var minhaLista = new List<UsuarioEntity>();

            for (int i = 0; i < 5; i++)
            {
                minhaLista.Add(new UsuarioEntity()
                {
                    Id = i,
                    Nome = Fake.Name.FirstName()
                });
            }

            return minhaLista;
        }

        public static async Task<UsuarioEntity> UsuarioEntityAsync(int id)
        {
            return new UsuarioEntity()
            {
                Id = id,
                Nome = Fake.Name.FirstName(),
                Telefone = Fake.Phone.PhoneNumber(),
                Email = Fake.Internet.Email(),
                CPF = Fake.Person.Cpf(),
                Role = Domain.Enum.RoleEnum.Admin,
                DataDeNascimento = Fake.Person.DateOfBirth.ToString(),
                Endereco = EnderecoFaker.EnderecoFaker.EnderecoEntity()
            };
        }

        public static UsuarioEntity UsuarioEntity()
        {
            return new UsuarioEntity
            {
                Id = Fake.IndexFaker,
                Nome = Fake.Name.FirstName(),
                Telefone = Fake.Phone.PhoneNumber(),
                Email = Fake.Internet.Email(),
                CPF = Fake.Person.Cpf(),
                Role = Domain.Enum.RoleEnum.Admin,
                DataDeNascimento = Fake.Person.DateOfBirth.ToString(),
                Endereco = EnderecoFaker.EnderecoFaker.EnderecoEntity()
            };
        }
    }
}