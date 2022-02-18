using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace observer_lib
{
    public class CurrentConditionDisplay: IObserver, IDisplayElement
    {
        private float temp;
        private float humidity;
        private float pressure;
        public WeatherData WeatherData;

        public CurrentConditionDisplay(WeatherData weatherData)
        {
            this.WeatherData = weatherData;
            WeatherData.registryObservers(this);
        }
        public void update(float temp, float humidity, float pressure)
        {
            this.temp = temp;
            this.humidity = humidity;
            this.pressure = pressure;
            display();
        }
        public string display()
        {
            return $"Current codnditions in Kostroma:" +
                $"\nTemperature is {temp} of Celsius;" +
                $"\nHumidity is {humidity}%;" +
                $"\nPressure is {pressure}mm of mercury\n";
        }
    }
}
