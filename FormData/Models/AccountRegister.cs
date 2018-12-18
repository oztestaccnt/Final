using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FormData.DataLayer;

namespace Northwind.Models
{

    public class BaseModel
    {
        public string Title { get; set; }
    }

    public class AccntRegister
    {
        [Required]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Minimum 5 characters required")]
        public string Password { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Contact Name")]
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

    }


    public class HomeModel
    {
        public string Message { get; set; }
    }


}