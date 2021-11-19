using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Veilig.IdentityWare
{
    public class MyDbContext : IdentityDbContext<MyUser>
    {
        public MyDbContext(DbContextOptions opts)
            : base(opts)
        {

        }
    }
}
