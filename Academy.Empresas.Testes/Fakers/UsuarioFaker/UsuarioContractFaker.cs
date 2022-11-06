using Academy.Empresas.Domain.Contracts.Usuario;
using Academy.Empresas.Domain.Shared;
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
                    Telefone = Fake.Phone.PhoneNumber("(31) 9####-####"),
                    Email = Fake.Internet.Email(),
                    DataDeNascimento = Fake.Person.DateOfBirth.ToShortDateString(),
                    Role = Domain.Enum.RoleEnum.Admin,
                    Endereco = EnderecoFaker.EnderecoFaker.EnderecoResponse()
                });
            }

            return minhaLista;
        }
        public static async Task<IEnumerable<AdminUsuarioResponse>> AdminUsuarioResponseAsync()
        {
            var minhaLista = new List<AdminUsuarioResponse>();

            for (int i = 0; i < 5; i++)
            {
                minhaLista.Add(new AdminUsuarioResponse()
                {
                    Id = i,
                    Nome = Fake.Name.FirstName(),
                    Telefone = Fake.Phone.PhoneNumber("(31) 9####-####"),
                    Email = Fake.Internet.Email(),
                    DataDeNascimento = Fake.Person.DateOfBirth.ToShortDateString(),
                    Role = Domain.Enum.RoleEnum.Admin,
                    Cpf = Fake.Person.Cpf(),
                    Endereco = EnderecoFaker.EnderecoFaker.EnderecoResponse()
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
                Telefone = Fake.Phone.PhoneNumber("(31) 9####-####"),
                Email = Fake.Internet.Email(),
                DataDeNascimento = Fake.Person.DateOfBirth.ToShortDateString(),
                Role = Domain.Enum.RoleEnum.Admin,
                Endereco = EnderecoFaker.EnderecoFaker.EnderecoResponse()
            };
        }

        public static UsuarioRequest UsuarioRequest()
        {
            return new UsuarioRequest
            {
                Nome = Fake.Name.FirstName(),
                Telefone = Fake.Phone.PhoneNumber(),
                Email = Fake.Internet.Email(),
                CPF = Fake.Person.Cpf(),
                Role = Domain.Enum.RoleEnum.Cliente,
                DataDeNascimento = Fake.Person.DateOfBirth.ToShortDateString(),
                Endereco = EnderecoFaker.EnderecoFaker.EnderecoRequest()
            };
        }
        public static UsuarioCadastroRequest UsuarioSenhaCriptografada(string senha)
        {
            return new UsuarioCadastroRequest
            {
                Nome = Fake.Name.FirstName(),
                Telefone = Fake.Phone.PhoneNumber("(31) 9####-####"),
                Email = Fake.Internet.Email(),
                Senha = Cryptography.Encrypt(senha),
                CPF = Fake.Person.Cpf(),
                Role = Domain.Enum.RoleEnum.Admin,
                DataDeNascimento = Fake.Person.DateOfBirth.ToShortDateString(),
                Endereco = EnderecoFaker.EnderecoFaker.EnderecoRequest()
            };
        }

        public static UsuarioCadastroRequest UsuarioCadastroRequest()
        {
            return new UsuarioCadastroRequest
            {
                Nome = Fake.Name.FirstName(),
                Telefone = Fake.Phone.PhoneNumber("(31) 9####-####"),
                Email = Fake.Internet.Email(),
                Senha = Fake.Internet.Password(8, true, "", "A@1a23"),
                CPF = Fake.Person.Cpf(),
                Role = Domain.Enum.RoleEnum.Admin,
                DataDeNascimento = Fake.Person.DateOfBirth.ToShortDateString(),
                Endereco = EnderecoFaker.EnderecoFaker.EnderecoRequest()
            };
        }

        public static async Task<UsuarioResponse> UsuarioResponseBaseRequestAsync(string nome)
        {
            return new UsuarioResponse()
            {
                Id = Fake.IndexFaker,
                Nome = nome,
                Email = Fake.Internet.Email(),
            };
        }
    }
}