using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvcApp.Models;

/*
 * Asynchronous JS and XML is called as AJAX. It allows to make single page applications. In this case, instead of the whole page going to the server for processing, a part or partial page would be loaded. This makes the User feel that he is viewing a single page and a part of it has been updated. Hense the name as SINGLE PAGE APPLICATION(SPA).
 */
namespace SampleMvcApp.Controllers
{
    public class AjaxController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult AllEmployees()
        {
            var context = new CSharpProjectEntities();
            var data = context.tblEmployees.Take(15).ToList();
            return PartialView(data);
        }

        //DEFAULT is HTTPGET..
        public PartialViewResult Details(string id)
        {
            var empid = int.Parse(id);
            var context = new CSharpProjectEntities();
            var selected = context.tblEmployees.FirstOrDefault((e) => e.EmpID == empid);
            if (selected == null) throw new Exception("Employee not found!!!!");
            var depts = context.tblDepts.ToList();
            ViewBag.Depts = depts;
            return PartialView(selected);
        }

        [HttpPost]//Called when the Form is POSTED...
        public ActionResult Details(tblEmployee emp)
        {
            //Update the record...
            var context = new CSharpProjectEntities();
            var selected = context.tblEmployees.FirstOrDefault((e) => e.EmpID == emp.EmpID);
            selected.EmpName = emp.EmpName;
            selected.EmpAddress = emp.EmpAddress;
            selected.EmpSalary = emp.EmpSalary;
            selected.EmpPhone = emp.EmpPhone;
            selected.DeptId = emp.DeptId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}