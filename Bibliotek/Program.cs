namespace Bibliotek
{
    internal class Program
    {
        public static Person currentPerson = new Person();
        public static Bok currentBok = new Bok();

        static void Main(string[] args)
        {

        }


     public class Användare : Person
          {
              bool admin = false;
              void inlogg()
              {

              }
          }

     public class Bibliotikarie: Person
        {
            bool admin = true;
            void inlogg()
            {

            }
        }
        
    }
}