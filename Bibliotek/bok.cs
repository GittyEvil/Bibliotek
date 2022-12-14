using System;

public class Bok
{
        string titel;
        int serienummer;
        int antal;
        string status;

        Bok(string titel, int serienummer, int antal, string status)
        {
            this.titel = titel;
            this.serienummer = serienummer;
            this.antal = antal;
            this.status = status;
        }
}
