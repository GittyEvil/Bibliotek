using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;



namespace Bibliotek
{
    public class BokSystem
    {
        private static BokSystem? instance = null;
        private static string kontonFilePath = "C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\konton.txt";
        private static string booksFilePath = "C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\Böcker.txt";
        private static string RentedbooksFilePath = "C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\Lånade_böcker.txt";
        private List<Bok> books = new List<Bok>();
        private List<string> loanedbooks = new List<string>();
        private Person loggedInPerson;

        public List<Bok> GetBooks() { return books; }

        private BokSystem()
        {
            LoadBooks();
            LoggedUser();
        }

        public void AddBok(Bok bok)
        {
            books.Add(bok);
            Save();
        }

        public void Save()
        {

            string[] bokStringArr = books.Select(bok => $"{bok.Titel} {bok.Antal} {bok.Serienummer} {bok.Författare}").ToArray();


            File.WriteAllLines(booksFilePath, bokStringArr);
        }

        public static BokSystem GetInstance()
        {
            if (instance == null)
            {
                instance = new BokSystem();
            }
            return instance;
        }

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

        public void Lånabok(Bok bok)
        {
            if(bok.Ledig)
            {
                Console.WriteLine("nu har du lånat boken");
                var line = $"{bok.Serienummer} {loggedInPerson.id}";
                bok.Ledig = false;

                loanedbooks.Add(line);
                File.WriteAllLines(RentedbooksFilePath, loanedbooks);
            }
        }

        void LoggedUser()
        {
            string[] personInfo = File.ReadAllLines(kontonFilePath);
            string[] personLista = personInfo[0].Split(" ");
            string personId = personLista[0];
            string förnamn= personLista[1];

            loggedInPerson = new Person(personId, förnamn);
        }
        public bool currentPersonLoaningBook(Bok bok)
        {
            foreach (string line in loanedbooks)
            {
                string[] bookinformation = line.Split(" ");
                int loanedbookId = Int32.Parse(bookinformation[0]);
                string personId = bookinformation[1];

                if (bok.Serienummer == loanedbookId && personId == loggedInPerson.id)
                {
                    return true;
                }
            }
            return false;
        }
        void LoadBooks()
        {
            string Data = File.ReadAllText("C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\böcker.json");
            dynamic booksData = JsonConvert.DeserializeObject<dynamic>(Data)!;

            foreach (var i in booksData!)
            {
                Bok bok = new Bok((string)i.titel, (int)i.serienummer, (int)i.antal, (string)i.författare);
                books.Add(bok);
               
            }
        }

        void LoadRentedBooks()
        {
            string[] RentedBooks = File.ReadAllLines(RentedbooksFilePath);
            foreach(string books in RentedBooks)
            {
                loanedbooks.Add(books);
            }
        }

        public bool Returnbooks(Bok bok)
        {
            var bookremover = -1;


            for (var i = 0;i < loanedbooks.Count();i++)
            {
                
                //lämna tillbaka böcker
                var line = loanedbooks[i];
                string[] bookinformation = line.Split(" ");
                int loanedbookId = Int32.Parse(bookinformation[0]);
                string personId = bookinformation[1];

                if(bok.Serienummer == loanedbookId && personId == loggedInPerson.id)
                {
                    bookremover = i;
                }
            }

            if(bookremover == -1)
            {
                return false;
            }else
            {
                loanedbooks.RemoveAt(bookremover);
                File.WriteAllLines(RentedbooksFilePath, loanedbooks);
                bok.Ledig = true;
                return true;
            }
        }


    }
}
