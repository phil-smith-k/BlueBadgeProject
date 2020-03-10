using Basketball.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Models
{
    public class CreateNewPlayer
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least one character.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field. Limit is 50.")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least one character.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field. Limit is 50.")]
        public string LastName { get; set; }
        public string FullName { get => FirstName + " " + LastName; }

        
        public string Team { get; set; }
    }
}
