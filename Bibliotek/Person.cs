using System;

namespace Bibliotek
{
    public class Person
    {
        public string? förnamn { get; set; }
        public string? efternamn { get; set; }
        public string? id { get; set; }
        public int? personnummer { get; set; }
        public int? lösenord { get; set; }

        public Person(string förnamn, string id) //string efternamn, string personnummer, int lösenord)
        {
            this.förnamn = förnamn;
            this.id = id;
            //this.efternamn = efternamn;
            //this.personnummer = personnummer;
            //this.lösenord = lösenord;
        }

        public Person(string förnamn, string efternamn, int personnummer, int lösenord) //string efternamn, string personnummer, int lösenord)
        {
            this.förnamn = förnamn;
            this.efternamn = efternamn;
            this.personnummer = personnummer;
            this.lösenord = lösenord;
        }

        public Person(int personnummer, int lösenord)
        {
            this.personnummer = personnummer;
            this.lösenord = lösenord;
        }
    }
}


