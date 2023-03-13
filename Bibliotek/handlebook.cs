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
            int serienummer = Int32.Parse((Console.ReadLine()!));
            Console.WriteLine("Hur många av boken vill du beställa?");
            int antal = Int32.Parse((Console.ReadLine()!));

            Bok nybok = new Bok(titel, antal, serienummer, författare);
            BokSystem.AddBok(nybok);
        }

        public static void Tabortbok()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }
       
        public static void Listaböcker()
        {
            List<Bok> books = BokSystem.GetBooks();


            for(var i=0;i < books.Count;i++)
            {
                Bok bok = books[i];

                Console.WriteLine($"{bok.Titel} {bok.Författare} {bok.Serienummer} {bok.Antal}");
            }

            Console.WriteLine("Skulle du vilja söka efter en specifik bok? 1:Ja, 2:Nej");
            string val = Console.ReadLine();
            if(val == "1")
            {
                Sökaböcker();
            }
            if(val =="2")
            {
                homepage.Användarhemsida(); 
            }
        }

        public static void Sökaböcker()
        {

            Console.WriteLine("Vad vill du söka efter?, du kan söka med titel, författare eller seriernummer?");
            string? val = Console.ReadLine()!;

            var sökning = BokSystem.Hittabooks(val);

            for(var i=0; i < sökning.Count; i++)
            {
                var bok = sökning[i];

                Console.WriteLine(bok.Titel);
                Console.WriteLine(bok.Författare);
                Console.WriteLine(bok.Serienummer);

            }


            Console.WriteLine("Skulle du vilja låna boken?1:Ja, 2:Nej");

            if (val == "1")
            {
                BokSystem.Lånabok(bok);
            }

            if (val == "2")
            {
                homepage.Användarhemsida();
            }
        }



    }
}
