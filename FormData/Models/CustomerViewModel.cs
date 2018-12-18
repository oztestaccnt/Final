using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormData.Models
{
    public class CustomerViewModel
    {
        //adding properties

        public int CustomerId { get; set;  }

        [Required(ErrorMessage = "Password required")]
        public string Password { get; set;  }

    }

    //example on how to create your own validation
    public class MyValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return false;
        }

        
    }
}