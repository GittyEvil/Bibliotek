using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;



namespace Bibliotek
{
    public class BokSystem
    {
        private static BokSystem? instance = null;
        //private static string kontonFilePath = "C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\konton.txt";
        private static string BooksFilePath = "C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\Böcker.txt";
        private static string RentedbooksFilePath = "C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\Lånade_böcker.txt";
        public string Data = File.ReadAllText("C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\böcker.json");
        public string userData = File.ReadAllText("C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\Konton.json");
        private List<Bok> books = new List<Bok>();
        private static List<string> loanedbooks = new List<string>();
        public  static Person? loggedInPerson;

        public List<Bok> GetBooks() { return books; }

        //kollar ifall en person redan lånar en viss bok, genom att läsa fil och kolla så id/serienummer + person id stämmer
        public static bool currentPersonLoaningBook(Bok bok)
        {
            foreach (var line in loanedbooks)
            {
                string[] bookinformation = line.Split(" ");
                int loanedbookId = Int32.Parse(bookinformation[0]);
                string personId = bookinformation[1];

                if (bok.Serienummer == loanedbookId && personId == loggedInPerson!.id)
                {
                    return true;
                }
            }

            return false;
        }
        private BokSystem()
        {
            LoadBooks();
            LoggedUser();
            
        }
        //tar in en specifik bok för att lägga till körs via save
        public void AddBok(Bok bok)
        {
            books.Add(bok);
            Save();
        }
        //sparar boken i en lista(funkar)
        public void Save()
        {

            string[] bokStringArr = books.Select(bok => $"{bok.Titel} {bok.Antal} {bok.Serienummer} {bok.Författare}").ToArray();


            File.WriteAllLines(BooksFilePath, bokStringArr);
        }

        public static BokSystem GetInstance()
        {
            if (instance == null)
            {
                instance = new BokSystem();
            }
            return instance;
        }
        //detta är för att söka upp böcker, tar in input och jämför
        public List<Bok> Hittabooks(string val)
        {
            var sökning = new List<Bok>();

            foreach (var bok in books)
            {

                var tillgänglig = false;

                if (bok.Titel!.ToLower().Contains(val.ToLower()))
                {
                    tillgänglig = true;
                }

                if (bok.Författare!.ToLower().Contains(val.ToLower()))
                {
                    tillgänglig = true;
                }
                /*
                if (bok.Serienummer.Contains(val.ToLower()))
                {
                    tillgänglig = true;
                }
                */

                if (tillgänglig)
                {
                    sökning.Add(bok);
                }


            }
            return sökning;
        }
        //tar in en specifik bok och kollar om den är ledig, är den så läggs den till i lånadeböckertxt med id och serienummer
        public void Lånabok(Bok bok)
        {
            if(bok.Ledig)
            {
                if (bok.Ledig)
                {
                    var line = $"{bok.Serienummer} {loggedInPerson!.id}";
                    bok.Ledig = false;

                    loanedbooks.Add(line);
                    File.WriteAllLines(RentedbooksFilePath, loanedbooks);

                    Console.WriteLine($"Du har lånat boken '{bok.Titel}'. Glöm inte att lämna tillbaka den senast om tre veckor.");
                }
                else
                {
                    Console.WriteLine($"Boken '{bok.Titel}' är redan utlånad.");
                }
            }
        }
        //hanterar personer som loggar in
        void LoggedUser()
        {
            /*
            string[] personInfo = File.ReadAllLines(kontonFilePath);
            string[] personLista = personInfo[0].Split(" ");
            string personId = personLista[0];
            string förnamn= personLista[1];

            loggedInPerson = new Person(personId, förnamn);
            */

            //string Data = File.ReadAllText("C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\Konton.json");
            dynamic personData = JsonConvert.DeserializeObject<dynamic>(userData)!;
            foreach(var i in personData)
            {
                loggedInPerson = new Person((string)i.personnummer, (string)i.lösenord);
            }
        }
        //laddar upp böcker
        
        void LoadBooks()
        {
            //string Data = File.ReadAllText("C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\böcker.json");
            dynamic booksData = JsonConvert.DeserializeObject<dynamic>(Data)!;

            foreach (var i in booksData!)
            {
                Bok bok = new Bok((string)i.titel, (int)i.serienummer, (int)i.antal, (string)i.författare);
                books.Add(bok);
               
            }
        }
        //laddar upp lånade böcker från en txt fil
        void LoadRentedBooks()
        {
            string[] RentedBooks = File.ReadAllLines(RentedbooksFilePath);
            foreach(string books in RentedBooks)
            {
                loanedbooks.Add(books);
            }
        }
        //hanterar lämnandet av böcker, går igenom txt och kollar om inloggade personen stämmer över ifall så lämnar den tillbaka
        public static bool Returnbooks(Bok bok)
        {
            var bookremover = -1;

            for (var i = 0; i < loanedbooks.Count(); i++)
            {
                var line = loanedbooks[i];
                string[] bookinformation = line.Split(" ");
                int loanedbookId = Int32.Parse(bookinformation[0]);
                string personId = bookinformation[1];

                if (bok.Serienummer == loanedbookId && personId == loggedInPerson!.id)
                {
                    bookremover = i;
                }
            }

            if (bookremover == -1)
            {
                return false;
            }
            else
            {
                loanedbooks.RemoveAt(bookremover);
                File.WriteAllLines(RentedbooksFilePath, loanedbooks);
                bok.Ledig = true;
                Console.WriteLine($"Du har lämnat tillbaka boken '{bok.Titel}'. Tack för att du lånade den!");
                return true;
            }
        }


    }
}
