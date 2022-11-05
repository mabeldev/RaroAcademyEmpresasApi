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