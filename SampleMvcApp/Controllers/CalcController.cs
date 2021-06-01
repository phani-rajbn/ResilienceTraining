using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*
 * A View can be associated with only one type of model. However if U want other types of data to be sent to the View, U have to do it in different ways.
 * ViewBag, ViewData, TempData->Ways of sharing data to a view other than the Model from Controller
 * ViewBag: it uses dynamic data type and U need not BOX or UNBOX the values in the controller and the View respectively. 
 * ViewData: It stores the data as object dictionary, so U should BOX AND UNBOX while U use them. ViewData is used when U have large quantity of data to be passed.
 * Both ViewData and ViewBag have their scope to the action method that it is created. They cannot be shared b/w multiple actions.
 * TempData is something very similar to ViewData but it can be shared among the Actions, but U should tell the MVC to preserve the values before U use them. 
 * Forms Collection, parameters, TempData->To send the info to the Controller from the view. 
 * ViewBag is local to the Action to which it is created. 
 */
namespace SampleMvcApp.Controllers
{
    public class CalcController : Controller
    {
        static double result = 0.0;
        public ActionResult Index()
        {
            //ViewBag.ResultValue = result;
            //ViewData["ResultValue"] = result;
            return View();
        }

        private double getResult(double v1, double v2, string operand)
        {
            switch (operand)
            {
                case "+":
                    return v1 + v2;
                case "-":
                    return v1 - v2;
                case "X":
                    return v1 * v2;
                case "/":
                    return v1 / v2;
            }
            return 0;
        }
        public ActionResult Result(FormCollection collection)
        {
            var firstValue = double.Parse(collection["FirstValue"]);
            var secondValue = double.Parse(collection["SecondValue"]);
            var operand = collection["Operand"];
            result = getResult(firstValue, secondValue, operand);
            return RedirectToAction("Index");
        }

        public ActionResult GetResult(string FirstValue, string SecondValue, string Operand)
        {
            var firstValue = double.Parse(FirstValue);
            var secondValue = double.Parse(SecondValue);
            result = getResult(firstValue, secondValue, Operand);
            TempData["ResultValue"] = result;
            TempData.Keep();//Preserves the value for the next action and will be for a short duration
            return RedirectToAction("Index");
        }

    }
}