﻿using DecoratorTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorTask.Models
{
    internal class Midfield : IPlayer
    {
        IPlayer player;
        public Midfield(IPlayer player) => this.player = player;
        public string PassBall()
        {
            return player.PassBall() + ", Midfield";
        }
    }
}
