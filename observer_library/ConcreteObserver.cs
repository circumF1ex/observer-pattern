using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace observer_classes
{
    public class ConcreteObserever: IObserver
    {
        public int Counter = 0;
        public int update()
        {
            this.Counter++;
            return this.Counter;
        }
        public int display()
        {
            return this.Counter;
        }
    }
}
