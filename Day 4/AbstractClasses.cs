using System;
/*
 * Abstract classes are classes which contain methods that are not implemented in the class. It is rather expected to be implemented by the respective derived classes as they are supposed to have more clear picture of implementing it.
 * If a method is abstract, it means that it is not implemented and the class is not complete. So that class is called abstract class defined by a keyword abstract at the class level, making the system understand that this class is incomplete and cannot be creatable. So abstract classes cannot be instantiated as they are incomplete classes
 */
namespace SampleConApp.Day_4
{
    abstract class Account
    {
        public int AccountNo { get; set; }
        public string Name { get; set; }
        public double Balance { get; protected set; } = 0;//protected means only can be set in the current class or its derived classes.
        public void Credit(double amount) => Balance += amount;

        public void Debit(double amount)
        {
            if (amount > Balance)
                throw new Exception("Insufficient funds");
            Balance -= amount;
        }
        public abstract void CalculateInterest();
    }

    class SBAccount : Account
    {
        public override void CalculateInterest()
        {
            double principal = Balance;
            var rate = 6.5 / 100;
            float term = 0.25f;
            var interest = principal * rate * term;
            Credit(interest);
        }
    }
    class AbstractClasses
    {
        static void Main(string[] args)
        {
            Account acc = new SBAccount
            {
                Name = "Phaniraj",
                AccountNo = 1111
            };
            acc.Credit(65000);//Balance can be modified either by credited or debitting...
            acc.CalculateInterest();
            Console.WriteLine($"Balance after calculating interest is {acc.Balance}");
        }
    }
}
