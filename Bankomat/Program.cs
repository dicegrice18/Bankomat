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
            BankAccount c1 = new BankAccount("Davide03", "1234", 1000, "IT84I0300203280838287694556");
            BankAccount c2 = new BankAccount("Samu04", "5678", 1000, "IT17K0300203280842843543212");
            BankAccount c3 = new BankAccount("Carlos", "9012", 1000, "ES4520381612736729323146");
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
