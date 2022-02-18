using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using observer_lib;

namespace observer_main
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            //WeatherData GisMeteo = new WeatherData();
            //WeatherData Yandex = new WeatherData();

            //CurrentConditionDisplay CurDisp1 = new CurrentConditionDisplay(GisMeteo);
            //StatisticsDisplay StatDisp1 = new StatisticsDisplay(Yandex);
            //ForeCastDisplay Fcastdisp1 = new ForeCastDisplay(Yandex);
            //Yandex.removeObservers(Fcastdisp1);
            //GisMeteo.setState("GisMeteo - reg CurDisp1");
            //Yandex.setState("Yandex - reg statDisp1, reg Fcastdisp1");

            //Console.WriteLine(GisMeteo.getState());
            //Console.WriteLine(Yandex.getState());

            void RandomMeasurmentsAndDisplay(WeatherData Subject, IDisplayElement observer, int CountOfInstanses)
            {
                while (CountOfInstanses != 0)
                {
                    Random rnd = new Random();
                    Subject.SetMeasurements(rnd.Next(-50, 50), rnd.Next(30, 70), rnd.Next(740, 760));
                    Thread.Sleep(1);
                    Console.WriteLine(observer.display());
                    CountOfInstanses--;
                }        
            }
            //RandomMeasurmentsAndDisplay(GisMeteo, CurDisp1, 1);
            //RandomMeasurmentsAndDisplay(Yandex, StatDisp1, 2);
            //RandomMeasurmentsAndDisplay(Yandex, Fcastdisp1, 5);

            Console.ReadLine();
        }
    }
}
