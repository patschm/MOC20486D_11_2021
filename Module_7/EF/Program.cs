using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EF
{
    class Program
    {
        static void Main(string[] args)
        {

            string qq = "SELECT * FROM dbo.People ";
            qq += "WHERE id > 1";
            qq += " ORDER BY FirstName";

            ACMEContext ctx = new ACMEContext();
            
            var query =  ctx.People.Select(p => new { p.FirstName, p.LastName });
            var q1 = ctx.People;

            var q2 = from p in q1 where p.Id == 1 select new { p.FirstName, p.LastName };

            var q3 = q2.OrderBy(p => p.FirstName);

            var list = q3.ToList();
            foreach(var p in q3)
            {
               // Console.WriteLine($"{p.FirstName} {p.LastName}");
            }
            var q6 = ctx.People.Include(px => px.PersonCompanies).ThenInclude(pc => pc.Company);

            foreach (var p in q6 )
            {
                Console.WriteLine(p.GetType().Name);
                Console.WriteLine($"{p.Id} {p.FirstName} {p.LastName}");
                foreach(PersonCompany pc in p.PersonCompanies)
                {
                    Console.WriteLine($"\t{pc.Company.Name}");
                }
            }
        }
    }
}
