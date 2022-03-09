using System; // System.Console ... helps access Console
using System.Collections.Generic;

namespace CSpractice 
{
    class Program
    {
        static void Main(string[] args)
        {


            var myAccount = new BankAccount("Natalie", 1000);

            Console.WriteLine($"Account {myAccount.Number} was created for {myAccount.Owner} with {myAccount.Balance}");

            myAccount.MakeWithdrawl(120, DateTime.Now, "STAX");

            myAccount.MakeWithdrawl(300, DateTime.Now, "Laptop Repairs");

            Console.WriteLine(myAccount.GetAccountHistory());



            ////Test that there is not a negative balance
            //myAccount.MakeDeposit(-300, DateTime.Now, "trying to steal");

            ////Test that initial balances must be positive.
            //try
            //{
            //    var invalidAccount = new BankAccount("invalid", -55);
            //}
            //catch (ArgumentOutOfRangeException error)
            //{
            //    Console.WriteLine("Exception caught creating account with negative balance");
            //    Console.WriteLine(error.ToString());
            //}



        }
    }
}
