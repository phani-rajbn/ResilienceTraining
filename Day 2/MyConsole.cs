using System;

//MyConsole is a helper class that will interact with the Console of the Application to display and take inputs.
//static classes make the class available only thru' the class name and no object can be created for this class. This is required when U have only static members in the class as static members are invoked by their classname instead of any object of the class..... 
//static classes are created for those functions that are very frequently used across the application. If a class is used very frequently U will spend time in creating and deleting the objects. Frequent creation and deletion will hampper the performance of the application. So those functions that U use very frequently can be made static and invoked by the classname instead of an object creation...
static class MyConsole
{
    public static void Print(string content)
    {
        Console.WriteLine(content);
    }
    public static string GetString(string question)
    {
        Console.WriteLine(question);
        return Console.ReadLine();
    }

    public static int GetNumber(string question)
    {
        return int.Parse(GetString(question));
    }

    public static double GetDouble(string question)
    {
        return double.Parse(GetString(question));
    }
}
