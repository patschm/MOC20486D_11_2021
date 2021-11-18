using EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebData
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ACMEContext context;

        public EFUnitOfWork(ACMEContext ctx)
        {
            context = ctx;
            People = new EFPersonRepository(context);
        }

        public IPersonRepository People { get; set; }
       

        public ICompanyRepository Companies { get; set; }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
