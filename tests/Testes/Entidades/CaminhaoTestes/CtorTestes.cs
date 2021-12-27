using Dominio.Entidades;
using Xunit;

namespace Testes.Entidades.CaminhaoTestes
{
    public class CtorTestes
    {
        [Fact]
        public void CaminhaoDeveDeveInstanciarComNumeroDePassageirosIgualA2()
        {
            //Arrange/Action
            var caminhao = new Caminhao("111111", "vermelho");

            //Assert
            Assert.Equal(2, caminhao.NumeroDePassageiros);
        }
    }
}