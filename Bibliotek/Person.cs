using System;

namespace Bibliotek
{
    public class Person
    {
        string förnamn;
        string efternamn;
        int personnummer;

        Person(string förnamn, string efternamn, int personnummer)
        {
            this.förnamn = förnamn;
            this.efternamn = efternamn;
            this.personnummer = personnummer;
        }
    }
}


