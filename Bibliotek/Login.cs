using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class Login
    {

        public static void LoggaIn()
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


            foreach (string line in Användarnamncheck)
            {
                var spliting = line.Split(" ");
                var användarnamn1 = spliting[0];
                var lösenord1 = spliting[1];

                string val = Console.ReadLine();

                if (val == "1")
                {
                    //logga in som vikarie
                }
                if (val == "2")
                {
                    Console.WriteLine("Vänligen skriv in ditt användarnamn");
                    string användarnamn = Console.ReadLine();
                    Console.WriteLine("Skriv in ditt lösenord");
                    string lösenord = Console.ReadLine();

                    if (användarnamn1 == användarnamn && lösenord1 == lösenord)
                    {
                        homepage.Hemsida();
                    }
                }


            }

            



        }
    }
}
