using System;


namespace Bibliotek
{
    public class Bok
    {
        public string Titel {get; set;}
        public int Serienummer { get; set; }
        public int Antal { get; set; }
        public string Författare { get; set; }

        public bool Ledig { get; set; }

        public Bok(string bokTitel, int bokAntal, int bokSerienummer, string bokFörfattare, bool bokLedig = true)
        {
            this.Titel = bokTitel;
            this.Antal = bokAntal;
            this.Serienummer = bokSerienummer;
            this.Författare = bokFörfattare;
            this.Ledig = bokLedig;
        }

    }

}
