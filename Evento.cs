using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class Evento
    {
        public string Titolo { 
            get
            {
                return Titolo;
            }
            set 
            { 
                if(value == null)
                {
                    throw new ArgumentNullException("value");
                }
                else
                {
                    Titolo = value;
                }
            } 
        }
        public DateTime Data {
            get 
            {
                return Data;
            }
            set 
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                else
                {
                    Data = value;
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
            if (posti<NumeroPostiPrenotati && this.Data > DateTime.Now)
            {
                this.NumeroPostiPrenotati -= (uint)posti;
            }
            else if(posti > NumeroPostiPrenotati)
            {
                Console.WriteLine("Errore posti non disponibili");
            }
            else if(this.Data < DateTime.Now)
            {
                Console.WriteLine("Errore evento passato");
            }
        }
        public override string ToString()
        {
            return this.Data.ToString("dd/MM/yyyy") + "-" + Titolo;
        }

    }
}
