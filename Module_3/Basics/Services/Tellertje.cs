using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basics.Services
{
    public class Tellertje : ITellertje
    {
        private int _counter = 0;

        public void Increment()
        {
            Console.WriteLine(++_counter);
        }
    }
}
