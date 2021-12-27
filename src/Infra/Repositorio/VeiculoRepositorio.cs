using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Infra.Contextos;

namespace Infra.Repositorio
{
    public class VeiculoRepositorio : IVeiculoRepositorio
    {
        private readonly AppDbContext appDbContext;

        public VeiculoRepositorio(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public int Adicionar(Veiculo veiculo)
        {
            appDbContext.Veiculos.Add(veiculo);
            return appDbContext.SaveChanges();
        }

        public int Editar(Veiculo veiculo)
        {
            appDbContext.Veiculos.Update(veiculo);
            return appDbContext.SaveChanges();
        }

        public int Remover(Veiculo veiculo)
        {
            appDbContext.Veiculos.Remove(veiculo);
            return appDbContext.SaveChanges();
        }

        public Veiculo Encontrar(string chassi)
        {
            return appDbContext.Veiculos.FirstOrDefault(veiculo => veiculo.Chassi.Equals(chassi));
        }

        public IEnumerable<Veiculo> Listar()
        {
            return appDbContext.Veiculos.ToList();
        }
    }
}