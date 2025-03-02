using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTask.Interfaces
{
    internal interface IStation
    {
        public void AttachObserver(IObserver observer);
        public void DeattachObserver(IObserver observer);
        public void NotifyObserver();
    }
}
