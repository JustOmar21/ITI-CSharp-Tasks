using StrategyTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyTask.Models
{
    internal class AttackStrategy : ITeamStrategy
    {
        public void Play()
        {
            Console.WriteLine("Attack Strategy in motion");
        }
    }
}
