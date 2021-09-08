using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore1.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string City { get; set; }
        [Display(Name = "Is Deleted")]
        public bool isDeleted { get; set; }
    }
}
