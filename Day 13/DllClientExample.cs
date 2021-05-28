using System;
using SampleDll;
using System.Data;

namespace SampleConApp.Day_13
{
    class UsingDllExample
    {
        static void Main(string[] args)
        {
            var component = ComponentFactory.GetComponent();
            var table = component.GetAllEmployees();
            foreach(DataRow row in table.Rows)
            {
                Console.WriteLine(row[1]);//2nd column data
            }
        }
    }
}