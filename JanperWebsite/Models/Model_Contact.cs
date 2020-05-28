using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace JanperWebsite.Models
{
    public class Model_Contact
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(255)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(255)]
        [EmailAddress(ErrorMessage = "Email address is not valid")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Enquiry is required")]
        [Display(Name = "Enquiry")]
        public string AdditionalComments { get; set; }
    }
}