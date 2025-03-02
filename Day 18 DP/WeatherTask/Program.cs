using WeatherTask.Models;

namespace WeatherTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Station station = new Station();

            Sensor sensor = new Sensor();

            station.Status = "Good";

            station.AttachObserver(sensor);

            station.Status = "Not Good";

            station.DeattachObserver(sensor);

            station.Status = "Ye";
        }
    }
}
