using StrategyTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyTask.Models
{
    internal class Team
    {
        private ITeamStrategy teamStrategy = new DefaultStrategy();
        public void PlayGame()
        {
            teamStrategy.Play();
        }

        public void SetStrategy(ITeamStrategy strategy) => teamStrategy = strategy;
    }
}
