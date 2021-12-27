using Dominio.Entidades;
using Xunit;

namespace Testes.Entidades.VeiculoTestes
{
    public class EditarCorTestes
    {
        [Fact]
        public void DeveEditarACorDeUmVeiculo()
        {
            //Arrange
            var novaCor = "roxo";
            var veiculo = new Onibus("111111", "vermelho");

            //Action
            veiculo.EditarCor(novaCor);

            //Assert
            Assert.Equal(novaCor, veiculo.Cor);
        }
    }
}