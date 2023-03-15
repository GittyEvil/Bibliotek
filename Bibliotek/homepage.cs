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
            Console.WriteLine("1, lista böcker?");
            Console.WriteLine("2,byta kontouppgifter?");
            Console.WriteLine("3, lägga till bok?");
            Console.WriteLine("4, söka bok?");

            string val = Console.ReadLine()!;

            if (val == "1")
            {
                handlebook.Listaböcker();
            }
            if (val == "2")
            {
                ChangePassword.PasswordChange();
            }
            if (val == "3")
            {
                handlebook.Listaböcker();
            }
            if(val == "4")
            {
                handlebook.Addbokpage();
                
            }

        }

        public static void Användarhemsida()
        {

            Console.WriteLine("du är inloggad");

            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("1, lista  böcker?");
            Console.WriteLine("2, byta kontouppgifter");
            Console.WriteLine("3, söka bok?");

            string val = Console.ReadLine()!;

            if (val == "1")
            {
                //söka
                handlebook.Listaböcker();
            }
            if (val == "w")
            {
                ChangePassword.PasswordChange();
            }
            if (val == "3")
            {
                handlebook.Sökaböcker();
            }

        }



    }
}

       