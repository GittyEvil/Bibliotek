using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    internal class Addbook
    {

        public static void Läggatillbok()
        {
            Console.WriteLine("Vad är titeln för boken");
            string titel = Console.ReadLine();
            Console.WriteLine("vem är författaren");
            string författare = Console.ReadLine();
            Console.WriteLine("vad är serienumret?");
            int v = int.Parse(Console.ReadLine());
            string serienummer = v;
            Console.WriteLine("Hur många av boken vill du beställa?");
            string antal = Console.ReadLine();

            Bok nybok = new Bok(titel, antal, serienummer, författare);
            //system.LäggatillBok(nybok);
        }

    }
}
