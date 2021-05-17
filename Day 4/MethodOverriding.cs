using System;
//One of the outcomes of the inheritance is to extend a class and modifying the existing functionality of the base class. This is called Method overriding. U modify the existing method in the derived class. 
//base class should provide the permission for the method to be changed in the derived class.
//Derived class will notify the app that it is modifying the base class virtual method. making a method virtual does not mean that it should be modifying by the derived class.
//In method overriding, the derived function signature should be same as the base class. Its name, parameters and its return type all should be same or atleast the parameters or its return type should be derived types. 
namespace SampleConApp.Day_4
{
    class Father
    {
        public virtual void AcceptPayment(string mode, int amount)
        {
            if ((mode == "Cheque") || (mode == "Cash"))
                Console.WriteLine($"Payment accepted for Rs. {amount} thru' {mode}");
            else
                Console.WriteLine("Payment not accepted");
        }
    }

    class Son : Father
    {
        public override void AcceptPayment(string mode, int amount)
        {
            //base.AcceptPayment(mode, amount);
            //Add new feature to it....
            if ((mode == "Card") || (mode == "Cash"))
                Console.WriteLine($"Payment accepted for Rs. {amount} thru' {mode}");
            else
                Console.WriteLine("Payment not accepted");
        }
    }
    class MethodOverriding
    {
        static void Main(string[] args)
        {
            Father business = new Father();//Customer who used to visit UR father
            business.AcceptPayment("Cheque", 50000);

            business = new Son();//Same Customer comes to U...
            business.AcceptPayment("Card", 50000);
        }
    }
}
