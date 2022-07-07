using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class Evento
    {
        private string titolo;
        private DateTime data;
        public string Titolo { 
            get
            {
                return this.titolo;
            }
            set
            {
                try
                {
                    if (value == " ")
                    {
                        throw new ArgumentNullException("value");
                    }
                    else
                    {
                        this.titolo = value;
                    }
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Non puoi lasciare il campo vuoto");
                }
            } 
        }
        public DateTime Data {
            get 
            {
                return this.data;
            }
            set 
            {
                try
                {
                    if (value < DateTime.Now)
                    {
                        throw new ArgumentOutOfRangeException("value");
                    }
                    else
                    {
                        this.data = value;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Errore: hai inserito una data passata");
                }
            } 
        }
        public uint CapienzaMassima { get; private set; }
        public uint NumeroPostiPrenotati { get; private set; }
        public Evento(string titolo, DateTime data, uint capienzaMassima)
        {
            Titolo = titolo;
            Data = data;
            CapienzaMassima = capienzaMassima;
            NumeroPostiPrenotati = 0;
        }

        public void PrenotaPosti(int posti)
        {
            int postiDisponibili = (int)(this.CapienzaMassima - this.NumeroPostiPrenotati);
            if(posti <= postiDisponibili && this.Data > DateTime.Now)
            {
                this.NumeroPostiPrenotati+= (uint)posti;
            }
            else
            {
                Console.WriteLine("Errore");
            }
        }
        public void DisdiciPosti(int posti)
        {
            if (posti < NumeroPostiPrenotati && this.Data > DateTime.Now)
            {
                this.NumeroPostiPrenotati -= (uint)posti;
            }
            else if (posti > NumeroPostiPrenotati)
            {
                Console.WriteLine("Errore posti non disponibili");
            }
            else if (this.Data < DateTime.Now)
            {
                Console.WriteLine("Errore evento passato");
            }
            
        }
        public override string ToString()
        {
            return this.Data.ToString("dd/MM/yyyy") + "-" + this.Titolo;
        }

        public static void NuovoEvento()
        {
            Console.WriteLine("Inserisci il nome dell'evento");
            string titolo = Console.ReadLine();
            Console.WriteLine("Inserisci la data dell'evento");
            string data = Console.ReadLine();
            Console.WriteLine("Inserisci il numero dei posti totali");
            uint postiTotali = uint.Parse(Console.ReadLine());
            Evento evento = new Evento(titolo, DateTime.Parse(data), postiTotali);
            Console.WriteLine("Quanti posti vuoi prenotare?");
            int posti= int.Parse(Console.ReadLine());
            evento.PrenotaPosti(posti);
            int postiDisponibli = (int)(evento.CapienzaMassima - evento.NumeroPostiPrenotati);
            Console.WriteLine($"Numero di posti prenotati: {evento.NumeroPostiPrenotati}");
            Console.WriteLine($"Numero di posti disponibili: {postiDisponibli}");
            string risposta;
            do
            {
                Console.WriteLine("Vuoi disdire posti (si/no)?");
                risposta = Console.ReadLine();
            } while (!(risposta == "si" || risposta == "no"));
            if (risposta == "si")
            {
                Console.WriteLine("Quanti posti vuoi disdire?");
                posti = int.Parse(Console.ReadLine());
                evento.DisdiciPosti(posti);
                postiDisponibli = (int)(evento.CapienzaMassima - evento.NumeroPostiPrenotati);
                Console.WriteLine($"Numero di posti disponibili: {postiDisponibli}");
            }
        }
        
    }
}
