using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Bibliotek
{
    public class ChangePassword
    {
        static Person? loggedInPerson = null;

        public static void PasswordChange()
        {
            //läser in filer
            string dataFilePath = @"C:\Users\adrian.stude\Documents\Prog2\Bibliotek\bibliotek\Bibliotek\Konton.json";
            string data = File.ReadAllText(dataFilePath);
            dynamic personData = JsonConvert.DeserializeObject<dynamic>(data)!;

            Console.WriteLine("Användare eller bibliotikarie? 1: Användare, 2: Bibliotikarie");
            string val = Console.ReadLine();


            // loopar igenom för att hitta den inloggade användaren
            foreach (var i in personData)
            {
                if (val == "1")
                {
                    if (loggedInPerson!.personnummer == (int)i.personnummer)
                    {
                        
                        Console.WriteLine("Skriv ditt nya lösenord:");
                        string newPassword = Console.ReadLine();

                        //uppdaterar det gamla lösenordet
                        i.lösenord = newPassword;

                        // skriver tillbaka den nya informationen och byter ut info
                        string newData = JsonConvert.SerializeObject(personData, Formatting.Indented);
                        File.WriteAllText(dataFilePath, newData);

                        Console.WriteLine("Lösenordet har uppdaterats!");
                        break;
                    }
                }
            }







        }

    }

