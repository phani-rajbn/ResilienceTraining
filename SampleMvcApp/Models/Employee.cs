using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMvcApp.Models
{
    public class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string  EmpAddress { get; set; }

        public override string ToString()
        {
            return $"<h1>Name: {EmpName}</h1><hr/>";
        }
    }
}