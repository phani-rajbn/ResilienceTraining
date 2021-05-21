using System;
using System.Threading;
//MultiThreading and Garbage Collection.
/*
 * Allowing multiple paths of execution to happen parallelly. 
 * What is a process=> A Process is a private address space created when an Instance of an EXE begins. Inside this comes UR code, dependencies, memory, execution paths and things that are required to execute Ur program.
 * What is a Thread=>Thread is the path of execution which makes UR program run. There will be atleast one thread per process, sometimes supported by multiple Threads. The thread that starts when the process begins is called as MAIN Thread. When the Main thread completes its job, the process ends and the app instance terminates. Every thread is associated with a function, which defines the functionality of the thread called Thread function. Main is the thread function for Main thread. In lower Win32 programming, the Main thread is a UI Thread. For complex application and scenarios where the main thread will block the UI and will take a long time to process, in such cases, developers create small work based threads(Worker Threads) which will do the jobs parallely and make the application active instead of a frozen state.   
 * In .NET, Multi threading is achieved using a Class called Thread. The Thread is associated with a delegate called ThreadStart which points to the function UR thread is supposed to call when it begins.
 * Sleep is a static method of the Thread class used to pause the thread execution for a speculated interval of time in ms.
 * Suspend method of the Thread class can be used to suspend a given thread and it will be resumed only after U explicitly call the Resume method.
 * If U dont want the thread creation, U can go for Async functions that will internally use ThreadPool provided by .NET and use one of the threads within it. 
 */
namespace SampleConApp.Day_8
{
    class MultiThreading
    {
        static int pointer = 0;
        static void BigFunc() 
        {
            //lock is a keyword in C# to lock the resource and stop other threads to access it while one is using it. It is also called as MUTEX(Mutually and Exclusive). However, Mutex can be used on multiple processes, lock is used on one process only. This is represented by a class called MONITOR. 
            lock (typeof(MultiThreading))
            {
                Console.WriteLine($"Resource utilized by {Thread.CurrentThread.Name}");
                pointer++;
                Console.WriteLine("Pointer incremented: " + pointer);
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Big Thread Beep #{i}");
                    Thread.Sleep(1000); //Delay the function for a sec...
                }
                pointer--;
                Console.WriteLine("Pointer decremented: " + pointer);
                Console.WriteLine($"Resource utilized by {Thread.CurrentThread.Name}");
            }    
        }

        static void SmallFunc(Thread th)
        {
            for (int i = 0; i < 5; i++)
            {
                
                Console.WriteLine($"Small Thread Beep #{i}");
                Thread.Sleep(1000); //Delay the function for a sec...
            }
        }
        static void Main(string[] args)
        {
            //Started by one User...
            Thread th = new Thread(BigFunc);//Delegate instance...
            th.Name = "FirstUser";
            th.Start();//This makes the BigFunc execute and ask the Main to execute the next line...
            //Started by another User...
            Thread other = new Thread(BigFunc);
            other.Name = "Other User";
            other.Start();
            SmallFunc(th);
        }
    }
}
