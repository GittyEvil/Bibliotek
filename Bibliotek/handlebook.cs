using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class handlebook
    {
        static BokSystem BokSystem = BokSystem.GetInstance();
        public static void Addbokpage()
        {
            Console.WriteLine("Vad är titeln för boken");
            string titel = Console.ReadLine()!;
            Console.WriteLine("vem heter författaren");
            string författare = Console.ReadLine()!;
            Console.WriteLine("vad är serienumret?");
            int serienummer = Int32.Parse((Console.ReadLine()));
            Console.WriteLine("Hur många av boken vill du beställa?");
            int antal = Int32.Parse((Console.ReadLine()));

            Bok nybok = new Bok(titel, antal, serienummer, författare);
            BokSystem.AddBok(nybok);
        }

        public static void Tabortbok()
        {

        }

        public static void Listaböcker()
        {
            List<Bok> books = BokSystem.GetBooks();


            for(var i=0;i < books.Count;i++)
            {
                Bok bok = books[i];

                Console.WriteLine($"{bok.Titel} {bok.Serienummer} {bok.Författare} {bok.Antal}");
            }


        }

        public static void Sökaböcker()
        {

            Console.WriteLine("Vad vill du söka efter?, du kan söka med titel, författare eller seriernummer?");
            string val = Console.ReadLine();

            var sökning = BokSystem.Hittabooks(val);

            for(var i =0; i < sökning.Count; i++)
            {
                var bok = sökning[i];

                Console.WriteLine(bok.Titel);
                Console.WriteLine(bok.Författare);
                Console.WriteLine(bok.Serienummer);
            }
        }



    }
}
