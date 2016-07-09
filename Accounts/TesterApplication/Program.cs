using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounts;

namespace TesterApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Account acc1 = AccountFactory.CreateAccount(1500);
                Account acc2 = AccountFactory.CreateAccount(0);

                try
                {
                    Account acc3 = AccountFactory.CreateAccount(-500);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Did Not creat an account with a negative balance");
                }

                try
                {
                    acc2.Withdraw(700000);
                }
                catch (InsufficientFundsException e)
                {
                    Console.WriteLine("Cannot withdraw " + e.Amount + " dollars much from account " + e.AccID);
                    Console.WriteLine("Account " +e.AccID + " has InsufficientFunds.");
                }

                acc1.Transfer(acc2, 750);
                acc1.Transfer(acc2, -100);

                

            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("You tried to deposit/withdraw a negative amount of cash");
            }
            
        }
    }
}
