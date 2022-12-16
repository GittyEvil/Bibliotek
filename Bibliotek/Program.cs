namespace Bibliotek
{
    internal class Program
    {
        //imports så jag kan använda class person och bok
        public static Person GetPerson = new Person();
        public static Bok GetBok = new Bok();

        var Json = [];
        //main metoden
        static void Main(string[] args)
        {

        }

        //class för användaren
        public class Användare : Person
        {
            bool admin = false;
            void inlogg()
            {

            }
        }

        //class för bibliotikarie
        public class Bibliotikarie: Person
        {

            bool admin = true;
            void inlogg()
            {

            }
        }

        //login sida
        static void Login()
        {
            Console.WriteLine("--");
            Console.WriteLine("||");
            Console.WriteLine("||");
            Console.WriteLine("||");
            Console.WriteLine("||");
            Console.WriteLine("||");
            Console.WriteLine("");

            string val = Console.ReadLine();
            if(val == "")
            {
                //användaren
            }
            if(val == "")
            {
                //bibliotikare
            }
        }

        //tänker mig UI då jag loggat in
        void UI()
        {

        }
    }
}