using EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebData
{
    public interface IPersonRepository : IRepository<Person>
    {
    }
}
