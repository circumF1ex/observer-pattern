using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace observer_lib
{
    public interface ISubject
    {
        void registryObservers(IObserver O);
        void removeObservers(IObserver O);
        void notifyObservers();
        

    }
}
