using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace course_net_core_software.Models
{
    public class Friend
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required"), MaxLength(100, ErrorMessage = "No more than 100 charcters")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Required")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([A-Za-z0-9][^'!&\\#*$%^?<>()+=:;`~\[\]{}|/,₹€@ ][a-zA-z0-9-._][^!&\\#*$%^?<>()+=:;`~\[\]{}|/,₹€@ ]*\@[a-zA-Z0-9][^!&@\\#*$%^?<>()+=':;~`.\[\]{}|/,₹€ ]*\.[a-zA-Z]{2,6})$", ErrorMessage = "Please enter a valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must select a city")]
        public Province? City { get; set; }
    }
}
