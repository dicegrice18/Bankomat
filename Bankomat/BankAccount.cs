using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    public class BankAccount
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string IBAN { get; }
        public double Saldo { get;  set; }

         BancoMat bancomat = new BancoMat();


        public BankAccount(string utente, string pass, double saldo, string iban)
        {
            Username = utente;
            Password = pass;
            IBAN = iban;
            Saldo = saldo;
            

        }

        public void Prelievo(BankAccount contocorrente,double ammontare)
        {
            bancomat.Prelievo(contocorrente,ammontare);
        }

        public void Versamento(BankAccount contocorrente,double ammontare)
        {
            bancomat.Versamento(contocorrente,ammontare);
        }


        /*private void BloccaConto(int giorni)
        {
            Console.WriteLine($"Il conto di {Cliente.Nome} è stato bloccato per {giorni} giorni.");
        }*/

    }
}
