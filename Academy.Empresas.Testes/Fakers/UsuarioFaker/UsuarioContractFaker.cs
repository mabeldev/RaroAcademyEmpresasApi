using Academy.Empresas.Domain.Contracts.Usuario;
using Bogus;
using Bogus.Extensions.Brazil;

namespace Academy.Empresas.Testes.Fakers.UsuarioFaker
{
    public static class UsuarioContractFaker
    {
        private static readonly Faker Fake = new Faker();

        public static int GetId()
        {
            return Fake.IndexFaker;
        }

        public static async Task<IEnumerable<UsuarioResponse>> UsuarioResponseAsync()
        {
            var minhaLista = new List<UsuarioResponse>();

            for (int i = 0; i < 5; i++)
            {
                minhaLista.Add(new UsuarioResponse()
                {
                    Id = i,
                    Nome = Fake.Name.FirstName(),
                    Email = Fake.Internet.Email(),
                });
            }

            return minhaLista;
        }

        public static async Task<UsuarioResponse> UsuarioResponseAsync(int id)
        {
            return new UsuarioResponse()
            {
                Id = id,
                Nome = Fake.Name.FirstName(),
                Email = Fake.Internet.Email(),
            };
        }

        public static UsuarioRequest UsuarioRequest()
        {
            return new UsuarioRequest
            {
                Nome = Fake.Name.FirstName(),
                Telefone = Fake.Phone.PhoneNumber(),
                Email = Fake.Internet.Email(),
                Role = Domain.Enum.RoleEnum.Admin,
                DataDeNascimento = Fake.Person.DateOfBirth.ToString(),
                Endereco = EnderecoFaker.EnderecoFaker.EnderecoRequest()
            };
        }

        public static UsuarioRequest UsuarioAdminRequest()
        {
            return new UsuarioRequest
            {
                Nome = Fake.Name.FirstName(),
                Telefone = Fake.Phone.PhoneNumber(),
                Email = Fake.Internet.Email(),
                CPF = Fake.Person.Cpf(),
                Role = Domain.Enum.RoleEnum.Admin,
                DataDeNascimento = Fake.Person.DateOfBirth.ToString(),
                Endereco = EnderecoFaker.EnderecoFaker.EnderecoRequest()
            };
        }

        public static UsuarioCadastroRequest UsuarioCadastraRequest()
        {
            return new UsuarioCadastroRequest
            {
                Nome = Fake.Name.FirstName(),
                Telefone = Fake.Phone.PhoneNumber(),
                Email = Fake.Internet.Email(),
                Senha = Fake.Internet.Password(8, false, @"^(?=.[a-z])(?=.[A-Z])(?=.\d)(?=.[@$!%?&])[A-Za-z\d@$!%?&]{8,}$"),
                CPF = Fake.Person.Cpf(),
                Role = Domain.Enum.RoleEnum.Admin,
                DataDeNascimento = Fake.Person.DateOfBirth.ToString(),
                Endereco = EnderecoFaker.EnderecoFaker.EnderecoRequest()
            };
        }
    }
}