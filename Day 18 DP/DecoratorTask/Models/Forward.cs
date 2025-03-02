using DecoratorTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorTask.Models
{
    internal class Forward : IPlayer
    {
        IPlayer player;
        public Forward(IPlayer player) => this.player = player;
        public string PassBall()
        {
            return player.PassBall() + ", Attacker";
        }
    }
}
