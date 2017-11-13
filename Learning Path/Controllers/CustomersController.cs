using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Learning_Path.Models;

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