using MVC_Application.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Application.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        static List<Employee> employee = new List<Employee>();
        // GET: Home
        public ActionResult Index()
        {
            return View(employee.ToList());
        }
     
        public ActionResult Delete(int id)
        {
            Employee item = employee.Where(model => model.EmployeeId == id).SingleOrDefault();
            employee.Remove(item);
            return View("Index");
        }
        public ActionResult Create(int id=0 )
        {
            if(id == 0)
            {
                return View();
            }
            else
            {
                Employee item = employee.Where(model => model.EmployeeId == id).FirstOrDefault();
                return View(item);             
            }
        }
        [HttpPost]

        public ActionResult Create(Employee emp)

        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View("Create", emp);
                }
                employee.Add(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
    }
}