using ConsoleApp.Menus.Veiculos.Opcoes;
using Dominio.Interfaces.AppService;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace ConsoleApp.Menus.Veiculos
{
    public class MenuPrincipalVeiculos : Menu
    {
        private readonly IVeiculoAppService veiculoAppService;

        public MenuPrincipalVeiculos(IServiceProvider serviceProvider)
        {
            this.veiculoAppService = serviceProvider.GetRequiredService<IVeiculoAppService>();
        }

        public override bool Iniciar()
        {
            Console.Clear();

            var escolha = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                            .Title("Selecione uma opção:")
                                            .PageSize(10)
                                            .AddChoices(new[] {
                                                "Inserir", "Editar", "Deletar", "Listar", "Encontrar", "Relatório", "Voltar"
                                            }));

            switch (escolha)
            {
                case "Inserir":
                    {
                        Contexto.GerarContexto(new OpcaoInserirVeiculo(veiculoAppService));

                        return true;
                    }
                case "Editar":
                    {
                        Contexto.GerarContexto(new OpcaoEditarVeiculos(veiculoAppService));

                        return true;
                    }
                case "Deletar":
                    {
                        Contexto.GerarContexto(new OpcaoDeletarVeiculos(veiculoAppService));

                        return true;
                    }
                case "Listar":
                    {
                        Contexto.GerarContexto(new OpcaoListarVeiculos(veiculoAppService));

                        return true;
                    }
                case "Encontrar":
                    {
                        Contexto.GerarContexto(new OpcaoEncontrarVeiculos(veiculoAppService));

                        return true;
                    }
                case "Relatório":
                    {
                        Contexto.GerarContexto(new OpcaoRelatorioVeiculos(veiculoAppService));

                        return true;
                    }
                default:
                    return false;
            }
        }
    }
}