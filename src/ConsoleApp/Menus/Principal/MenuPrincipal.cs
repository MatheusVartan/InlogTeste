using ConsoleApp.Menus.Veiculos;
using Spectre.Console;

namespace ConsoleApp.Menus.Principal
{
    public class MenuPrincipal : Menu
    {
        private readonly IServiceProvider serviceProvider;

        public MenuPrincipal(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public override bool Iniciar()
        {
            AnsiConsole.Write(
    new FigletText($"Bem-Vindo ao Frotas!")
                .Centered()
                .Color(Color.Aqua));

            var escolha = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                            .Title("Selecione uma opção:")
                                            .PageSize(10)
                                            .AddChoices(new[] {
                                                "Veículos", "Sair"
                                            }));

            switch (escolha)
            {
                case "Veículos":
                    {
                        Contexto.GerarContexto(new MenuPrincipalVeiculos(serviceProvider));

                        return true;
                    }
                default:
                    return false;
            }
        }
    }
}