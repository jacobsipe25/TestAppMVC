using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAppMVC.Models;

namespace TestAppMVC.Controllers
{
    public class HomeController : Controller //inherits the controller baseclass
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.SomethingNew = "Hello world";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //public ActionResult ViewCustomer(string Name, string Telephone)
        //{
        //    Customer customer = new Customer();
        //    customer.ID = Guid.NewGuid().ToString();//
        //    customer.Name = Name;
        //    customer.TelephoneNumber = Telephone;
        //    return View(customer);
        //}
        public ActionResult ViewCustomer(Customer postedCustomer)
        {
            Customer customer = new Customer();
            customer.ID = Guid.NewGuid().ToString();
            customer.Name = postedCustomer.Name;
            customer.Telephone = postedCustomer.Telephone;
            return View(customer);
        }
        public ActionResult AddCustomer()
        {
            return View();
        }
        public ActionResult CustomerList()
        {
            List<Customer> customers = new List<Customer> ();
            customers.Add(new Customer() { Name = "Fred", Telephone = "91987" });
            customers.Add(new Customer() { Name = "Jasob", Telephone = "91985" });
            return View(customers);
        }
    }
    //may want more controllers

}