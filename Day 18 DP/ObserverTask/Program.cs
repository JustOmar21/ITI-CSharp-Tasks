using ObserverTask.Models;

namespace ObserverTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player(new(1,5,7));
            Player player2 = new Player(new(3,5,6));
            Player player3 = new Player(new(2,5,7));
            Player player4 = new Player(new(4,6,7));

            Referee referee1 = new Referee(new(1,1,1));
            Referee referee2 = new Referee(new(10,10,10));

            Ball ball = new Ball(new(1,3,4));
            ball.AttachObserver(player1);
            ball.AttachObserver(player2);
            ball.AttachObserver(player3);
            ball.AttachObserver(player4);
            ball.AttachObserver(referee1);
            ball.AttachObserver(referee2);

            ball.SetPosition(new(2, 5, 8));

        }
    }
}
