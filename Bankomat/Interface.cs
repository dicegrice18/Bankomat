using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    public class Interface
    {
        public static void Login(List<BankAccount> ContiCorrenti) 
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Benvenuto al BankoMat!");
            Console.ResetColor();
            
            string pass;
            string user;
            bool accessoRiuscito = false;
            
            do
            {
                Console.WriteLine("\nEffettua il Login per eseguire operazioni");
                Console.Write("Username: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                user = Console.ReadLine();
                Console.ResetColor();
                Console.Write("Password: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                pass = Console.ReadLine();
                Console.ResetColor();

                // Verifica se le credenziali sono corrette per uno qualsiasi degli utenti
                foreach (var utente in ContiCorrenti)
                {
                    if (utente.Username == user && utente.Password == pass)
                    {
                        accessoRiuscito = true;
                        break; // Esci dal ciclo se le credenziali sono corrette per almeno un utente
                    }
                }

                if (!accessoRiuscito)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Credenziali non valide. Vuoi reinserirle? (Si/No)");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string risposta = Console.ReadLine();
                    Console.ResetColor();
                    if (risposta.ToLower() != "si")
                    {
                        Console.WriteLine("Accesso negato.");
                        break; // Interrompi il ciclo se l'utente non vuole reinserire le credenziali
                    }
                }
                else
                {
                    Console.WriteLine("Accesso riuscito!");
                }

            } while (!accessoRiuscito);
        }



        public static bool Operations(List<BankAccount> ContiCorrenti)
        {
            bool restart = false;
            
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Seleziona un'operazione:");
                Console.ResetColor();
                Console.WriteLine("(1) Versamento");
                Console.WriteLine("(2) Prelievo");
                Console.WriteLine("(3) Visualizza Saldo Disponibile");
                Console.WriteLine("(4) Esci");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string scelta = Console.ReadLine();
            Console.ResetColor();

                switch (scelta)
                {
                    case "1":
                        Console.WriteLine("Inserisci l'IBAN del conto:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string ibanVersamento = Console.ReadLine();
                    Console.ResetColor();
                        BankAccount contoVersamento = ContiCorrenti.Find(c => c.IBAN == ibanVersamento);

                        if (contoVersamento == null)
                        {
                            Console.WriteLine("Conto corrente non trovato.");
                        }
                        else
                        {
                            Console.WriteLine($"\nSaldo Disponibile: {contoVersamento.Saldo}\n");
                            Console.WriteLine("Inserisci l'importo da versare:");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        double importoVersamento = Convert.ToDouble(Console.ReadLine());
                        Console.ResetColor();
                            if (importoVersamento <= 0)
                            {
                                Console.WriteLine("L'importo deve essere maggiore di zero.");
                            }
                            else
                            {
                                contoVersamento.Versamento(contoVersamento, importoVersamento);
                                Console.WriteLine($"\nSaldo Disponibile: {contoVersamento.Saldo}\n");

                            }
                        }
                    Console.WriteLine("\nPremi Invio per tornare al menu principale.");
                    Console.ReadLine(); // Torna al menu principale
                    break;


                    case "2":
                        Console.WriteLine("Inserisci l'IBAN del conto:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string ibanPrelievo = Console.ReadLine();
                    Console.ResetColor();
                        BankAccount contoPrelievo = ContiCorrenti.Find(c => c.IBAN == ibanPrelievo);

                        if (contoPrelievo == null)
                        {
                            Console.WriteLine("Conto corrente non trovato.");
                        }
                        else
                        {
                            Console.WriteLine($"\nSaldo Disponibile: {contoPrelievo.Saldo}\n");
                            Console.WriteLine("Inserisci l'importo da prelevare:");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        double importoPrelievo = Convert.ToDouble(Console.ReadLine());
                        Console.ResetColor();

                            if (importoPrelievo <= 0)
                            {
                                Console.WriteLine("L'importo deve essere maggiore di zero.");
                            }
                            else if (importoPrelievo > contoPrelievo.Saldo)
                            {
                                Console.WriteLine("Saldo insufficiente per il prelievo.");
                            }
                            else
                            {
                                contoPrelievo.Prelievo(contoPrelievo, importoPrelievo);
                                Console.WriteLine($"\nSaldo Disponibile: {contoPrelievo.Saldo}\n");

                            }
                        }
                    Console.WriteLine("\nPremi Invio per tornare al menu principale.");
                    Console.ReadLine(); // Torna al menu principale
                    break;

                    case "3":
                        Console.WriteLine("Inserisci l'IBAN del conto:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string ibanSaldo = Console.ReadLine();
                    Console.ResetColor();
                        BankAccount contoSaldo = ContiCorrenti.Find(c => c.IBAN == ibanSaldo);

                        if (contoSaldo == null)
                        {
                            Console.WriteLine("Conto corrente non trovato.");
                        }
                        else
                        {
                            DateTime dataOraCorrente = DateTime.Now;
                            Console.WriteLine($"\nSaldo Disponibile: {contoSaldo.Saldo}");
                            Console.WriteLine($"{dataOraCorrente}\n");
                    }
                    Console.WriteLine("\nPremi Invio per tornare al menu principale.");
                    Console.ReadLine(); // Torna al menu principale
                    break;

                    case "4":
                        restart = true;
                        break;


                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }
                
            Console.Clear();
            return restart;
        }
    }
}
