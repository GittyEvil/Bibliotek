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

            List<string> Konton = new List<string>();
            Konton.Add("forre");
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
                SkapaKonto();
            }
            if(val == "2")
            {
                LoggaIn();
            }

        }



        //tänker mig UI då jag loggat in
        static void SkapaKonto()
        {

            string användar_path = "C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\konton.txt";
            string bibliotikarie_path = "C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\bibliotikarie_konton.txt";

            Console.WriteLine("-------------------------------");
            Console.WriteLine("|          Skapa konto        |");
            Console.WriteLine("|          Vikarie(1)         |");
            Console.WriteLine("|          användare(2)       |");
            Console.WriteLine("|                             |");
            Console.WriteLine("|                             |");
            Console.WriteLine("-------------------------------");
            //Console.Clear();
            string val = Console.ReadLine();
            if(val =="1")
            {
                Console.WriteLine("skriv användarnamn:");
                string användarnamn = Console.ReadLine();
                Console.WriteLine("skriv ett lösenord");
                Console.ReadLine();
                Console.WriteLine("skriv adminkoden");
                string lösenord = Console.ReadLine();
                Console.WriteLine("du har nu skapat ett konto.");
                LoggaIn();


                string[] lines1 = { $"{användarnamn} {lösenord}" };
                System.IO.File.AppendAllLines(bibliotikarie_path, lines1);


            }
            if (val == "2")
            {
                Console.WriteLine("skriv användarnamn:");
                string användarnamn = Console.ReadLine();
                Console.WriteLine("skriv ett lösenord");
                string lösenord = Console.ReadLine();
                Console.WriteLine("du har nu skapat ett konto.");
                string[] lines = { $"{användarnamn} {lösenord}" };
                System.IO.File.AppendAllLines(användar_path, lines);
                LoggaIn();
            }
        }

        static void LoggaIn()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("|          Logga in           |");
            Console.WriteLine("|          Vikarie(1)         |");
            Console.WriteLine("|          användare(2)       |");
            Console.WriteLine("|                             |");
            Console.WriteLine("|                             |");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("");
            //Console.Clear();


            string[] Användarnamncheck = System.IO.File.ReadAllLines("C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\konton.txt");
            string[] bilbiotikariecheck = System.IO.File.ReadAllLines("C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\bibliotikarie_konton.txt");

            string val = Console.ReadLine();
            if (val == "1")
            {
                //logga in som vikarie
            }
            if (val == "2")
            {
                while (true)
                {
                    Console.WriteLine("Vänligen skriv in ditt användarnamn");
                    string användarnamncheck = Console.ReadLine();
                    Console.WriteLine("Skriv in ditt lösenord");
                    string lösenordcheck = Console.ReadLine();

                    if(användarnamncheck && lösenordcheck)
                    {

                    }
                }
            }
        }


    }
}