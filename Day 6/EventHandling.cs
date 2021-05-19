using System;
using System.Collections.Generic;

//Events are call back functions which are instances of the delegates. They are invoked like Triggers of SQL server. When an action is performed by the caller, the event is triggered. Click is an event, TextChange is an event, when the user of the app performs that action, UR method gets invoked. Else U dont invoke the method.
//event is the keyword used to declare an event. 
//.NET offers a ready to use delegates which can be used in ur application, however for our practice, we will create a new delegate which is  void delegate and takes string as arg...
namespace SampleConApp.Day_6
{
    delegate void EventHandler(string message);

    class CRUDOperation
    {
        //internal members are available to all the classes within the project...
        internal event EventHandler callBack = null;

        public CRUDOperation(EventHandler callBack)
        {
            this.callBack = callBack;
        }
        HashSet<string> values = new HashSet<string>();
        internal void Add(string value)
        {
            if(values.Add(value))
            {
                if(callBack != null)
                {
                    callBack("Added Successfully");
                }
            }
            else
            {
                callBack("Duplicate value");
            }
        }

        internal void Delete(string value)
        {
            if (values.Remove(value))
                callBack("Removed Successfully");
            else
                callBack("No object found to delete");
        }

    }
    class EventHandling
    {
        static void Main(string[] args)
        {
            CRUDOperation myApp = new CRUDOperation((msg) => Console.WriteLine(msg));
            myApp.Add("Apples");
            myApp.Add("Apples");
            myApp.Add("Apples");
            myApp.Delete("Apples");

        }

       
    }
}
