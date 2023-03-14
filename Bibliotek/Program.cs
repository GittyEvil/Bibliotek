using System.IO;

namespace Bibliotek
{
    internal class Program
    {
        //imports så jag kan använda class person och bok
        public static Person GetPerson = new Person("fem","1");
        public static Bok GetBok = new Bok("sluta",1,12,"ja");
        static BokSystem system = BokSystem.GetInstance();

        //bool admin = false;
        //main metoden
        static void Main(string[] args)
        {
            FirstPage();

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