using System;

namespace Bibliotek
{
    public class Person
    {
        public string förnamn;
        public string lösenord;
        public int personnummer;

        public Person(string förnamn, string efternamn, int personnummer)
        {
            this.förnamn = förnamn;
            this.lösenord = efternamn;
            this.personnummer = personnummer;
        }
    }
}


