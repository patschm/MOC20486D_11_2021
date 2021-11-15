using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basics.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        public ITellertje CreateBlaBla()
        {
            return new BlaBla();
        }

        public ITellertje CreateTellertje()
        {
            return new Tellertje();
        }
    }
}
