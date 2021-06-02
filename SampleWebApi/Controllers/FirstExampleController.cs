using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleWebApi.Controllers
{
    public class FirstExampleController : ApiController
    {
        public List<String> GetData()
        {
            return new List<string>
            {
                "Apple", "Mango", "Orange", "Banana"
            };
        }
    }
}
