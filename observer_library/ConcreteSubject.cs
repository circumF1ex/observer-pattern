using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace observer_classes
{
    public class ConcreteSubject: ISubject
    {
        private List<ConcreteObserever> Observers = new List<ConcreteObserever>() { };
        private string State;
        public ConcreteSubject()
        {
           
        }
        public void registryObservers(ConcreteObserever O)
        {
            Observers.Add(O);
        }
        public void removeObservers(ConcreteObserever O)
        {
            int i = Observers.IndexOf(O);
            if (i >= 0) { Observers.RemoveAt(i); }
        }
        public void notifyObservers()
        {
            for (int i = 0; i < Observers.Count; i++)
            {
                Observers[i].update();
            }
        }
        public int getCounter(ConcreteObserever O)
        {
            return O.Counter;
        }
        public string getState()
        {
            if (State == null) { return "State is null"; }
            else { return $"State is:{State}"; }
        }
        public string setState(string State)
        {
            this.State = State;
            notifyObservers();
            return State;
        }
    }
}
