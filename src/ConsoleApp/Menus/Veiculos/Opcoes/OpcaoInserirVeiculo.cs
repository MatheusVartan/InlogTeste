using Dominio.Entidades;
using Dominio.Interfaces.AppService;
using Spectre.Console;

namespace ConsoleApp.Menus.Veiculos.Opcoes
{
    public class OpcaoInserirVeiculo : Menu
    {
        private readonly IVeiculoAppService veiculoAppService;

        public OpcaoInserirVeiculo(IVeiculoAppService veiculoAppService)
        {
            this.veiculoAppService = veiculoAppService;
        }

        public override bool Iniciar()
        {
            var tipo = AnsiConsole.Prompt(
                    new TextPrompt<string>("Qual o [green]tipo[/] do veículo?")
                          .InvalidChoiceMessage("[red]Tipo de veículo inválido[/]")
                          .DefaultValue("Onibus")
                          .AddChoice("Onibus")
                          .AddChoice("Caminhao"));
            var cor = AnsiConsole.Ask<string>("Qual a [green]cor[/] do veículo?");
            var chassi = AnsiConsole.Prompt(
                    new TextPrompt<string>("Qual o [green]número do chassi[/] do veículo? (6 dígitos)")
                          .Validate(chassi =>
                          {
                              var veiculo = veiculoAppService.Encontrar(chassi);

                              if (veiculo is not null)
                              {
                                  return ValidationResult.Error("[red]Já existe um veículo com esse número de chassi[/]");
                              }

                              return chassi.Length switch
                              {
                                  < 6 => ValidationResult.Error("[red]Número maior que o correto[/]"),
                                  > 6 => ValidationResult.Error("[red]Número menor que o correto[/]"),
                                  _ => ValidationResult.Success(),
                              };
                          }));

            Veiculo veiculo = tipo == "Onibus" ? new Onibus(chassi, cor) : new Caminhao(chassi, cor);

            veiculoAppService.Adicionar(veiculo);

            return false;
        }
    }
}