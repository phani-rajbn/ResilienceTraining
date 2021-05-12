using System;
//Arrays are reference types in C#, they are objects of a class called System.Array. It gives U methods and properties to access the elements of the array and get runtime info about the array like size, rank, length of each bound and many more... 
namespace SampleConApp
{
    class ArraysExample
    {
        static void Main(string[] args)
        {
            //datatype [] identifier = values....
            //simpleArray();
            //multiDimensionalArray();
            //jaggedArrayExample();
            //Explore : How to create an array dynamically which means U dont know the data type, size as well as dimensions of the array at compile time. Tip: Use Array Class directly. 
        }

        private static void jaggedArrayExample()
        {
            //Array of arrays is called as Jagged Array. 
            //A School is an array of classrooms where each room has an array of students in it. 
            //U have a fixed no of rows and variable no of columns in each row...
            int[][] School = new int[3][];//3 rows...
            School[0] = new int[] { 45, 55, 66, 78 };
            School[1] = new int[] { 66, 78, 98 };
            School[2] = new int[] { 86, 96, 55, 47, 46, 19, 45 };

            //Display it in matrix format:
            for (int i = 0; i < School.Length; i++)
            {
                for(int j = 0; j < School[i].Length; j++)
                    Console.Write(School[i][j] + " ");
                Console.WriteLine();
            }
        }

        //Use camel casing for private methods in C# programming
        private static void multiDimensionalArray()
        {
            int fD = MyConsole.GetNumber("Enter the first Dimension");
            int sD = MyConsole.GetNumber("Enter the Second Dimension");
            int[,] TwoD= new int[fD, sD];
            for (int i = 0; i < TwoD.GetLength(0); i++)
            {
                Console.WriteLine("Entering the values of row " + (i + 1));
                for (int j = 0; j < TwoD.GetLength(1); j++)
                {
                    TwoD[i,j] =MyConsole.GetNumber($"Enter the value for {i},{j}th Position");
                }
                Console.WriteLine("Row is filled");
            }
            Console.WriteLine("All the data is filled");
            Console.WriteLine("The Rank of the Array: " + TwoD.Rank);
            Console.WriteLine("The Size of the Array: " + TwoD.Length);
            Console.WriteLine("The Size of the first Dimension: " + TwoD.GetLength(0));
            Console.WriteLine("The Size of the Second Dimension: " + TwoD.GetLength(1));
            for (int i = 0; i < TwoD.GetLength(0); i++)
            {
                for (int j = 0; j < TwoD.GetLength(1); j++)
                {
                    Console.Write(TwoD[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void simpleArray()
        {
            string[] fruits = { "Apple", "Mango", "Orange", "Banana", "KiwiFruit" };
            Console.WriteLine("The No of elements: " + fruits.Length);
            Console.WriteLine("The First Element: " + fruits[0]);
            Console.WriteLine("The Last Element: " + fruits[fruits.Length - 1]);
        }
    }
}
