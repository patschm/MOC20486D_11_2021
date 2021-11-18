using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Principals
{
    class Program
    {
        static void Main(string[] args)
        {
            var myIdent = new GenericIdentity("Pat");
            var myPrin = new GenericPrincipal(myIdent, new string[] { "admin" });

            Thread.CurrentPrincipal = myPrin;

            var prin = Thread.CurrentPrincipal;
            var ident = prin.Identity;

            Console.WriteLine(ident.Name);
            DoeIets();
            Console.ReadLine();
        }

       // [Permission]
        private static void DoeIets()
        {
            if (Thread.CurrentPrincipal.IsInRole("admin"))
                Console.WriteLine( "Doet iets");
        }
    }
}
