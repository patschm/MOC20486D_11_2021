using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controleurs
{
    public class MyActionFilter : ActionFilterAttribute
    {
        //private ILogger _logger;

        //public MyActionFilter(ILogger logger)
        //{
        //    _logger = logger;
        //}

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation("3 Start render ActionResult");
            Console.WriteLine("3 Start render ActionResult");
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("4 Finish render ActionResult");
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("1 Start executing action");
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("2 Finish executing action");
        }
    }
}
