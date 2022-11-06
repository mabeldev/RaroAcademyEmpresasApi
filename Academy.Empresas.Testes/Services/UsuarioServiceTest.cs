using Academy.Empresas.Domain.Entities;
using Academy.Empresas.Domain.Interfaces.Repository;
using Academy.Empresas.Service;
using Academy.Empresas.Testes.CrossCutting;
using Academy.Empresas.Testes.Fakers.Usuario;
using Academy.Empresas.Testes.Fakers.UsuarioFaker;
using AutoMapper;
using Moq;

namespace Academy.Empresas.Testes.Services
{

    [Trait("Service", "Service de Usuario")]
    public class UsuarioServiceTest
    {
        private readonly Mock<IUsuarioRepository> _mockUsuarioRepository = new Mock<IUsuarioRepository>();
        public IMapper mapper = new AutoMapperFixture().GetMapper();

        [Fact(DisplayName = "Cadastra um novo usuario")]
        public async Task Post()
        {
            var userRequest = UsuarioContractFaker.UsuarioCadastroRequest();
            var userRequestEntity = UsuarioEntityFaker.UsuarioEntity();
            var resultUserRequest = UsuarioEntityFaker.UsuarioEntityBaseRequestAsync(userRequestEntity.Nome);

            _mockUsuarioRepository.Setup(mock => mock.Post(It.IsAny<UsuarioEntity>())).Returns(resultUserRequest);

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);

            var result = await service.Post(userRequest);

            Assert.Equal(result.Nome, resultUserRequest.Result.Nome);
        }

        [Fact(DisplayName = "Tenta cadastrar um novo usuario com Nome invalido")]
        public async Task PostNomeInvalido()
        {
            var user = UsuarioContractFaker.UsuarioCadastroRequest();
            user.Nome = "";

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);
            var excepction = await Assert.ThrowsAsync<ArgumentException>(() => service.Post(user));

            Assert.Equal("Nome de usuário inválido ou inexistente!", excepction.Message);
        }

        [Fact(DisplayName = "Tenta cadastrar um novo usuario com Cpf invalido")]
        public async Task PostCpfInvalido()
        {
            var user = UsuarioContractFaker.UsuarioCadastroRequest();
            user.CPF = "";

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);
            var excepction = await Assert.ThrowsAsync<ArgumentException>(() => service.Post(user));
            
            Assert.Equal("Cpf não corresponde a um cpf válido!", excepction.Message);
        }

        [Fact(DisplayName = "Tenta cadastrar um novo usuario com DataDeNascimento invalido")]
        public async Task PostDataDeNascimentoInvalido()
        {
            var user = UsuarioContractFaker.UsuarioCadastroRequest();
            user.DataDeNascimento = "";

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);
            var excepction = await Assert.ThrowsAsync<ArgumentException>(() => service.Post(user));
            
            Assert.Equal("Data está invalida!", excepction.Message);
        }

        [Fact(DisplayName = "Tenta cadastrar um novo usuario com Email Nulo")]
        public async Task PostEmailNulo()
        {
            var user = UsuarioContractFaker.UsuarioCadastroRequest();
            user.Email = "";

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);
            var excepction = await Assert.ThrowsAsync<ArgumentException>(() => service.Post(user));
            
            Assert.Equal("Email não pode ser nulo!", excepction.Message);
        }

        [Fact(DisplayName = "Tenta cadastrar um novo usuario com Email Invalido")]
        public async Task PostEmailInvalido()
        {
            var user = UsuarioContractFaker.UsuarioCadastroRequest();
            user.Email = "aaaaaa.aaa.231.514.";

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);
            var excepction = await Assert.ThrowsAsync<ArgumentException>(() => service.Post(user));
            
            Assert.Equal("Email não corresponde a um email válido!", excepction.Message);
        }

        [Fact(DisplayName = "Tenta cadastrar um novo usuario com Rua invalida")]
        public async Task PostEnderecoRuaInvalido()
        {
            var user = UsuarioContractFaker.UsuarioCadastroRequest();
            user.Endereco.Rua = "";

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);
            var excepction = await Assert.ThrowsAsync<ArgumentException>(() => service.Post(user));
            
            Assert.Equal("Rua não pode ser nulo", excepction.Message);
        }
        [Fact(DisplayName = "Tenta cadastrar um novo usuario com Bairro invalida")]
        public async Task PostEnderecoBairroInvalido()
        {
            var user = UsuarioContractFaker.UsuarioCadastroRequest();
            user.Endereco.Bairro = "";

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);
            var excepction = await Assert.ThrowsAsync<ArgumentException>(() => service.Post(user));
            
            Assert.Equal("Bairro não pode ser nulo", excepction.Message);
        }

        [Fact(DisplayName = "Tenta cadastrar um novo usuario com Cep invalida")]
        public async Task PostEnderecoCepInvalido()
        {
            var user = UsuarioContractFaker.UsuarioCadastroRequest();
            user.Endereco.Cep = "";

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);
            var excepction = await Assert.ThrowsAsync<ArgumentException>(() => service.Post(user));
            
            Assert.Equal("Cep não pode ser nulo", excepction.Message);
        }

        [Fact(DisplayName = "Tenta cadastrar um novo usuario com Cidade invalida")]
        public async Task PostEnderecoCidadeInvalido()
        {
            var user = UsuarioContractFaker.UsuarioCadastroRequest();
            user.Endereco.Cidade = "";

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);
            var excepction = await Assert.ThrowsAsync<ArgumentException>(() => service.Post(user));
            
            Assert.Equal("Cidade não pode ser nulo", excepction.Message);
        }

        [Fact(DisplayName = "Tenta cadastrar um novo usuario com Estado invalida")]
        public async Task PostEnderecoEstadoInvalido()
        {
            var user = UsuarioContractFaker.UsuarioCadastroRequest();
            user.Endereco.Estado = "";

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);
            var excepction = await Assert.ThrowsAsync<ArgumentException>(() => service.Post(user));
            
            Assert.Equal("Estado não pode ser nulo", excepction.Message);
        }

        [Fact(DisplayName = "Tenta cadastrar um novo usuario com Numero De Endereco invalida")]
        public async Task PostEnderecoNumeroEnderecoInvalido()
        {
            var user = UsuarioContractFaker.UsuarioCadastroRequest();
            user.Endereco.Numero = "";

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);
            var excepction = await Assert.ThrowsAsync<ArgumentException>(() => service.Post(user));
            
            Assert.Equal("Numero não pode ser nulo", excepction.Message);
        }
        [Fact(DisplayName = "Tenta cadastrar um novo usuario com Senha  invalida")]
        public async Task PostEnderecoSenhaInvalido()
        {
            var user = UsuarioContractFaker.UsuarioCadastroRequest();
            user.Senha = "aaaa";

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);
            var excepction = await Assert.ThrowsAsync<ArgumentException>(() => service.Post(user));
            
            Assert.Equal("Sua senha é muito fraca, necessário caracteres especiais, números e letras (Aa)", excepction.Message);
        }


        [Fact(DisplayName = "Lista todos os Usuarios")]
        public async Task Get()
        {
            _mockUsuarioRepository.Setup(mock => mock.Get()).Returns(UsuarioEntityFaker.UsuarioEntityAsync());

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);

            var result = await service.Get();

            Assert.True(result.ToList().Count() > 0);
        }
        [Fact(DisplayName = "Lista todos os Usuarios")]
        public async Task AdminGet()
        {
            _mockUsuarioRepository.Setup(mock => mock.Get()).Returns(UsuarioEntityFaker.UsuarioEntityAsync());

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);

            var result = await service.AdminGet();

            Assert.True(result.ToList().Count() > 0);
        }

        [Fact(DisplayName = "Busca um usuario por ID")]
        public async Task GetById()
        {
            int id = UsuarioEntityFaker.GetId();

            _mockUsuarioRepository.Setup(mock => mock.GetById(id)).Returns(UsuarioEntityFaker.UsuarioEntityAsync(id));

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);

            var result = await service.GetById(id);

            Assert.Equal(result.Id, id);
        }

        [Fact(DisplayName = "Edita um usuario já existente")]
        public async Task Put()
        {
            var userRequest = UsuarioContractFaker.UsuarioCadastroRequest();
            var userRequestEntity = UsuarioEntityFaker.UsuarioEntity();
            var resultUserRequest = UsuarioEntityFaker.UsuarioEntityBaseRequestAsync(userRequestEntity.Nome);

            _mockUsuarioRepository.Setup(mock => mock.GetById(It.IsAny<int>())).Returns(resultUserRequest);
            _mockUsuarioRepository.Setup(mock => mock.Put(It.IsAny<UsuarioEntity>(), It.IsAny<int?>())).Returns(resultUserRequest);

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);

            var result = await service.Put(userRequest, resultUserRequest.Result.Id);

            Assert.Equal(result.Nome, resultUserRequest.Result.Nome);

        }
        [Fact(DisplayName = "Remove um usuario já existente")]
        public async Task Delete()
        {
            int id = UsuarioEntityFaker.GetId();

            _mockUsuarioRepository.Setup(mock => mock.Delete(id)).Returns(() => Task.FromResult(string.Empty));

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);

            try
            {
                await service.Delete(id);
            }
            catch (System.Exception)
            {
                Assert.True(false);
            }
        }

    }
}