using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace JanperWebsite.Models
{
    public class Model_TradeContact
    {

        [Display(Name = "CustomerName")]
        public string CustomerName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }


        [StringLength(255)]
        [Display(Name = "Address")]
        public string Address { get; set; }


        [StringLength(255)]
        [Display(Name = "Suburb")]
        public string Suburb { get; set; }


        [StringLength(255)]
        [Display(Name = "State")]
        public string State { get; set; }


        [Display(Name = "pCode")]
        public string pCode { get; set; }

        [AllowHtml]
        public string samples { get; set; }

        public bool Successful = false;


    }
}