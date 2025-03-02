using ObserverTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTask.Models
{
    public class Ball : IBall
    {
        Position Position = new Position();

        public Ball()
        {
            Position.X = 0;
            Position.Y = 0;
            Position.Z = 0;
        }

        public Ball(Position position) 
            => (Position.X, Position.Y, Position.Z) = (position.X, position.Y, position.Z);

        public void SetPosition(Position position)
        {
            (Position.X, Position.Y, Position.Z) = (position.X, position.Y, position.Z);
            NotifyObserver();
        }
        public Position GetPosition() 
            => Position;
        public override string ToString() 
            => $"Ball now at ({Position.X} , {Position.Y} , {Position.Z})";

        public override void AttachObserver(IObserver observer)
        {
            Observers.Add(observer);
        }

        public override void DeattachObserver(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public override void NotifyObserver()
        {
            foreach(var observer in Observers)
            {
                observer.Update();
            }
        }
    }
}
