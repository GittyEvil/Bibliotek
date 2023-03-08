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
        private static string booksFilePath = "C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\Böcker.txt";
        private List<Bok> books = new List<Bok>();

        public List<Bok> GetBooks() { return books; }

        private BokSystem()
        {
            LoadBooks();
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
            
            foreach(var bok in books)
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

                if (bok.Titel.ToLower().Contains(val.ToLower()))
                {
                    tillgänglig = true;
                }


                if(tillgänglig)
                {
                    sökning.Add(bok);
                }


            }
            return sökning;
        }
        void LoadBooks()
        {
            string Data = File.ReadAllText("C:\\Users\\adrian.stude\\Documents\\Prog2\\Bibliotek\\bibliotek\\Bibliotek\\böcker.json");
            dynamic booksData = JsonConvert.DeserializeObject<dynamic>(Data);

            foreach (var i in booksData!)
            {
                Bok bok = new Bok((string)i.bokTitel, (int)i.bokSerienummer, (int)i.bokAntal, (string)i.bokFörfattare);
                books.Add(bok);

               
            }
        }



    }
}
