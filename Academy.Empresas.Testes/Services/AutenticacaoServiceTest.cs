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
    [Trait("Service", "Service de Autenticacao")]
    public class AutenticacaoServiceTest
    {
        private readonly Mock<IUsuarioRepository> _mockUsuarioRepository = new Mock<IUsuarioRepository>();
        public IMapper mapper = new AutoMapperFixture().GetMapper();
        
        [Fact(DisplayName = "Tenta Logar")]
        public async Task Login()
        {
            string senha = "Senha@1234";
            var user = UsuarioContractFaker.UsuarioCadastroRequest();
            user.Senha = senha;
            
            var service = new AutenticacaoService(_mockUsuarioRepository.Object);
            _mockUsuarioRepository.Setup(mock => mock.GetByEmail(user.Email)).ReturnsAsync(UsuarioEntityFaker.UsuarioEntityCiptSenha(senha));

            var result = await service.Login(user.Email, user.Senha);

            Assert.True(result.Any());
        }

        [Fact(DisplayName = "Tenta Logar Com email não cadastrado")]
        public async Task LoginComEmailInvalido()
        {
            var user = UsuarioContractFaker.UsuarioCadastroRequest();
            
            var service = new AutenticacaoService(_mockUsuarioRepository.Object);
            _mockUsuarioRepository.Setup(mock => mock.GetByEmail(user.Email)).ReturnsAsync((UsuarioEntity)null);


            var excepction = await Assert.ThrowsAsync<ArgumentException>(() => service.Login(user.Email, user.Senha));

            Assert.Equal("Este email não está cadastrado!", excepction.Message);
        }
        [Fact(DisplayName = "Tenta Logar Com email não cadastrado")]
        public async Task LoginComSenhaIncompativel()
        {
            var user = UsuarioContractFaker.UsuarioCadastroRequest();
            
            var service = new AutenticacaoService(_mockUsuarioRepository.Object);
            _mockUsuarioRepository.Setup(mock => mock.GetByEmail(user.Email)).ReturnsAsync(UsuarioEntityFaker.UsuarioEntity);
            user.Senha = "Senha@1Certa";
            string senha = "senha@1Errada";
            var excepction = await Assert.ThrowsAsync<ArgumentException>(() => service.Login(user.Email, senha));

            Assert.Equal("Senha incompatível com a cadastrada!", excepction.Message);
        }
    }
}