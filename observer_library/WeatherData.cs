using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace observer_lib
{
    public class WeatherData: ISubject
    {
        private ArrayList Observers;
        private string State;
        private float temp;
        private float humidity;
        private float pressure;
        public WeatherData()
        {
           Observers = new ArrayList();
        }
        public void registryObservers(IObserver O)
        {
            Observers.Add(O);
        }
        public void removeObservers(IObserver O)
        {
            int i = Observers.IndexOf(O);
            if (i >= 0) { Observers.RemoveAt(i); }
        }
        public void notifyObservers()
        {
            for (int i = 0; i < Observers.Count; i++)
            {
                if (Observers[i] is IObserver)
                {
                    (Observers[i] as IObserver).update(temp, humidity, pressure);
                }
                
            }
        }
        
        public void MeasurmentChanged()
        {
            notifyObservers();
        }
        public void SetMeasurements(float temp, float humidity, float pressure)
        {
            this.temp = temp;
            this.humidity = humidity;
            this.pressure = pressure;
            MeasurmentChanged();
        }
        public string getState()
        {
            if (State == null) { return "State is null"; }
            else { return $"State is:{State}"; }
        }
        public string setState(string State)
        {
            this.State = State;
            //notifyObservers();
            return State;
        }
    }
}
