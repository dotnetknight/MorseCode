using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MorseCode.Models
{
    public class SetData
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter text")]
        [Display(Name = "Text")]
        public List<string> Vals = new List<string>();
    }
}