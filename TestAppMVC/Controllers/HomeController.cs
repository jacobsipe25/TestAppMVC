using System;
using System.Runtime.Caching;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using TestAppMVC.Models;

namespace TestAppMVC.Controllers
{
    public class HomeController : Controller //inherits the controller baseclass
    {
        ObjectCache obj = MemoryCache.Default;
        List<Customer> customers;
        public HomeController()
        {
            customers = obj["customers"] as List<Customer>;
            if (customers == null)
            {
                customers = new List<Customer>();


            }
        }
        public void Saveobj(){
                obj["customers"] = customers;
            }
            
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
        //public ActionResult ViewCustomer(Customer postedCustomer)
        //{
        //    //Send ID and retrieve 
        //    Customer customer = new Customer();
        //    customer.ID = Guid.NewGuid().ToString();
        //    customer.Name = postedCustomer.Name;
        //    customer.Telephone = postedCustomer.Telephone;
        //    return View(customer);
        //}
        public ActionResult ViewCustomer(string id)
        {
            Customer customer = customers.FirstOrDefault(c => c.ID == id);
            if (customer == null)
            {
                return HttpNotFound();
           
            }
            else
            {
                return View(customer);
            }
        }
        public ActionResult AddCustomer()
        {
            return View();
        }
       [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            customer.ID = Guid.NewGuid().ToString();
            customers.Add(customer);
            Saveobj();
            return RedirectToAction("CustomerList");
        }
        public ActionResult CustomerList()
        {
            return View(customers);
        }
        public ActionResult EditCustomer(string id)
        {
            Customer customer = customers.FirstOrDefault(c => c.ID == id);
            if (customer == null)
            {
                return HttpNotFound();

            }
            else
            {
                return View(customer);
            }
        }
        [HttpPost]
        public ActionResult EditCustomer(Customer customer, string id)
        {
            var customertoEdit = customers.FirstOrDefault(c => c.ID == id);
            if (customertoEdit == null)
            {
                return HttpNotFound();

            }
            else
            {
                customertoEdit.Name = customer.Name;
                customertoEdit.Telephone = customer.Telephone;
                Saveobj();
                return RedirectToAction("CustomerList");
            }
        }
    }
    //may want more controllers

}