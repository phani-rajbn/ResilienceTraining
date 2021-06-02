using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvcApp.Models;
namespace SampleMvcApp.Controllers
{
    //Example to send the data as JSOn instead of a View, good for API calls within the MVC App
    public class ApiController : Controller
    {
        // GET: Api
        [HttpGet]
        public JsonResult Index()
        {
            var component = new ADOApiComponent();
            var data = component.GetAllEmployees();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
//HTML->WebAPI->C# code->ADO.NET->SQL SERVER.