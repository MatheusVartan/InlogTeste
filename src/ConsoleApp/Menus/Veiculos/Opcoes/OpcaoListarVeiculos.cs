using Dominio.Entidades;
using Dominio.Interfaces.AppService;
using Spectre.Console;

namespace ConsoleApp.Menus.Veiculos.Opcoes
{
    public class OpcaoListarVeiculos : Menu
    {
        private readonly IVeiculoAppService veiculoAppService;

        public OpcaoListarVeiculos(IVeiculoAppService veiculoAppService)
        {
            this.veiculoAppService = veiculoAppService;
        }

        public override bool Iniciar()
        {
            var veiculos = veiculoAppService.Listar();
            AnsiConsole.Clear();

            var table = new Table();

            table.Border(TableBorder.AsciiDoubleHead);

            table.AddColumns("Id", "Chassi", "Cor", "Tipo", "Número de Passageiros");

            foreach (var veiculo in veiculos)
            {
                table.AddRow(veiculo.Id.ToString(), veiculo.Chassi, veiculo.Cor, veiculo is Onibus ? "Ônibus" : "Caminhão", veiculo.NumeroDePassageiros.ToString());
            }

            AnsiConsole.Write(table);

            AnsiConsole.WriteLine("Pressione qualquer botão para retornar");
            Console.ReadKey();

            return false;
        }
    }
}