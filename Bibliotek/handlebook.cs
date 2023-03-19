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

       
        public static void Listaböcker()
        {
            List<Bok> books = BokSystem.GetBooks();


            for(var i=0;i < books.Count;i++)
            {
                Bok bok = books[i];


                Console.WriteLine($"{i + 1}.{bok.Titel} {bok.Författare} {bok.Serienummer} {bok.Antal}");
            }

            Console.WriteLine("Skulle du vilja söka efter en specifik bok? 1:Ja, 2:Nej");
            string val = Console.ReadLine()!;

            if(val == "1")
            {
                Console.WriteLine("Vilken bok? Du kan söka med författare och serienummer också.");
                var choice = Console.ReadLine();
                int number;

                var isNumber = int.TryParse(choice, out number);

                if (isNumber && number > 0 && number < books.Count + 1)
                {
                    BokHanterare(books[number - 1]);
                }

            }
            if (val =="2")
            {
                homepage.Användarhemsida(); 
            }
        }

        static void BokHanterare(Bok bok)
        {
            Console.WriteLine(bok.Titel);
            Console.WriteLine(bok.Författare);
            Console.WriteLine(bok.Serienummer);
            Console.WriteLine(bok.Antal);

            Console.WriteLine("Vad skulle du vilja göra nu?");
            Console.WriteLine("1. Gå tillbaka");

            bool userIsRenting = BokSystem.currentPersonLoaningBook(bok);
            
            if (bok.Ledig)
            {
                Console.WriteLine("2. Låna bok");

            }
            

            if (userIsRenting)
            {
                Console.WriteLine("2. Lämna tillbaka bok");

            }

            Console.Write("Ditt val (1-2): ");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                Listaböcker();
            }
            
            else if (choice == "2" && bok.Ledig)
            {
                BokSystem.Lånabok(bok);

                Lånabok();
            }
            
            else if (choice == "2" && userIsRenting)
            {
                BokSystem.Returnbooks(bok);
                LämnatillbakaBöcker();
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


                Console.WriteLine("Skulle du vilja låna boken?1:Ja, 2:Nej");
                string hyraellerej = Console.ReadLine()!;

                if (hyraellerej == "1")
                {
                    BokSystem.Lånabok(bok);
                    Lånabok();
                }

                if (hyraellerej == "2")
                {
                    homepage.Användarhemsida();
                }
            }


            
        }
        static void Lånabok()
        {
            Console.WriteLine("bok är nu lånad");
            //Listaböcker();
        }

        void ListaLånadeBöcker()
        {
            //fixa så man kan lista lånade böcker
            Console.WriteLine("");
        }


        public static void LämnatillbakaBöcker()
        {
            //lämna tillbaka böcker
            Console.WriteLine("boken är nu återlämnad");
            //Listaböcker();
        }
    }
}
