using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace observer_lib
{
    public class ForeCastDisplay : IObserver, IDisplayElement
    {
        //Поля со значениями текущей температуры, влажности, давления и список, хранящий значения давления
        //(нужно для дальнейшего прогнозирования) - можно было и в статистиксдисплэй сделать...
        private float Temp; 
        private float Humidity; 
        private float Pressure;
        public WeatherData WeatherData;
        private List<float> PresList;
        private string prognozis; private string WState;
        private int RWCount;
        //Констркутор форкастдисплэй: инициализирует список давлений, поле WeatherData, регистрирует ФКД за субъектом
        public ForeCastDisplay(WeatherData weatherData)
        {
            this.WeatherData = weatherData;
            WeatherData.registryObservers(this);
            PresList = new List<float>() { 750, 750, 750 };
        }
        //Апдейт для форкаст: генерирует предсказание на основе записей о изменении давления
        //где три и более прироста/отроста)) будут говорить о скором наступлении новой погоды
        public void update(float temp, float humidity, float pressure)
        {
            this.Temp = temp;
            this.Humidity = humidity;
            this.Pressure = pressure;
            PresList.Add(pressure);
            void deletefirst()
            {
                if (RWCount > 9)
                {
                    RWCount--;
                    PresList.RemoveAt(0);
                }
            }
            void setWState()
            {
                if (pressure > 760)
                {
                    WState = "sunny";
                }
                if (pressure < 745)
                {
                    WState = "dull/rainy";
                }
                else if (pressure < 760 && pressure > 745)
                {
                    WState = "cloudy";
                }
            }
            //Прогноз создаётся на основании двух предыдущих показаний давления:
            //если новый показатель больше/меньше двух предыдущих, прогноз будет показывать возможное изменения погоды
            //если не больше/меньше предыдущего, но не больше/меньше предпредыдущего - погода стабильна
            void Prognoz()
            {
                setWState();
                if (PresList.ElementAt(PresList.Count - 2) > PresList.Last())
                {
                    if (PresList.ElementAt(PresList.Count - 3) > PresList.Last())
                    {
                        this.prognozis = $"Now {WState} weather may be worse soon!";
                    }
                    else
                    {
                        this.prognozis = $"Now {WState} weather is stable";
                    }
                }
                if (PresList.ElementAt(PresList.Count - 2) < PresList.Last())
                {
                    if (PresList.ElementAt(PresList.Count - 3) > PresList.Last())
                    {
                        this.prognozis = $"Now {WState} weather is stable";
                    }
                    else
                    {
                        this.prognozis = $"Now {WState} weather may be better soon!";
                    }
                }
            }
            RWCount++;
            deletefirst();
            Prognoz();
            display();
        }
        public string display()
        {
            return $"Current codnditions in Kostroma:" +
                $"\nTemperature is {Temp} of Celsius;" +
                $"\nHumidity is {Humidity}%;" +
                $"\nPressure is {Pressure}mm of mercury" +
                $"\nPrognoz: {this.prognozis}\n";
        }
    }
}