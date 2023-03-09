using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
            //string Data = File.ReadAllText("C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\Konton.json");
            //var userData = JsonSerializer.Deserialize<Person>(Data);

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

                    //var username1 = userData.förnamn;
                    //var password1 = userData.lösenord;
                    //var personnummer1 =userData.personnummer.ToString();

                    
                    if (val == "1")
                    {
                        Console.WriteLine("Vänligen skriv in ditt personnummer");
                        string användarnamn = Console.ReadLine();
                        Console.WriteLine("Skriv in ditt lösenord");
                        string lösenord = Console.ReadLine();


                        /*if(användarnamn == personnummer1 && lösenord == password1)
                        {
                            homepage.Hemsida();
                        }
                        */
                        if (bibliotikarienamn == användarnamn && bibliotikarielösenord == lösenord)
                        {
                            homepage.Hemsida();
                            return;
                        }
                        
                        LoggaIn();
                    }

                    if (val == "2")
                    {
                        Console.WriteLine("Vänligen skriv in ditt personnummer");
                        string användarnamn = Console.ReadLine();
                        Console.WriteLine("Skriv in ditt lösenord");
                        string lösenord = Console.ReadLine();

                        if (användarnamn1 == användarnamn && lösenord1 == lösenord)
                        {
                            homepage.Användarhemsida();
                            return;
                        }
                        LoggaIn();
                    }


                }
               


            }

            



        }
    }
}
