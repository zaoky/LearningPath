using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Learning_Path.Models;

namespace Learning_Path.Controllers
{
    public class CustomersController : Controller
    {
        readonly List<Customer> Customers = new List<Customer>
            {
                new Customer {Id=1,  Name = "Jhon Smith"},
                new Customer {Id=2, Name = "Mary Williams"}
            };
        // GET: Customers
        public ActionResult Index()
        {
            return View(Customers);
        }

        public ActionResult Details(int id)
        {
            Customer cust = this.Customers.FirstOrDefault(c => c.Id == id);
            return View(cust ?? new Customer {Id = -1, Name = "Customers"});
        }
    }
}