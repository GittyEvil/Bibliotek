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

            string val = Console.ReadLine();

            foreach (string line in Användarnamncheck)
            {
                foreach(string lines in bilbiotikariecheck)
                {
                    var spliting = line.Split(" ");
                    var bibliotikariesplit = lines.Split(" ");

                    var bibliotikarienamn = bibliotikariesplit[0];
                    var bibliotikarielösenord = bibliotikariesplit[1];

                    var användarnamn1 = spliting[0];
                    var lösenord1 = spliting[1];

                    
                    if (val == "1")
                    {
                        Console.WriteLine("Vänligen skriv in ditt användarnamn");
                        string användarnamn = Console.ReadLine();
                        Console.WriteLine("Skriv in ditt lösenord");
                        string lösenord = Console.ReadLine();

                        if (bibliotikarienamn == användarnamn && bibliotikarielösenord == lösenord)
                        {
                            homepage.Hemsida();
                            return;
                        }
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
                            return;
                        }
                    }


                }
               


            }

            



        }
    }
}
