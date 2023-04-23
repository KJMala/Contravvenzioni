using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contravvenzioni
{
    internal class Program
    {
        static void Main(string[] args)
        {
          Municipale m = new Municipale();
          m.CreaLista();
          m.Start();
            
        }

        public class Municipale
        {
            public Municipale() { }

            public List<Trasgressore> ListaTrasgressori { get; set; } = new List<Trasgressore>();

            public void Start()
            {
                int scelta = 0;
                Console.WriteLine("Scelgi una opzione: 1. Totale verbali \n2. Elenco verbali \n3. Trasgressori di una città \n4. Trasgressori quando infrazione supera i 5 punti " +
                    "\n5. Trasgressori quando infrazione importo supera i 400 euro \n6. Calcolo saldo patente");
                Console.WriteLine("\nInserisci da 1 a 6 numeri");
                scelta = Convert.ToInt32(Console.ReadLine());
                if (scelta == 1)
                {
                    TotaleVerbali1();
                    Console.WriteLine("\nPremi invio per continuare");
                    Console.ReadLine();
                    Console.Clear();
                    Start();
                }
                else if (scelta == 2)
                {
                    ElencoVerbali2();
                    Console.WriteLine("\nPremi invio per continuare");
                    Console.ReadLine();
                    Console.Clear();
                    Start();
                }
                else if (scelta == 3)
                {
                    Citta3();
                    Console.WriteLine("\nPremi invio per continuare");
                    Console.ReadLine();
                    Console.Clear();
                    Start();
                }
                else if (scelta == 4)
                {
                    DecurtamentoPunti4();
                    Console.WriteLine("\nPremi invio per continuare");
                    Console.ReadLine();
                    Console.Clear();
                    Start();
                }
                else if (scelta == 5)
                {
                    Importo5();
                    Console.WriteLine("\nPremi invio per continuare");
                    Console.ReadLine();
                    Console.Clear();
                    Start();
                }
                else if (scelta == 6)
                {
                    SaldoPatente6();
                    Console.WriteLine("\nPremi invio per continuare");
                    Console.ReadLine();
                    Console.Clear();
                    Start();
                }
                else
                {
                    Console.WriteLine("Opzione non disponibile, premi invio per continuare");
                    Console.WriteLine("\nPremi invio per continuare");
                    Console.ReadLine();
                    Console.WriteLine("\nPremi invio per continuare");
                    Start();
                }
            }
            public void TotaleVerbali1()
            {
                double totale =0;
                foreach (Trasgressore item in ListaTrasgressori) 
                {
                    foreach (Verbale v in item.ListaVerbali)
                    {
                        totale += v.QtaVerbale;
                    }
                }
                Console.WriteLine($"\nIl totale dei verbali trascritti è {totale}");
            }

            

            public void ElencoVerbali2()
            {
                foreach (Trasgressore item in ListaTrasgressori)
                {
                    foreach (Verbale v in item.ListaVerbali)
                    {
                        Console.WriteLine($"\nID Verbale {v.ID_Verbale} | Data violazione: {v.DataViolazione} | Indirizzo violazione: {v.IndirizzoViolazione} | Città violazione: {v.CittaViolazione} |" +
                            $" Nominativo Agente verbalizzante: {v.NominativoAgenteVerbalizzante} | Data trascrizione: {v.DataTrascrizioneViolazione} | Importo verbale: {v.ImportoVerbale} | " +
                            $"Decurtamento punti: {v.DecurtamentoPunti}");
                    }
                }
            }

            public void Citta3()
            {
                string citta;
                Console.WriteLine("\nInserisci la città di cui vuoi sapere il trasgressore");
                citta = Console.ReadLine();
                foreach (Trasgressore t in ListaTrasgressori)
                {
                    if (t.Citta == citta)
                    {
                        Console.WriteLine($"\nNome e Cognome trasgressore: {t.Nome} {t.Cognome}");
                        foreach (Verbale v in t.ListaVerbali)
                        {
                            Console.WriteLine($"Data violazione: {v.DataViolazione} | Importo: {v.ImportoVerbale} euro | Punti decurtati: {v.DecurtamentoPunti}");
                        }
                    }
                }
            }

            public void DecurtamentoPunti4()
            {
                foreach (Trasgressore t in ListaTrasgressori)
                {
                    //Console.WriteLine($"\nNome e Cognome trasgressore: {t.Nome} {t.Cognome}");
                    foreach (Verbale v in t.ListaVerbali)
                    {
                        if (v.DecurtamentoPunti > 5)
                        {
                            Console.WriteLine($"\nNome e Cognome trasgressore: {t.Nome} {t.Cognome}");
                            Console.WriteLine($"Data violazione: {v.DataViolazione} | Importo: {v.ImportoVerbale} | Punti decurtati: {v.DecurtamentoPunti}");
                        }
                    }
                }
            }

            public void Importo5()
            {
                foreach (Trasgressore t in ListaTrasgressori)
                {
                    Console.WriteLine($"\nNome e Cognome trasgressore: {t.Nome} {t.Cognome}");
                    foreach (Verbale v in t.ListaVerbali)
                    {
                        if (v.ImportoVerbale > 400)
                        {
                            Console.WriteLine($"Data violazione: {v.DataViolazione} | Importo: {v.ImportoVerbale} euro | Punti decurtati: {v.DecurtamentoPunti}");
                        }
                        else
                        {
                            Console.WriteLine("Non c'è nessuna trasgressione che supera i 400 euro di importo");
                        }
                    }
                }
            }

            public void SaldoPatente6()
            {
                string cf;
                int punti = 20;
                Console.WriteLine("\nInserisci il CF per controllare il saldo");
                cf = Console.ReadLine();
                foreach (Trasgressore t in ListaTrasgressori)
                {
                    if (cf ==  t.CF)
                    {
                        //Console.WriteLine($"\n{t.Nome} {t.Cognome}");
                        foreach (Verbale v in t.ListaVerbali)
                        {
                            punti -= v.DecurtamentoPunti;
                        }
                        Console.WriteLine($"\n{t.Nome} {t.Cognome} ha un saldo di {punti} punti");
                    }
                }
            }

            public void CreaLista()
            {
                //Creazione Violazione
                TipoViolazione violazione1 = new TipoViolazione();
                violazione1.ID_Violazione = 1;
                violazione1.Descrizione = "Passaggio col rosso";

                TipoViolazione violazione2 = new TipoViolazione();
                violazione2.ID_Violazione = 2;
                violazione2.Descrizione = "Divieto di sosta";

                TipoViolazione violazione3 = new TipoViolazione();
                violazione3.ID_Violazione = 3;
                violazione3.Descrizione = "Tamponamento";

                //Creazione Veicolo
                Veicolo veicolo1 = new Veicolo();
                veicolo1.Targa = "PIPPO";
                veicolo1.Nr_Telaio = "01ABC";
                veicolo1.Marca_veicolo = "Fiat";
                veicolo1.Tipo_veicolo = "Auto";

                Veicolo veicolo2 = new Veicolo();
                veicolo2.Targa = "PLUTO";
                veicolo2.Nr_Telaio = "02EFG";
                veicolo2.Marca_veicolo = "Lancia";
                veicolo2.Tipo_veicolo = "Auto";

                Veicolo veicolo3 = new Veicolo();
                veicolo3.Targa = "PAPERINO";
                veicolo3.Nr_Telaio = "01HIG";
                veicolo3.Marca_veicolo = "Smart";
                veicolo3.Tipo_veicolo = "Auto";

                Verbale verbale1 = new Verbale();
                verbale1.QtaVerbale = 1;
                verbale1.ID_Verbale = 1;
                verbale1.DataViolazione = new DateTime(2023, 04, 01);
                verbale1.DataViolazione.ToString("d");
                verbale1.IndirizzoViolazione = "Piazza Rossi";
                verbale1.CittaViolazione = "Modena";
                verbale1.NominativoAgenteVerbalizzante = "Mario Rossi";
                verbale1.DataTrascrizioneViolazione = new DateTime(2023, 05, 01);
                verbale1.DataTrascrizioneViolazione.ToString("d");
                verbale1.ImportoVerbale = 600.00;
                verbale1.DecurtamentoPunti = 8;
                verbale1.ListaViolazioni.Add(violazione1);
                verbale1.ListaViolazioni.Add(violazione2);

                Verbale verbale2 = new Verbale();
                verbale2.QtaVerbale = 1;
                verbale2.ID_Verbale = 2;
                verbale2.DataViolazione = new DateTime(2023, 07, 13);
                verbale2.DataViolazione.ToString("d");
                verbale2.IndirizzoViolazione = "Piazza Verdi";
                verbale2.CittaViolazione = "Roma";
                verbale2.NominativoAgenteVerbalizzante = "Massimo Arena";
                verbale2.DataTrascrizioneViolazione = new DateTime(2023, 10, 20);
                verbale2.DataTrascrizioneViolazione.ToString("d");
                verbale2.ImportoVerbale = 450;
                verbale2.DecurtamentoPunti = 6;
                verbale2.ListaViolazioni.Add(violazione2);
                verbale2.ListaViolazioni.Add(violazione3);

                Verbale verbale3 = new Verbale();
                verbale3.QtaVerbale = 1;
                verbale3.ID_Verbale = 3;
                verbale3.DataViolazione = new DateTime(2023, 02, 25);
                verbale3.DataViolazione.ToString("d");
                verbale3.IndirizzoViolazione = "Piazza Gialla";
                verbale3.CittaViolazione = "Genova";
                verbale3.NominativoAgenteVerbalizzante = "Fabio Gerli";
                verbale3.DataTrascrizioneViolazione = new DateTime(2023, 01, 25);
                verbale3.DataTrascrizioneViolazione.ToString("d");
                verbale3.ImportoVerbale = 200;
                verbale3.DecurtamentoPunti = 3;
                verbale3.ListaViolazioni.Add(violazione3);

                //Creazione Trasgressori//
                Trasgressore trasgressore1 = new Trasgressore();
                trasgressore1.ID_Trasgressore = 1;
                trasgressore1.Nome = "Andrea";
                trasgressore1.Cognome = "Malavasi";
                trasgressore1.CF = "ANDREAMALAVASI";
                trasgressore1.Citta = "Modena";
                trasgressore1.CAP = 41013;
                trasgressore1.Veicolo = veicolo1;
                trasgressore1.ListaVerbali.Add(verbale1);

                Trasgressore trasgressore2 = new Trasgressore();
                trasgressore2.ID_Trasgressore = 1;
                trasgressore2.Nome = "Bruno";
                trasgressore2.Cognome = "Giordano";
                trasgressore2.CF = "BRUNOGIORDANO";
                trasgressore2.Citta = "Rimini";
                trasgressore2.CAP = 22567;
                trasgressore2.Veicolo = veicolo2;
                trasgressore2.ListaVerbali.Add(verbale2);

                Trasgressore trasgressore3 = new Trasgressore();
                trasgressore3.ID_Trasgressore = 3;
                trasgressore3.Nome = "Alex";
                trasgressore3.Cognome = "Verdi";
                trasgressore3.CF = "ALEXVERDI";
                trasgressore3.Citta = "Milano";
                trasgressore3.CAP = 20945;
                trasgressore3.Veicolo = veicolo3;
                trasgressore3.ListaVerbali.Add(verbale3);

                ListaTrasgressori.Add(trasgressore1);
                ListaTrasgressori.Add(trasgressore2);
                ListaTrasgressori.Add(trasgressore3);
            }

        }
        public class Veicolo
        {
            public string Targa { get; set; }
            public string Nr_Telaio { get; set; }  
            public string Marca_veicolo { get; set; }
            public string Tipo_veicolo { get; set; }

        }

        public class TipoViolazione
        {
            public int ID_Violazione { get; set; }
            public string Descrizione { get; set; }
        }

        public class Verbale
        {
            public int QtaVerbale { get; set; }
            public int ID_Verbale { get; set; }
            public DateTime DataViolazione { get; set; }
            public string IndirizzoViolazione { get; set; }
            public string CittaViolazione { get; set; }
            public string NominativoAgenteVerbalizzante { get; set; }
            public DateTime DataTrascrizioneViolazione { get; set; }
            public double ImportoVerbale { get; set; }
            public int DecurtamentoPunti { get; set; }
            public List<TipoViolazione> ListaViolazioni { get; set; } = new List<TipoViolazione>();
        }

        public class Trasgressore
        {
            public int ID_Trasgressore { get; set; }
            public string Cognome { get; set; }
            public string Nome { get; set; }
            public string Indirizzo { get; set; }
            public string Citta { get; set; }
            public long CAP { get ; set; }
            public string CF { get; set; }
            public List<Verbale> ListaVerbali { get; set; } = new List<Verbale>();
            public Veicolo Veicolo { get; set; } = new Veicolo();
        }

    }
}
