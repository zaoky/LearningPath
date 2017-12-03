using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Learning_Path.Models;
using Learning_Path.ViewModels;

namespace Learning_Path.Controllers
{
    public class CustomersController : Controller
    {
        #region Fields
        private ApplicationDbContext _context;
        #endregion

        #region Constructor

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        #endregion
       
        #region Actions
        // GET: Customers
        public ActionResult Index()
        {
            List<Customer> customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            Customer cust = this._context.Customers.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);
            return View(cust ?? new Customer { Id = -1, Name = "Customers" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // to avoid cross site request forgery
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                CustomerFormViewModel viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                Customer customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            Customer cust = this._context.Customers.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);
            CustomerFormViewModel formViewModel = new CustomerFormViewModel
            {
                Customer = cust,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return cust == null ? (ActionResult)HttpNotFound() : View("CustomerForm", formViewModel);
        }

        public ActionResult New()
        {
            List<MembershipType> membershipTypes = _context.MembershipTypes.ToList();
            CustomerFormViewModel formViewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer ()
            };
            return View("CustomerForm", formViewModel);
        }
        #endregion

        #region Override
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
        #endregion

      
    }
}