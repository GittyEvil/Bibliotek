using System;


namespace Bibliotek
{
    public class Bok
    {
        string titel;
        int serienummer;
        int antal;
        string författare;

        public Bok(string titel, int serienummer, int antal, string författare)
        {
            this.titel = titel;
            this.serienummer = serienummer;
            this.antal = antal;
            this.författare = författare;
        }

        public Bok(string? titel, string? antal1, string serienummer1, string? författare)
        {
            this.titel = titel;
            Antal = antal1;
            Serienummer = serienummer1;
            this.författare = författare;
        }

        public string? Antal { get; }
        public string Serienummer { get; }
    }

}
