using DecoratorTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorTask.Models
{
    internal class Player : IPlayer
    {
        public string PassBall()
        {
            return $"Player";
        }
    }
}
