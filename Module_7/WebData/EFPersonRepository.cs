using EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebData
{
    public class EFPersonRepository : IPersonRepository
    {
        private ACMEContext context;

        public EFPersonRepository(ACMEContext ctx)
        {
            context = ctx;
        }
        public void Create(Person entity)
        {
            context.People.Add(entity);
        }

        public void Delete(Person entity)
        {
            var dbp = context.People.Find(entity.Id);
            //context.People.Remove(entity);
            context.Entry(dbp).State = EntityState.Deleted;
        }

        public IQueryable<Person> GetAll()
        {
            return context.People
                .Include(p => p.PersonCompanies)
                .ThenInclude(pc => pc.Company)
                .OrderBy(p=>p.Id)
                .AsNoTracking();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Person entity)
        {
            var dbp = context.People.Find(entity.Id);
            context.Entry(dbp).CurrentValues.SetValues(entity);
        }
    }
}
