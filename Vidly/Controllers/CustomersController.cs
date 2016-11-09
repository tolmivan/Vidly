using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
            return View(customers);
        }

        // GET: Customers/Detail/1
        public ActionResult Detail(int id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return new HttpNotFoundResult();
            }
            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);  
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var custumerInDb = _context.Customers.Single((c => c.Id == customer.Id));

                custumerInDb.Name = customer.Name;
                custumerInDb.Birthdate = customer.Birthdate;
                custumerInDb.MembershipTypeId = customer.MembershipTypeId;
                custumerInDb.IsSubsribedToNewsletter = customer.IsSubsribedToNewsletter;

            }

            
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
            
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault((c => c.Id == id));

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}