using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basics.Services
{
    public interface IUnitOfWork
    {
        ITellertje CreateTellertje();
        ITellertje CreateBlaBla();
    }
}
