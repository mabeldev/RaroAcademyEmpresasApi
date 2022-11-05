using Academy.Empresas.Api.Controllers;
using Academy.Empresas.Domain.Interfaces.Service;
using Academy.Empresas.Testes.Fakers.EmpresaFaker;
using Moq;

namespace Academy.Empresas.Testes.Controller
{
    [Trait("Controller", "Controller de Empresas")]
    public class EmpresaControllerTest
    {
        private readonly Mock<IEmpresaService> _mockEmpresaService = new Mock<IEmpresaService>();

        [Fact(DisplayName = "Cadastra uma nova Empresa")]
        public async Task Post()
        {
            var userRequest = EmpresaContractFaker.EmpresaRequest();
            var resultUserRequest = EmpresaContractFaker.EmpresaResponseBaseRequestAsync(userRequest.Nome);

            _mockEmpresaService.Setup(mock => mock.Post(userRequest)).Returns(resultUserRequest);

            var controller = new EmpresaController(_mockEmpresaService.Object);

            var result = await controller.Post(userRequest);

            Assert.Equal(result.Nome, resultUserRequest.Result.Nome);
        }
        
        [Fact(DisplayName = "Lista todas as Empresas")]
        public async Task Get()
        {
            _mockEmpresaService.Setup(mock => mock.Get()).Returns(EmpresaContractFaker.EmpresaResponseAsync());

            var controller = new EmpresaController(_mockEmpresaService.Object);

            var result = await controller.Get();

            Assert.True(result.ToList().Count() > 0);
        }
        

        [Fact(DisplayName = "Busca uma Empresa por ID")]
        public async Task GetById()
        {
            int id = EmpresaContractFaker.GetId();

            _mockEmpresaService.Setup(mock => mock.GetById(id)).Returns(EmpresaContractFaker.EmpresaResponseAsync(id));

            var controller = new EmpresaController(_mockEmpresaService.Object);

            var result = await controller.GetById(id);

            Assert.Equal(result.Id, id);
        }

        [Fact(DisplayName = "Edita uma Empresa já existente")]
        public async Task Put()
        {
            var userRequest = EmpresaContractFaker.EmpresaRequest();
            var resultUserRequest = EmpresaContractFaker.EmpresaResponseBaseRequestAsync(userRequest.Nome);

            _mockEmpresaService.Setup(mock => mock.Put(userRequest, resultUserRequest.Result.Id)).Returns(resultUserRequest);

            var controller = new EmpresaController(_mockEmpresaService.Object);

            var result = await controller.Put(resultUserRequest.Result.Id, userRequest);

            Assert.Equal(result.Nome, resultUserRequest.Result.Nome);
        }

        [Fact(DisplayName = "Remove uma Empresa já existente")]
        public async Task Delete()
        {
            int id = EmpresaContractFaker.GetId();

            _mockEmpresaService.Setup(mock => mock.Delete(id)).Returns(() => Task.FromResult(string.Empty));

            var controller = new EmpresaController(_mockEmpresaService.Object);

            try
            {
                await controller.Delete(id);
            }
            catch (System.Exception)
            {
                Assert.True(false);
            }
        }
    }
}