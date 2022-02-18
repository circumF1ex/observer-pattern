using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace observer_lib
{
    public interface IObserver
    {
        void update(float temp, float humidity, float pressure);
    }
    
}
