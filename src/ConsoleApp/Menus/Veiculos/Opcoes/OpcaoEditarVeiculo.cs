using Dominio.Entidades;
using Dominio.Interfaces.AppService;
using Spectre.Console;

namespace ConsoleApp.Menus.Veiculos.Opcoes
{
    public class OpcaoEditarVeiculos : Menu
    {
        private readonly IVeiculoAppService veiculoAppService;

        public OpcaoEditarVeiculos(IVeiculoAppService veiculoAppService)
        {
            this.veiculoAppService = veiculoAppService;
        }

        public override bool Iniciar()
        {
            Veiculo veiculo = null;

            AnsiConsole.Prompt(
                    new TextPrompt<string>("Digite o [green]número do chassi[/] do veículo:")
                          .Validate(chassi =>
                          {
                              veiculo = veiculoAppService.Encontrar(chassi);
                              Console.Clear();
                              if (veiculo is null)
                              {
                                  return ValidationResult.Error("[red]Veículo não encontrado[/]");
                              }

                              return ValidationResult.Success();
                          }));

            var table = new Table();

            table.Border(TableBorder.AsciiDoubleHead);

            table.AddColumns("Descrição", "Valor");

            table.AddRow("Id", veiculo.Id.ToString());
            table.AddRow("Chassi", veiculo.Chassi);
            table.AddRow("Cor", veiculo.Cor);
            table.AddRow("Tipo", veiculo is Onibus ? "Ônibus" : "Caminhão");
            table.AddRow("Número de Passageiros", veiculo.NumeroDePassageiros.ToString());

            AnsiConsole.Write(table);

            var novaCor = AnsiConsole.Ask<string>("Qual a nova [green]cor[/] do veículo?");

            if (!AnsiConsole.Confirm("Deseja realmente realizar a edição?"))
                return true;

            veiculoAppService.Editar(veiculo, novaCor);

            return false;
        }
    }
}