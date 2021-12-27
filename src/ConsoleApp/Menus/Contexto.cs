namespace ConsoleApp.Menus
{
    public static class Contexto
    {
        public static void GerarContexto(Menu menu)
        {
            var continuar = true;
            while (continuar)
            {
                continuar = menu.Iniciar();
                Console.Clear();
            }
        }
    }
}