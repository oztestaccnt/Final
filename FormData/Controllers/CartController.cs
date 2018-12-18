using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using FormData.DataLayer;
using FormData.Models;

namespace FormData.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddToCart(CartDTO cartDTO)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return Json(new { }, JsonRequestBehavior.AllowGet);
            }

            Cart sc = new Cart();
            sc.ProductID = cartDTO.ProductID;
            sc.CustomerID = cartDTO.CustomerId;
            sc.Quantity = cartDTO.Quantity;

            //saving changes(data) to Cart

            using (var db = new NorthwndEntities())
            {
                //checking if value that is about to get added, checking if the data already exists in DB(below)
                if (db.Carts.Any(c => c.ProductID == sc.ProductID && c.CustomerID == sc.CustomerID))
                {
                    Cart cart = db.Carts.FirstOrDefault(c =>
                        c.ProductID == sc.ProductID && c.CustomerID == sc.CustomerID);
                    cart.Quantity += sc.Quantity;

                    //this is not the best practice. Make sure you are not using more then one New in a Controller
                    // when running, it depends on the newly created object(new)
                    // best practice is to reuse already created object: in our case this is Cart sc(showing above)                    
                    sc = new Cart()
                    {
                        CartID = cart.CartID,
                        ProductID = cart.ProductID,
                        CustomerID = cart.CustomerID,
                        Quantity = cart.Quantity
                        
                    };
                }
                else
                {
                    db.Carts.Add(sc);
                }
                db.SaveChanges();
            }

            //better way to rewrite code that is showing above: need to get the rest from Mark 

            //using (NorthwndEntities db = new NorthwndEntities())

            //{
            //    Cart cart = db.Carts.SingleOrDefault(c => c.ProductID == cartDTO.ProductID && c.CustomerID==sc.CustomerID)
            //}

            return Json(sc, JsonRequestBehavior.AllowGet); 
        } 
    }
}