using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts
{

    public static class AccountFactory
    {
        private static int nextID=1;
        public static Account CreateAccount(int balance)
        {
            Account acc = new Account(nextID);
            nextID++;
            if (balance != 0)
            {
                acc.Deposit(balance);
            }

            return acc;
        }
    }

    public class Account
    {
        private int _id;
        private int _balance;

        public int Balance
        {
            get { return _balance; }
        }

        public int Id
        {
            get { return _id; }
        } 


        public Account(int id)
        {
            this._id = id;
            this._balance=0;
        }

        public void Deposit(int amount)
        {
            if (amount > 0)
            {
                _balance += amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

        }

        public int Withdraw(int amount)
        {
            if (amount > 0)
            {
                if (amount > this._balance)
                {
                    throw new InsufficientFundsException(this.Id,amount);
                }

                _balance = _balance - amount;
                return amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public bool Transfer(Account acc, int amount)
        {
            bool worked=false;
            int money=0;
            try
            {
                if (acc._id == this._id)
                {
                    worked = false;
                }

                money = this.Withdraw(amount);

                if (money > 0)
                {
                    acc._balance += money;
                    worked = true;
                }
                
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Failed Trasnfering " + amount +" Dollars from account " + this._id + " to account " + acc.Id +" has failed");
            }
            finally
            {
                if (worked == true)
                {
                    Console.WriteLine("Successfuly Trasnfered " + amount + " Dollars from account " + this._id + " to account " + acc.Id);     
                }

                Console.WriteLine("Account " + this._id + " had " + (this._balance + money) + " before the transfer, and now it has " + this._balance);
                
                if (worked == false)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            return worked;
        }
    }
}
