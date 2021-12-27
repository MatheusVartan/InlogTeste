namespace Dominio.Entidades
{
    public abstract class Veiculo
    {
        protected Veiculo(string chassi, string cor, byte numeroDePassageiros)
        {
            Chassi = chassi;
            Cor = cor;
            NumeroDePassageiros = numeroDePassageiros;
        }

        public Guid Id { get; init; }
        public string Chassi { get; init; }
        public string Cor { get; private set; }
        public byte NumeroDePassageiros { get; init; }

        public void EditarCor(string cor) => Cor = cor;
    }
}