using System;


namespace Bibliotek
{
    public class Bok
    {
        public string Titel {get; set;}
        public string Serienummer { get; set; }
        public string Antal { get; set; }
        public string Författare { get; set; }

        public bool Ledig { get; set; }

        public Bok(string bokTitel, string bokAntal, string bokSerienummer, string bokFörfattare, bool bokLedig = true)
        {
            this.Titel = bokTitel;
            this.Antal = bokAntal;
            this.Serienummer = bokSerienummer;
            this.Författare = bokFörfattare;
            this.Ledig = bokLedig;
        }

    }

}
