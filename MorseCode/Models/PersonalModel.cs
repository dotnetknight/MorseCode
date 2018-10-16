using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MorseCode.Models
{
    public class PersonModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter text")]
        [Display(Name="Text:")]
        public string Name { get; set; }

        public int DeValue { get; set; }
    }
}