using AppService.AppService;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Moq;
using Xunit;

namespace Testes.AppService.VeiculoAppServiceTestes
{
    public class EditarTestes
    {
        [Fact]
        public void DeveEditarUmVeiculo()
        {
            //Arrange
            var novaCor = "roxo";
            var veiculo = new Onibus("111111", "vermelho");

            var veiculoRepositorioMock = new Mock<IVeiculoRepositorio>();
            veiculoRepositorioMock.Setup(x => x.Editar(veiculo)).Returns(1);

            var veiculoAppService = new VeiculoAppService(veiculoRepositorioMock.Object);

            //Action
            var resultado = veiculoAppService.Editar(veiculo, novaCor);

            //Assert
            Assert.Equal(1, resultado);
            Assert.Equal(novaCor, veiculo.Cor);
        }
    }
}
