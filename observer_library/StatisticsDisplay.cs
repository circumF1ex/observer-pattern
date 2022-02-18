using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace observer_lib
{
    public class StatisticsDisplay: IObserver, IDisplayElement
    {
        private float MaxTemp;     private float MinTemp;       public float AvgTemp;
        private float MaxHumidity; private float MinHumidity;   private float AvgHumidity;
        private float MaxPressure; private float MinPressure;   private float AvgPressure;

        private List<float> Temps;
        private List<float> Humids;
        private List<float> Presurs;

        private int RWCount;

        public WeatherData WeatherData;
        
        public StatisticsDisplay(WeatherData weatherData)
        {
            this.WeatherData = weatherData;
            WeatherData.registryObservers(this);
            Temps = new List<float>();
            Humids = new List<float>();
            Presurs = new List<float>();
        }
        public void update(float temp, float humidity, float pressure)
        {
            void setTemp()
            {
                Temps.Add(temp);
                MaxTemp = Temps.Max();
                MinTemp = Temps.Min();
                AvgTemp = Temps.Average();
            }
            
            void setHumidity()
            {
                  Humids.Add(humidity);
                  MaxHumidity = Humids.Max();
                  MinHumidity = Humids.Min();
                  AvgHumidity = Humids.Average();
            }
            void setPressure()
            {
                Presurs.Add(pressure);
                MaxPressure = Presurs.Max();
                MinPressure = Presurs.Min();
                AvgPressure = Presurs.Average();
            }
            //Удаляет первый элемент списков, спасает от их переполнения! 
            void deletefirst()
            {
                if (RWCount > 9)
                {
                    RWCount--;
                    Temps.RemoveAt(0);
                    Humids.RemoveAt(0);
                    Presurs.RemoveAt(0);
                }
            }
            RWCount++;
            deletefirst();
            setTemp();
            setHumidity();
            setPressure();
            display();
        }
        public string display()
        {
            return $"Temperature - Max is {MaxTemp},  Min is {MinTemp}, Avg is {AvgTemp}\n"
                +  $"Humidity    - Max is {MaxHumidity}, Min is {MinHumidity}, Avg is {AvgHumidity}\n"
                +  $"Pressure    - Max is {MaxPressure}, Min is {MinPressure}, Avg is {AvgPressure}\n";
        }
    }
}
