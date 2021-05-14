using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp.Day_3
{

    class Patient
    {
        //Automatic Properties introduced in C# 3.0....
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public long PatientContact { get; set; }
        public DateTime Date { get; private set; } = DateTime.Now;  //Default Values...
    }
    class NewClassImpl
    {
        static void Main(string[] args)
        {
            Patient pt = new Patient { PatientContact = 9945205684, PatientID = 111, PatientName = "Phaniraj"  };
            Console.WriteLine($"The Name of the patient is {pt.PatientName} who can be contacted at {pt.PatientContact} and was tested on {pt.Date.ToLongDateString()}");
        }
    }
}
