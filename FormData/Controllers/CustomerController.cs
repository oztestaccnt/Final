using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using AutoMapper;
using FormData.DataLayer;
using FormData.Models;
using FormData.Security;

namespace FormData.Controllers
{
    public class CustomerController : BaseController
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Register()
        {
            return View();
        }


       [HttpPost]
        public ActionResult Register(Customer customer)
        {

            using (NorthwndEntities db = new NorthwndEntities())
            {
                
                // verify and not to allow duplicate company names
                //  var result = db.Customers.Any(c => c.CompanyName == customer.CompanyName);

                if (db.Customers.Any(c => c.CompanyName == customer.CompanyName))
                {
                    return View();
                    
                }


                //encrypt psw
                customer.UserGuid = System.Guid.NewGuid();
                customer.Password = UserAccount.HashSHA1(customer.Password+customer.UserGuid);


                // saving data to DB
                db.Customers.Add(customer);
                db.SaveChanges();
                
                
                
                return RedirectToAction("Index", "Home");
            }
            //return View(); instead of this return we do return redirectToAction

        }



        public ActionResult SignIn()
        {
            using (NorthwndEntities db = new NorthwndEntities())
            {


                var companies = db.Customers.OrderBy(c=>c.CompanyName).ToList();

                ViewBag.CustomerId = new SelectList(companies, "CustomerId","CompanyName");
                return View();

            }
                
        }


        // method below will allow do login with password
        [HttpPost]
        public ActionResult SignIn(CustomerViewModel customerViewModel, string ReturnUrl)
        {
            using (NorthwndEntities db = new NorthwndEntities())
            {

                if (ModelState.IsValid)
                {

                    Customer c = db.Customers.Find(customerViewModel.CustomerId);
                    string hashEnteredPassword = UserAccount.HashSHA1(customerViewModel.Password + c.UserGuid);

                    if (hashEnteredPassword == c.Password)
                    {
                        FormsAuthentication.SetAuthCookie(c.CustomerID.ToString(), false);

                        // create cookie
                        HttpCookie httpCookie = new HttpCookie("role");
                        httpCookie.Value = "customer";
                        Response.Cookies.Add(httpCookie);
                        
                        TempData.Add("Message", "Login Succesful");
                        if (ReturnUrl != null)
                        {
                            return Redirect(ReturnUrl);
                        }

                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("Password","Incorrect Password");
                }

                    var companies = db.Customers.OrderBy(x => x.CompanyName).ToList();
                    ViewBag.CustomerId = new SelectList(companies, "CustomerId", "CompanyName");
                    
                }
            return View();
        }

            //var c = customer;
          
        

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
            
        }


        [Authorize]
        public ActionResult Account()
        {
            //check to see if user can/cannot login || if customer to change to manager, the 400 will be received
            if (Request.Cookies["role"].Value != "customer")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            Customer customer;
            using (var db = new NorthwndEntities())
            {
                customer = db.Customers.Find(UserAccount.GetUserId());
            }

            var customerEdit = Mapper.Map<CustomerEdit>(customer);

            ViewBag.CustomerId = customer.CustomerID;

            //CustomerEdit customerEdit = new CustomerEdit
            //{
            //    CompanyName = customer.CompanyName,
            //    ContactName = customer.ContactName,
            //    ContactTitle = customer.ContactTitle,
            //    Address = customer.Address,
            //    City = customer.City,
            //    Region = customer.Region,
            //    PostalCode = customer.PostalCode,
            //    Country = customer.Country,
            //    Phone = customer.Phone,
            //    Fax = customer.Fax,
            //    Email = customer.Email
            //};
            return View(customerEdit);
        }

        [Authorize]
        [HttpPost]
        
        public ActionResult Account(CustomerEdit customerEdit)
        {

            using (var db = new NorthwndEntities())
            {
                var customer = db.Customers.Find(UserAccount.GetUserId());


                customer.CompanyName = customerEdit.CompanyName;
                customer.ContactName = customerEdit.ContactName;
                customer.Address = customerEdit.Address;
                customer.City = customerEdit.City;
                customer.ContactTitle = customerEdit.ContactTitle;
                customer.Country = customerEdit.Country;
                customer.Email = customerEdit.Email;
                customer.Fax = customerEdit.Fax;
                customer.Phone = customerEdit.Phone;
                customer.PostalCode = customerEdit.PostalCode;
                customer.Region = customerEdit.Region;

                db.SaveChanges();
            }

            return RedirectToAction("Index","Home");
        }

    }
}