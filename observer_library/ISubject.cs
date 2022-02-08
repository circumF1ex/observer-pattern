using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace observer_classes
{
    public interface ISubject
    {
        void registryObservers(ConcreteObserever O);
        void removeObservers(ConcreteObserever O);
        void notifyObservers();
        

    }
}
