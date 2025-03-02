using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherTask.Interfaces;

namespace WeatherTask.Models
{
    internal class Sensor : IObserver
    {
        
        public void Report(object sender, WeatherEventArgs e)
        {
            var stat = sender as Station;
            Console.WriteLine($"Sensor 1 has detected that {e.Report}, new status is {stat?.Status ?? "NA"}");
        }
    }
}
