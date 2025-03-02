using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherTask.Interfaces;

namespace WeatherTask.Models
{
    public class WeatherEventArgs : EventArgs
    {
        public string Report { get; set; } = string.Empty;
    }
    internal class Station : IStation
    {
        private string status;
        public string Status { get => status; set { status = value; NotifyObserver(); } }
        public event EventHandler<WeatherEventArgs> OnWeatherChanged;

        public void AttachObserver(IObserver observer)
        {
            OnWeatherChanged += observer.Report;
        }

        public void DeattachObserver(IObserver observer)
        {
            OnWeatherChanged -= observer.Report;
        }

        public void NotifyObserver()
        {
            OnWeatherChanged?.Invoke(this, new() { Report = "Status has changed"});
        }

        
    }
}
