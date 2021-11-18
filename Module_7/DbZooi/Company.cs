using System;
using System.Collections.Generic;

#nullable disable

namespace EF
{
    public partial class Company
    {
        public Company()
        {
            PersonCompanies = new HashSet<PersonCompany>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PersonCompany> PersonCompanies { get; set; }
    }
}
