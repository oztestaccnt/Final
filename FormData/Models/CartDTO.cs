using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormData.Models
{
    public class CartDTO
    {
        public int ProductID { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }

    }
}