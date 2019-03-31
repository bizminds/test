using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizminds.Models
{
    public class PalindromeRequest
    {
        [Display(Name = "Palindrome", Description = "Palindrome String")]
        [Required()]
        public string Value { get; set; }
    }

}
