using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModellenBureau.Models
{
    public class CapitalFirstAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return char.IsUpper(value.ToString().First());
        }
    }
}
