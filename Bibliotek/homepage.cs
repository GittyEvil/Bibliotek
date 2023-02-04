using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class homepage
    {
        public static void Hemsida()
        {
            Console.WriteLine("du är inloggad");

            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("1, låna bok?");
            Console.WriteLine("2, reservera bok?");
            Console.WriteLine("3, lämna tillbaka en bok?");
            Console.WriteLine("4,byta lösenord?");
            Console.WriteLine("5, lägga till bok");

            string val = Console.ReadLine();

            if (val == "1")
            {
                //låna bok
                Lånabok.Låna();
            }
            if (val == "2")
            {
                //reservera
            }
            if (val == "3")
            {
                //lämna tillbaka
            }
            if (val == "4")
            {
                //byta lösenord
            }
            if(val == "5")
            {
                //lägga till bok
                Addbook.Läggatillbok();
            }


        }

        public static void Användarhemsida()
        {

            Console.WriteLine("du är inloggad");

            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("1, låna bok?");
            Console.WriteLine("2, reservera bok?");
            Console.WriteLine("3, lämna tillbaka en bok?");
            Console.WriteLine("4,byta lösenord?");

            string val = Console.ReadLine();

            if (val == "1")
            {
                //låna bok
                Lånabok.Låna();
            }
            if (val == "2")
            {
                //reservera
            }
            if (val == "3")
            {
                //lämna tillbaka
            }
            if (val == "4")
            {
                //byta lösenord
            }

        }



    }
}

       