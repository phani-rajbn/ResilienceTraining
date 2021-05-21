using System;
using System.Diagnostics;
using System.Threading;
/*
 * Foreground threads and background threads:
 * Foreground threads are threads which make the Calling thread wait till it completes its job. 
 * Background threads cannot make the calling thread to pause till it completes. In this case, if the calling thread finishes the job, it will not wait till the child thread completes.  
 * IsBackground property should be set to true if U want a thread to be background thread, by default it is false. 
 * Threads are resource bound, it will take lot of effort internally to work with kernel memory within the OS. So for small tasks U could use ThreadPool, a bunch of ready to use threads that is already created by .NET Framework in its CLR to maintain its environment. U dont need to explicitly create new threads. 
 */
namespace SampleConApp.Day_8
{
    class BackgroundThreads
    {
        static void BigFunc()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Big Thread Beep #{i}");
                Thread.Sleep(1000);
            }
        }
        static void SmallFunc()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Small Thread Beep #{i}");
                Thread.Sleep(1000); //Delay the function for a sec...
            }
        }
        static void Main(string[] args)
        {
            //backgroundThreadDemo();
            //threadPoolExample();
            performanceMonitor();
        }

        private static void performanceMonitor()
        {
            Stopwatch watch = new Stopwatch();
            Console.WriteLine("Using Thread:");
            watch.Start();
            MethodWithThread();
            watch.Stop();
            Console.WriteLine($"Time while using Threads: {watch.ElapsedTicks}");
            watch.Start();
            MethodWithThreadPool();
            watch.Stop();
            Console.WriteLine($"Time while using Pool: {watch.ElapsedTicks}");
            Console.Read();
        }

        private static void MethodWithThreadPool()
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Test);
            }
        }

        public static void Test(object obj)
        {
            //Console.WriteLine("Test created and closed");
        }
        private static void MethodWithThread()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread th = new Thread(Test);
            }
        }

        private static void threadPoolExample()
        {
            //ThreadPool is a pool of threads that is created by .NET for managing itself. However not all threads will be engaged. So as a developer U can use one or more threads to do tasks that will be done parallelly without an explicit creation of new threads. 
            int total, used;
            ThreadPool.GetMaxThreads(out total, out used);
            Console.WriteLine($"Total Threads: {total}");
            Console.WriteLine($"Available Ports : {used}");

            //Threads in the threadPool are all background threads. So in this case, if the Main function returns, Ur App will terminate and not wait for any background threads to complete. So ThreadPool should be used on those tasks which doesnt need completion like logs, background tasks and so forth. 
            ThreadPool.QueueUserWorkItem((obj) =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Thread executed using thread Pool");
                    Thread.Sleep(1000);
                }
            });
            //As the threads that u use is managed by .NET itself, it is more optimized than the threads that we create explicitly in our application. 
            //Thread.CurrentThread.Join();
        }

        private static void backgroundThreadDemo()
        {
            Thread th = new Thread(BigFunc);
            th.IsBackground = true;
            th.Start();
            SmallFunc();
            Console.WriteLine("End of the Application");
        }
    }
}
