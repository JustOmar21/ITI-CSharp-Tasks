using ObserverTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTask.Models
{
    public class Player : IObserver
    {
        Position Position = new Position();

        public Player()
        {
            Position.X = 0;
            Position.Y = 0;
            Position.Z = 0;
        }

        public Player(Position position)
            => (Position.X, Position.Y, Position.Z) = (position.X, position.Y, position.Z);

        public void SetPosition(int X, int Y, int Z)
            => (Position.X, Position.Y, Position.Z) = (X, Y, Z);
        public Position GetPosition()
            => Position;
        public override string ToString()
            => $"Player now at ({Position.X} , {Position.Y} , {Position.Z})";

        public void Update()
        {
            Console.WriteLine($"Player now looking at the ball from {Position}");
        }
    }
}
