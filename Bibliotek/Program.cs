using System.IO;

namespace Bibliotek
{
    internal class Program
    {
        //imports så jag kan använda class person och bok
        public static Person GetPerson = new Person("fem","er",1);
        public static Bok GetBok = new Bok("sluta",14,2,"ja");

        bool admin = false;
        //main metoden
        static void Main(string[] args)
        {
            FirstPage();

        }




        //class för användaren
        public class Användare : Person
        {
            bool admin = false;

            public Användare(string förnamn, string efternamn, int personnummer) : base(förnamn, efternamn, personnummer)
            {
                admin = false;
            }

            void inlogg()
            {

            }
        }

        //class för bibliotikarie
        public class Bibliotikarie: Person
        {

            bool admin = true;
            int adminkod = 12455;

            public Bibliotikarie(string förnamn, string efternamn, int personnummer) : base(förnamn, efternamn, personnummer)
            {
                admin = true;
            }

            void inlogg()
            {

            }
        }

        //login sida
        static void FirstPage()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("|          Bibliotek          |");
            Console.WriteLine("|        Skapa Konto(1)       |");
            Console.WriteLine("|          Logga in(2)        |");
            Console.WriteLine("|                             |");
            Console.WriteLine("|                             |");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("");
            //Console.Clear();

            string val = Console.ReadLine();
            if(val == "1")
            {
                Register.SkapaKonto();
            }
            if(val == "2")
            {
                Login.LoggaIn();
            }

        }
       

        


    }
}