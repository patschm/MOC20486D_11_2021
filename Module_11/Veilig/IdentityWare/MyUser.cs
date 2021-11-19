using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Veilig.IdentityWare
{ 
    public class MyUser : IdentityUser
    {
        public string Hobby { get; set; }
    }
}
