using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Babbeldoos
{
    public class BabbelService : Hub
    {
        public async Task MeldAan(string nick)
        {
            await Clients.All.SendAsync("victim", $"{nick} heeft zich aangemeld");
        }
        public async Task Zend(string nick, string bericht)
        {
            await Clients.All.SendAsync("toeter", $"{ nick}> { bericht}");
        }

    }
}
