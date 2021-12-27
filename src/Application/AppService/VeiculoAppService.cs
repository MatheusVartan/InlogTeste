using Dominio.Entidades;
using Dominio.Interfaces.AppService;
using Dominio.Interfaces.Repositorios;

namespace AppService.AppService
{
    public class VeiculoAppService : IVeiculoAppService
    {
        private readonly IVeiculoRepositorio veiculoRepositorio;

        public VeiculoAppService(IVeiculoRepositorio veiculoRepositorio)
        {
            this.veiculoRepositorio = veiculoRepositorio;
        }

        public int Adicionar(Veiculo veiculo) =>
            veiculoRepositorio.Adicionar(veiculo);

        public int Editar(Veiculo veiculo, string cor)
        {
            veiculo.EditarCor(cor);

            return veiculoRepositorio.Editar(veiculo);
        }

        public Veiculo Encontrar(string chassi) =>
            veiculoRepositorio.Encontrar(chassi);

        public IEnumerable<Veiculo> Listar() =>
            veiculoRepositorio.Listar();

        public int Remover(Veiculo veiculo) =>
            veiculoRepositorio.Remover(veiculo);
    }
}