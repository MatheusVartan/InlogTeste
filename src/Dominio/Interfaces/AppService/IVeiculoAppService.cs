using Dominio.Entidades;

namespace Dominio.Interfaces.AppService
{
    public interface IVeiculoAppService
    {
        int Adicionar(Veiculo veiculo);

        int Editar(Veiculo veiculo, string cor);

        int Remover(Veiculo veiculo);

        Veiculo Encontrar(string chassi);

        IEnumerable<Veiculo> Listar();
    }
}