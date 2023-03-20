using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
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
            //läser in filerna
            string Data = File.ReadAllText("C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\Konton.json");
            dynamic personData = JsonConvert.DeserializeObject<dynamic>(Data)!;
            string bData = File.ReadAllText("C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\bKonton.json");
            dynamic personbibData = JsonConvert.DeserializeObject<dynamic>(Data)!;

            //string path = "C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\konton.txt";
            //string bibliotikarie_path = "C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\bibliotikarie_konton.txt";

            Console.WriteLine("-------------------------------");
            Console.WriteLine("|          Skapa konto        |");
            Console.WriteLine("|          Vikarie(1)         |");
            Console.WriteLine("|          användare(2)       |");
            Console.WriteLine("|                             |");
            Console.WriteLine("|                             |");
            Console.WriteLine("-------------------------------");
            //Console.Clear();
            string val = Console.ReadLine()!;
            if (val == "2")
            {
                //tar input och skapar ett nytt objekt som sedan läggs till i konton json fil
                Console.WriteLine("skriv personnummer:");
                string personnummer1 = Console.ReadLine()!;
                Console.WriteLine("skriv ett lösenord");
                string lösenord1 = Console.ReadLine()!;
                Console.WriteLine("du har nu skapat ett konto.");

                Person newUser = new Person("test", "test", Int32.Parse(personnummer1!), Int32.Parse(lösenord1!));

                personData.Add(JToken.FromObject(newUser));

                string dataToSave = JsonConvert.SerializeObject(personData);
                File.WriteAllText("C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\Konton.json", dataToSave);

                Login.LoggaIn();

            }

            if (val == "1")
            {
                //för bibliotikarier
                Console.WriteLine("skriv personnummer:");
                string personnummer2 = Console.ReadLine()!;
                Console.WriteLine("skriv ett lösenord");
                string lösenord2 = Console.ReadLine()!;
                Console.WriteLine("du har nu skapat ett konto.");

                Person newUser2 = new Person("test", "test", Int32.Parse(personnummer2!), Int32.Parse(lösenord2!));

                personbibData.Add(JToken.FromObject(newUser2));

                string dataToSave = JsonConvert.SerializeObject(personbibData);
                File.WriteAllText("C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\bKonton.json", dataToSave);

                Login.LoggaIn();
            }


        }
        
    }
}
