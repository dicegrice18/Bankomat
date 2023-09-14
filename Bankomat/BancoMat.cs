using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    public class BancoMat
    {
        
        public void Versamento(BankAccount contocorrente,double ammontare)
        {
            if (ammontare <= 0)
                throw new ArgumentException("L'ammontare del versamento deve essere maggiore di zero.");

            contocorrente.Saldo += ammontare;
            Console.WriteLine("Versamento effettuato con successo!");
        }

        public void Prelievo(BankAccount contocorrente,double ammontare)
        {
            if (ammontare <= 0)
                throw new ArgumentException("L'ammontare del prelievo deve essere maggiore di zero.");

            if (ammontare > 10000)
                throw new InvalidOperationException("Hai superato il limite giornaliero di prelievo.");
            contocorrente.Saldo -= ammontare;
            Console.WriteLine("Prelievo effettuato con successo!");
        }

        /*public void RichiediSaldo()
        {
            DateTime dataOraCorrente = DateTime.Now;
            Console.WriteLine($"Il tuo saldo del conto corrente: {}");
            Console.WriteLine($"{dataOraCorrente}");

        }*/

    }
}
