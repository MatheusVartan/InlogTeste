using AppService.AppService;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Moq;
using Xunit;

namespace Testes.AppService.VeiculoAppServiceTestes
{
    public class AdicionarTestes
    {
        [Fact]
        public void DeveAdicionarUmVeiculo()
        {
            //Arrange
            var veiculo = new Onibus("111111", "vermelho");

            var veiculoRepositorioMock = new Mock<IVeiculoRepositorio>();
            veiculoRepositorioMock.Setup(x => x.Adicionar(veiculo)).Returns(1);

            var veiculoAppService = new VeiculoAppService(veiculoRepositorioMock.Object);

            //Action
            var resultado = veiculoAppService.Adicionar(veiculo);

            //Assert
            Assert.Equal(1, resultado);
        }
    }
}