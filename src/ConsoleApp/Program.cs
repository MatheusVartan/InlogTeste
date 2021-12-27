using ConsoleApp;
using ConsoleApp.Menus;
using ConsoleApp.Menus.Principal;

using var host = Startup.CreateHostBuilder(args).Build();

Contexto.GerarContexto(new MenuPrincipal(host.Services));