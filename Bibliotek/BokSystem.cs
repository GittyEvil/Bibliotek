using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

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

        public List<Bok> Getbooks(string val)
        {
            var sökning = new List<Bok>();
            var tillgänglig = false;
            foreach(var bok in books)
            {
                if(bok.Titel.ToLower().Contains(val.ToLower()))
                {
                    tillgänglig = true;
                }
                
                if (bok.Författare.ToLower().Contains(val.ToLower()))
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
            string[] bokFromDb = File.ReadAllLines(booksFilePath);

            for (var i = 0; i < bokFromDb.Length; i++)
            {
                string bokStr = bokFromDb[i];
                string[] bokLineTokens = bokStr.Split(" ");
                string bokTitel = bokLineTokens[0];
                int bokSerienummer = Int32.Parse(bokLineTokens[1]);
                int bokAntal = Int32.Parse(bokLineTokens[3]);
                string bokFörfattare = bokLineTokens[2];

                Bok bok = new Bok(bokTitel, bokSerienummer, bokAntal, bokFörfattare);
                books.Add(bok);
            }
        }
    }
}
