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
        static Person? loggedInPerson = null;

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

            //tar in data
            string Data = File.ReadAllText("C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\Konton.json");
            dynamic personData = JsonConvert.DeserializeObject<dynamic>(Data)!;
            string bData = File.ReadAllText("C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\bKonton.json");
            dynamic personbibData = JsonConvert.DeserializeObject<dynamic>(bData)!;

            //kollar så input är likadan som det som finns i json filen, om det stämmer = inloggad
            string val = Console.ReadLine()!;
            Console.WriteLine("Vänligen skriv in ditt personnummer");
            string personnummer = Console.ReadLine()!;
            Console.WriteLine("Skriv in ditt lösenord");
            string lösenord = Console.ReadLine()!;
            foreach (var i in personData)
            {
                var personnummer1 = (string)i["personnummer"];
                var lösenord1 = (string)i["lösenord"];

                if (val == "2")
                {
                    loggedInPerson = new Person(personnummer, lösenord);

                    if (personnummer1 == personnummer && lösenord1 == lösenord)
                    {
                        homepage.Hemsida();
                        return;
                    }
                }
            }
            /*
            //för bibliotikarier
            foreach (var i in personbibData)
            {
                var personnummer1 = (string)i["personnummer"];
                var lösenord1 = (string)i["lösenord"];

                if (val == "1")
                {
                    Console.WriteLine("Vänligen skriv in ditt personnummer");
                    string personnummer = Console.ReadLine()!;
                    Console.WriteLine("Skriv in ditt lösenord");
                    string lösenord = Console.ReadLine()!;
                    loggedInPerson = new Person(personnummer, lösenord);

                    if (personnummer1 == personnummer && lösenord1 == lösenord)
                    {
                        homepage.Hemsida();
                        return;
                    }
                }

            }
            */
            Login.LoggaIn();
            
        }


    
            
        


    }
}
