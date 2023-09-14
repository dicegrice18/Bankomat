using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bankomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Creazione ContiCorrenti
            BankAccount c1 = new BankAccount("user1", "user1", 1000, "user1");
            BankAccount c2 = new BankAccount("user2", "user2", 1000, "user2");
            BankAccount c3 = new BankAccount("user3", "user3", 1000, "user3");
            List<BankAccount> ContiCorrenti = new List<BankAccount>();
            {
                ContiCorrenti.Add(c1);
                ContiCorrenti.Add(c2);
                ContiCorrenti.Add(c3);
            };
            #endregion
            Interface.Login(ContiCorrenti);
            bool restart = false;

            while (true) 
            {
                restart = Interface.Operations(ContiCorrenti);

                if (restart == true)
                {
                    Interface.Login(ContiCorrenti);
                }
               
            }
           
        }
    }
}
