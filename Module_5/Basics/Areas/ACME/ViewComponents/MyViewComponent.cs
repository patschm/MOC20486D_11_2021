using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basics.Areas.ACME.ViewComponents
{
    [ViewComponent]
    public class MyFraaieTagViewComponent: ViewComponent
    {
        public string StudentFirstName { get; set; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            await Task.FromResult(0);
            return  View();
        }

    }
}
