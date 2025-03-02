using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherTask.Models;

namespace WeatherTask.Interfaces
{
    internal interface IObserver
    {
        public void Report(object sender,
       WeatherEventArgs e);
    }
}
