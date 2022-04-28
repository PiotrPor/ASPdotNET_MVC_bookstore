using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//klasa potrzebna by pod danymi klienta wypisac jego liste wypozyczonych ksiazek

namespace ProjektKsiegarnia.Models
{
    //do tej struktury przepisze sie informacje o konkretnym wypozyczeniu konkretnej ksiazki
    public struct BookStructure{
        public string Tytul;
        public string Autor;
        public float Cena;
        public int Ile;
    };

    public class KlasaDetali
    {
        public string Tozsamosc { get; set; }
        public DateTime OdKiedy { get; set; }
        public List<BookStructure> JegoKsiazki { get; set; } //co on wypozyczyl
        public int IleWypozyczonych { get; set; }

        //najwyrazniej konstruktor jest potrzebny, bo inaczej "JegoKsiazki" to bedzie null
        public KlasaDetali(string tm, DateTime dt, BookStructure bs)
        {
            Tozsamosc = tm;
            OdKiedy = dt;
            JegoKsiazki = new List<BookStructure>();
            JegoKsiazki.Add(bs);
            IleWypozyczonych = 1;
        }

        public KlasaDetali()
        {
            Tozsamosc = "N/N";
            OdKiedy = DateTime.Parse("2015-12-31");
            var bs = new BookStructure {Tytul="[bez tytulu]",Autor="Nikt",Cena=0,Ile=0};
            JegoKsiazki = new List<BookStructure>();
            JegoKsiazki.Add(bs);
            IleWypozyczonych = 1;
        }
    }
}