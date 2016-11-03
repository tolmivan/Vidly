using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }

        // GET: Customers/Detail/1
        public ActionResult Detail(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return new HttpNotFoundResult();
            }
            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer() {Id = 0, Name = "John Smith"},
                new Customer() {Id = 1, Name = "Mary Williams"}
            };
            return customers;
        }
    }
}