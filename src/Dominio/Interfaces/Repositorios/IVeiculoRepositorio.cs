using Dominio.Entidades;

namespace Dominio.Interfaces.Repositorios
{
    public interface IVeiculoRepositorio
    {
        int Adicionar(Veiculo veiculo);

        int Editar(Veiculo veiculo);

        int Remover(Veiculo veiculo);

        Veiculo Encontrar(string chassi);

        IEnumerable<Veiculo> Listar();
    }
}