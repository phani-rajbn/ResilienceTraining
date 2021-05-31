using System;
using SampleMvcApp.Models;
using System.Web.Mvc;//This namespace contains all the classes and interfaces required for the MVC App Development. 
//Controller is simply a .NET Class that implements an interface called IController. however in our application, UR class will derived from a Class called Controller which contains the default implementations for IController
//URController -> Controller -> ControllerBase -> IController. 
//Some Apps will implement their own version of IController interface for customization and optimization purposes.
namespace SampleMvcApp.Controllers
{
    public class FirstExampleController : Controller
    {
        public string DisplayMessage()//Action is the term used for a public function of a Controller. 
        {
            string model = "My First MVC Project";
            return model;
        }

        public Employee DisplayEmployee()
        {
            var emp = new Employee { EmpAddress = "Bangalore", EmpID = 123, EmpName = "Phaniraj" };//create the model
            return emp;//HTTP is a text/string based protocol, any object U return will be converrted to string and displayed on the browser. 
        }

        public ViewResult Display()
        {
            var emp = new Employee { EmpAddress = "Bangalore", EmpID = 123, EmpName = "Phaniraj" };//create the model
            return View(emp);
        }
    }
}