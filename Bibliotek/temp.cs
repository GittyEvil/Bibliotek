using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class temp
    {
        static Person? loggedInPerson = null;
        public static void LoggaIntemp()
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

            string Data = File.ReadAllText("C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\Konton.json");
            dynamic personData = JsonConvert.DeserializeObject<dynamic>(Data)!;
            string bData = File.ReadAllText("C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\bKonton.json");
            dynamic personbibData = JsonConvert.DeserializeObject<dynamic>(Data)!;


            string val = Console.ReadLine()!;
            foreach(var i in personData)
            {
            foreach(var j in personbibData)
                {
                    Person person = new Person((string)i.personnummer, (string)i.lösenord);
                    Person person2 = new Person((string)j.personnummer, (string)j.lösenord);
                    var personnummer2 = j.personnummer;
                    var lösenord2 = j.lösenord;
                    var personnummer1 = i.personnummer;
                    var lösenord1 = i.lösenord;

                    if (val == "2")
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

                        Login.LoggaIn();
                    }

                    if (val == "1")
                    {
                        Console.WriteLine("Vänligen skriv in ditt personnummer");
                        string användarnamn2 = Console.ReadLine()!;
                        Console.WriteLine("Skriv in ditt lösenord");
                        string lösenord3 = Console.ReadLine()!;

                        if (personnummer2 == användarnamn2 && lösenord2 == lösenord3)
                        {
                            homepage.Användarhemsida();
                            return;
                        }
                        Login.LoggaIn();
                    }
                }
                
                

            }
            static void PasswordChange()
            {
                
                string dataFilePath = @"C:\Users\adrian.stude\Documents\Prog2\Bibliotek\bibliotek\Bibliotek\Konton.json";
                string data = File.ReadAllText(dataFilePath);
                dynamic personData = JsonConvert.DeserializeObject<dynamic>(data);

                Console.WriteLine("Användare eller bibliotikarie? 1: Användare, 2: Bibliotikarie");
                string val = Console.ReadLine();
                

                // Loop through the account data to find the logged-in user
                foreach (var i in personData)
                {
                    if (val == "1")
                    {
                        if (loggedInPerson.personnummer == (int)i.personnummer)
                        {
                            // Prompt the user to enter their new password
                            Console.WriteLine("Skriv ditt nya lösenord:");
                            string newPassword = Console.ReadLine();

                            // Update the account data with the new password
                            i.lösenord = newPassword;

                            // Write the updated account data back to the JSON file
                            string newData = JsonConvert.SerializeObject(personData, Formatting.Indented);
                            File.WriteAllText(dataFilePath, newData);

                            Console.WriteLine("Lösenordet har uppdaterats!");
                            break;
                        }
                    }
                }


                if (val == "2")
                {
                    Console.WriteLine("Vänligen skriv in ditt personnummer");
                    string användarnamn = Console.ReadLine();
                    Console.WriteLine("Skriv in ditt lösenord");
                    string lösenord = Console.ReadLine();


                    PasswordChange();
                }


            }

            static void SkapaKontoTemp()
            {
                string Data = File.ReadAllText("C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\Konton.json");
                dynamic personData = JsonConvert.DeserializeObject<dynamic>(Data)!;

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
                    Console.WriteLine("skriv personnummer:");
                    string användarnamn1 = Console.ReadLine();
                    Console.WriteLine("skriv ett lösenord");
                    Console.ReadLine();
                    Console.WriteLine("skriv adminkoden");
                    string lösenord1 = Console.ReadLine();
                    Console.WriteLine("du har nu skapat ett konto.");

                    string newUser = $"{{ \"förnamn\": \"test\", \"efternamn\": \"test\", \"personnummer\"\": {användarnamn1}, \"lösenord\": {lösenord1}\"}}";

                    personData.Add(JToken.FromObject(newUser));

                    string dataToSave = JsonConvert.SerializeObject(personData);
                    File.WriteAllText("C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\Konton.json", dataToSave);

                    Login.LoggaIn();


                }

                if (val == "2")
                {
                    //fixa sen
                }
            }


















        }
    }
}
