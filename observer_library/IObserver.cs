using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace observer_classes
{
    public interface IObserver
    {
        int update();
        int display();
    }
    
}
