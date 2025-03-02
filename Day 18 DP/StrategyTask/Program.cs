using StrategyTask.Models;

namespace StrategyTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Team team = new Team();

            team.PlayGame();

            team.SetStrategy(new AttackStrategy());

            team.PlayGame();

            team.SetStrategy(new DefendStrategy());

            team.PlayGame();
        }
    }
}
