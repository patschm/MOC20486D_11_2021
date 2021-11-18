using System;
using System.Collections.Generic;

#nullable disable

namespace EF
{
    public partial class Person
    {
        public Person()
        {
            PersonCompanies = new HashSet<PersonCompany>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public virtual ICollection<PersonCompany> PersonCompanies { get; set; }
    }
}
