using Academy.Empresas.Domain.Entities;
using Academy.Empresas.Domain.Interfaces.Repository;
using Academy.Empresas.Service;
using Academy.Empresas.Testes.CrossCutting;
using Academy.Empresas.Testes.Fakers.EmpresaFaker;
using AutoMapper;
using Moq;

namespace Academy.Empresas.Testes.Services
{
    [Trait("Service", "Service de Empresa")]
    public class EmpresaServiceTest
    {
        private readonly Mock<IEmpresaRepository> _mockEmpresaRepository = new Mock<IEmpresaRepository>();
        public IMapper mapper = new AutoMapperFixture().GetMapper();

        [Fact(DisplayName = "Cadastra um novo Empresa")]
        public async Task Post()
        {
            var EmpresaRequest = EmpresaContractFaker.EmpresaRequest();
            var EmpresaRequestEntity = EmpresaEntityFaker.EmpresaEntity();
            var resultEmpresaRequest = EmpresaEntityFaker.EmpresaEntityBaseRequestAsync(EmpresaRequestEntity.Nome);

            _mockEmpresaRepository.Setup(mock => mock.Post(It.IsAny<EmpresaEntity>())).Returns(resultEmpresaRequest);

            var service = new EmpresaService(_mockEmpresaRepository.Object, mapper);

            var result = await service.Post(EmpresaRequest);

            Assert.Equal(result.Nome, resultEmpresaRequest.Result.Nome);
        }

        [Fact(DisplayName = "Tenta cadastrar uma nova Empresa com Nome invalido")]
        public async Task PostNomeInvalido()
        {
            var user = EmpresaContractFaker.EmpresaRequest();
            user.NomeFantasia = "";

            var service = new EmpresaService(_mockEmpresaRepository.Object, mapper);
            var excepction = await Assert.ThrowsAsync<ArgumentException>(() => service.Post(user));

            Assert.Equal("Nome Fantasia de empresa é muito pequeno ou inexistente!", excepction.Message);
        }

        public async Task GetById()
        {
            int id = EmpresaEntityFaker.GetId();

            _mockEmpresaRepository.Setup(mock => mock.GetById(id)).Returns(EmpresaEntityFaker.EmpresaEntityAsync(id));

            var service = new EmpresaService(_mockEmpresaRepository.Object, mapper);

            var result = await service.GetById(id);

            Assert.Equal(result.Id, id);
        }

        [Fact(DisplayName = "Edita um Empresa já existente")]
        public async Task Put()
        {
            var userRequest = EmpresaContractFaker.EmpresaRequest();
            var userRequestEntity = EmpresaEntityFaker.EmpresaEntity();
            var resultUserRequest = EmpresaEntityFaker.EmpresaEntityBaseRequestAsync(userRequestEntity.Nome);

            _mockEmpresaRepository.Setup(mock => mock.GetById(It.IsAny<int>())).Returns(resultUserRequest);
            _mockEmpresaRepository.Setup(mock => mock.Put(It.IsAny<EmpresaEntity>(), It.IsAny<int?>())).Returns(resultUserRequest);

            var service = new EmpresaService(_mockEmpresaRepository.Object, mapper);

            var result = await service.Put(userRequest, resultUserRequest.Result.Id);

            Assert.Equal(result.Nome, resultUserRequest.Result.Nome);

        }
        [Fact(DisplayName = "Remove um Empresa já existente")]
        public async Task Delete()
        {
            int id = EmpresaEntityFaker.GetId();

            _mockEmpresaRepository.Setup(mock => mock.Delete(id)).Returns(() => Task.FromResult(string.Empty));

            var service = new EmpresaService(_mockEmpresaRepository.Object, mapper);

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