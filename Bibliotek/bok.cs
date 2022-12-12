using System;

public class Bok
{
    public class Book
    {
        string titel;
        int serienummer;
        int antal;
        string status;

        Book(string titel, int serienummer, int antal, string status)
        {
            this.titel = titel;
            this.serienummer = serienummer;
            this.antal = antal;
            this.status = status;
        }
    }


}
