using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvcApp.Models;
//TODO: Create an MVC App that will display the records using ADO.NET Connected Model .
//Create a Table called Patient: ID, Name, Phone, BillAmount
//Create a ADOComponent with a single method called GetAllPatients which return DataTable
//Use that function in the controller and fill it into a view
//Display the View...


namespace SampleMvcApp.Controllers
{
    public class DataAccessController : Controller
    {
        
        public ActionResult Index()
        {
            var table = new ADOComponent().GetAll();
            return View(table);
        }
    }
}