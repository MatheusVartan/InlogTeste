using Dominio.Entidades;
using Xunit;

namespace Testes.Entidades.OnibusTestes
{
    public class CtorTestes
    {
        [Fact]
        public void OnibusDeveDeveInstanciarComNumeroDePassageirosIgualA42()
        {
            //Arrange/Action
            var onibus = new Onibus("111111", "vermelho");

            //Assert
            Assert.Equal(42, onibus.NumeroDePassageiros);
        }
    }
}