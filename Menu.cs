using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class Menu
    {
        public static void menuPage()
        {
            Console.WriteLine("\n--- MENU GESTORE EVENTI ---");

            Console.WriteLine("1. Inserisci evento");
            Console.WriteLine("2. Esci dal programma");

            uint input = Convert.ToUInt32(Console.ReadLine());


            switch (input)
            {
                case 1:
                    Evento.NuovoEvento();
                    menuPage();
                    break;
                case 2:

                    break;
                case 3:
                    return;
                    break;
            }
        }

    }
}




