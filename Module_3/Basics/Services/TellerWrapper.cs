using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basics.Services
{
    public class TellerWrapper
    {
        private ITellertje _teller;

        public TellerWrapper(ITellertje teller)
        {
            _teller = teller;
        }
        public void Increment()
        {
            _teller.Increment();
        }
    }
}
