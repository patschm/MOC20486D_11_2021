using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModellenBureau.Models
{
    public class PersonViewModel
    {
        //[Display(Name = "Idee")]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Voornaam verplicht")]
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [DisplayName("Lastt name")]
        //[StringLength(4, ErrorMessage = "Achternaam is te lang")]
        [RegularExpression("[A-Za-z]+",ErrorMessage = "Invalide format" )]
        [CapitalFirst(ErrorMessage = "Eeerste letter moet hoofdletter zijn")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
        [DataType(DataType.Password)]
        public string DirtySecrets { get; set; }
    }
}
