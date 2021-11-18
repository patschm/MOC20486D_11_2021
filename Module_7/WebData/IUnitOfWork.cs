using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebData
{
    public interface IUnitOfWork
    {
        IPersonRepository People { get; set; }
        ICompanyRepository Companies { get; set; }

        Task SaveAsync();
    }
}
