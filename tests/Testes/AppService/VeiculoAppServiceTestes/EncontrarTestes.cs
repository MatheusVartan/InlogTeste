using AppService.AppService;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Moq;
using Xunit;

namespace Testes.AppService.VeiculoAppServiceTestes
{
    public class EncontrarTestes
    {
        [Fact]
        public void DeveEncontrarUmVeiculo()
        {
            //Arrange
            var veiculo = new Onibus("111111", "vermelho");

            var veiculoRepositorioMock = new Mock<IVeiculoRepositorio>();
            veiculoRepositorioMock.Setup(x => x.Encontrar(veiculo.Chassi)).Returns(veiculo);

            var veiculoAppService = new VeiculoAppService(veiculoRepositorioMock.Object);

            //Action
            var resultado = veiculoAppService.Encontrar(veiculo.Chassi);

            //Assert
            Assert.Equal(resultado, veiculo);
        }
    }
}