using Microsoft.AspNetCore.Mvc;
using Rustiek.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rustiek.Controllers
{
    [Route("people")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new Person[] { new Person { Firstname = "Jan", Lastname = "Peters", Id = 1 } });

        }
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            return Ok(new Person { Firstname = "Jan", Lastname = "Peters", Id = id } );

        }
        [HttpPost]
        public IActionResult Post([FromBody]Person p)
        {
            p.Id = 200;
            return Accepted("/people/" + p.Id);
        }
    }
}
