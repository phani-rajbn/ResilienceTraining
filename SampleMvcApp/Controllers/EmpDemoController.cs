using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvcApp.Models;
//ViewResult is a class that is derived from ActionResult, an abstract class for all kinds of Results that U want to render to the Requests. 
//HTTP uses 4 verbs while interacting with the SERVER: GET, PUT, POST, DELETE. Default is GET.
namespace SampleMvcApp.Controllers
{
    public class EmpDemoController : Controller
    {
        public ActionResult Index()
        {
            var context = new CSharpProjectEntities();
            var empData = from emp in context.tblEmployees
                          select emp;
            return View(empData.ToList());
        }

        public ActionResult Search(string id)
        {
            var context = new CSharpProjectEntities();
            var empId = int.Parse(id);
            var selected = context.tblEmployees.FirstOrDefault((e) => e.EmpID == empId);
            if (selected == null) throw new Exception("Employee not found!!!!");
            return View(selected);//Model is one single tblEmployee
        }

        [HttpPost]
        public ActionResult Search(tblEmployee submittedData)
        {
            var context = new CSharpProjectEntities();
            var selected = context.tblEmployees.Find(submittedData.EmpID);
            selected.EmpName = submittedData.EmpName;
            selected.EmpAddress  = submittedData.EmpAddress;
            selected.EmpPhone = submittedData.EmpPhone;
            selected.EmpSalary = submittedData.EmpSalary;
            selected.DeptId = submittedData.DeptId;
            context.SaveChanges();
            return RedirectToAction("Index");//Redirects the MVC to call Index function as an action
        }

        public ActionResult AddNew()
        {
            var newRow = new tblEmployee();
            return View(newRow);
        }

        [HttpPost]
        public ActionResult AddNew(tblEmployee submittedRec)
        {
            var context = new CSharpProjectEntities();
            context.tblEmployees.Add(submittedRec);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MyDelete (string id)
        {
            var context = new CSharpProjectEntities();
            var empId = int.Parse(id);
            var selected = context.tblEmployees.FirstOrDefault((e) => e.EmpID == empId);
            context.tblEmployees.Remove(selected);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}