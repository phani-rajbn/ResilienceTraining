using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SampleWebApi.Models;
namespace SampleWebApi.Controllers
{
    public class EmpDataController : ApiController
    {
        public List<Employee> GetAll()
        {
            return new ADOComponent().GetAllEmployees();
        }

        public Employee GetEmployee(string id)
        {
            return new ADOComponent().Find(int.Parse(id));
        }

        [Route("api/Depts")]//Getting
        public List<Dept> GetAllDepts()
        {
            return new ADOComponent().GetAllDepts();
        }

        [HttpPost]//For adding 
        public bool AddEmployee(Employee emp)
        {
            return new ADOComponent().Insert(emp);
        }

        [HttpPut]//Used for updating
        public bool UpdateEmployee(Employee emp)
        {
            return new ADOComponent().Update(emp);
        }
    }
}
