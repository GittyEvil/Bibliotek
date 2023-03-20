using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class homepage
    {
        //hemsida för bibliotikarie
        public static void Hemsida()
        {
            var bibliotikarie =true;
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
            if(val == "3")
            {
                handlebook.Addbokpage();
                
            }
            if (val == "4")
            {
                //handlebook.Listaböcker();
            }

        }
        //hemsida för användare
        public static void Användarhemsida()
        {
            var bibliotikare = false;

            Console.WriteLine("du är inloggad");

            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("1, lista  böcker?");
            Console.WriteLine("2, byta kontouppgifter");
            Console.WriteLine("3, söka bok?");

            string val = Console.ReadLine()!;

            if (val == "1")
            {
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

       