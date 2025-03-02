using DecoratorTask.Interfaces;
using DecoratorTask.Models;

namespace DecoratorTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPlayer player = new Player();
            Console.WriteLine(player.PassBall());

            player = new Forward(player);
            Console.WriteLine(player.PassBall());
            
            
            player = new Midfield(player);
            Console.WriteLine(player.PassBall());

            player = new Defender(player);
            Console.WriteLine(player.PassBall());
        }
    }
}
