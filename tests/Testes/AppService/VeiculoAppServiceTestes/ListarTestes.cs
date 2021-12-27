using AppService.AppService;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Testes.AppService.VeiculoAppServiceTestes
{
    public class ListarTestes
    {
        [Fact]
        public void DeveListarVeiculos()
        {
            //Arrange
            var veiculos = new List<Veiculo>
            {
                new Onibus("111111", "vermelho"),
                new Caminhao("111112", "azul")
            };

            var veiculoRepositorioMock = new Mock<IVeiculoRepositorio>();
            veiculoRepositorioMock.Setup(x => x.Listar()).Returns(veiculos);

            var veiculoAppService = new VeiculoAppService(veiculoRepositorioMock.Object);

            //Action
            var resultado = veiculoAppService.Listar();

            //Assert
            Assert.Equal(resultado, veiculos);
        }
    }
}