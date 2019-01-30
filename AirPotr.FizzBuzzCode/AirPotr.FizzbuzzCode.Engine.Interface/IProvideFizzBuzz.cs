using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirPotr.FizzbuzzCode.Engine.Interface
{
    public interface IProvideFizzBuzz
    {

        StringBuilder BuildScenarioString( int inRange,IDictionary<string,int> stringToPrint);
    }
}
