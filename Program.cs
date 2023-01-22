using PetShop.View;

namespace PetShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // altera a cor do console para azul
            Console.BackgroundColor = ConsoleColor.Blue;

            // instanciando minha classe inicio chamando minha funcao dashboard
            HomeView home = new HomeView();
            home.DashBoard();
        }
    }
}