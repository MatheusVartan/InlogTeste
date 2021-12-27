using Dominio.Entidades;
using Dominio.Interfaces.AppService;
using Spectre.Console;

namespace ConsoleApp.Menus.Veiculos.Opcoes
{
    public class OpcaoRelatorioVeiculos : Menu
    {
        private readonly IVeiculoAppService veiculoAppService;

        public OpcaoRelatorioVeiculos(IVeiculoAppService veiculoAppService)
        {
            this.veiculoAppService = veiculoAppService;
        }

        public override bool Iniciar()
        {
            var veiculos = veiculoAppService.Listar();
            AnsiConsole.Clear();

            var totalOnibus = veiculos.Count(x => x is Onibus);
            var totalCaminhao = veiculos.Count(x => x is Caminhao);

            AnsiConsole.Write(new BarChart()
                .Width(100)
                .Label("[green bold underline]Relatório[/]")
                .CenterLabel()
                .AddItem("Ônibus", totalOnibus, Color.Yellow)
                .AddItem("Caminhão", totalCaminhao, Color.Green));

            AnsiConsole.WriteLine("Pressione qualquer botão para retornar");
            Console.ReadKey();

            return false;
        }
    }
}