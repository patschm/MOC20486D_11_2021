using System;
using System.Collections.Generic;

#nullable disable

namespace EF
{
    public partial class PersonCompany
    {
        public int PersonId { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Person Person { get; set; }
    }
}
