using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class Register
    {

        public static void SkapaKonto()
        {

            string path = "C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\konton.txt";
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
            if (val == "1")
            {
                Console.WriteLine("skriv personnummer:");
                string användarnamn1 = Console.ReadLine();
                Console.WriteLine("skriv ett lösenord");
                Console.ReadLine();
                Console.WriteLine("skriv adminkoden");
                string lösenord1 = Console.ReadLine();
                Console.WriteLine("du har nu skapat ett konto.");

                string[] lines1 = { $"{användarnamn1} {lösenord1}" };
                System.IO.File.AppendAllLines(bibliotikarie_path, lines1);
                Login.LoggaIn();


            }

            if (val == "2")
            {
                Console.WriteLine("skriv personnummer:");
                string användarnamn = Console.ReadLine();
                Console.WriteLine("skriv ett lösenord");
                string lösenord = Console.ReadLine();
                Console.WriteLine("du har nu skapat ett konto.");

                string[] lines = { $"{användarnamn} {lösenord}" };
                System.IO.File.AppendAllLines(path, lines);
                Login.LoggaIn();
            }
        }
    }
}
