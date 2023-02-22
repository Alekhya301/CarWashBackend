using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }


        [StringLength(50, MinimumLength = 0)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is required")]
        [StringLength(60)]
        //[DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [StringLength(10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "PhoneNumber")]
        [StringLength(10)]
        [Required(ErrorMessage = "PhoneNumber is required")]
        [RegularExpression("[6-9][0-9]{9}", ErrorMessage = "Mobile Number must begin with 6,7,8 or 9")]
        public string PhoneNumber { get; set; }


        [Required]
        [RegularExpression(@"Customer|Washer")]
        public string Role { get; set; }

        [Required]
        [RegularExpression(@"Active|InActive")]
        public string IsActive { get; set; }
       
    }
}
