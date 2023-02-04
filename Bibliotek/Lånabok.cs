using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class Lånabok
    {

        public static void Låna()
        {
            Bok nybok = new Bok("olof", 124, 1, "ledig");

            Console.WriteLine("Vilken bok skulle du vilja låna?, går att söka via författare, titel och genrer");
            string valavbok = Console.ReadLine();

            string böcker = null;


        }

    }
}
