using AppService.AppService;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Moq;
using Xunit;

namespace Testes.AppService.VeiculoAppServiceTestes
{
    public class RemoverTestes
    {
        [Fact]
        public void DeveRemoverUmVeiculo()
        {
            //Arrange
            var veiculo = new Onibus("111111", "vermelho");

            var veiculoRepositorioMock = new Mock<IVeiculoRepositorio>();
            veiculoRepositorioMock.Setup(x => x.Remover(veiculo)).Returns(1);

            var veiculoAppService = new VeiculoAppService(veiculoRepositorioMock.Object);

            //Action
            var resultado = veiculoAppService.Remover(veiculo);

            //Assert
            Assert.Equal(1, resultado);
        }
    }
}