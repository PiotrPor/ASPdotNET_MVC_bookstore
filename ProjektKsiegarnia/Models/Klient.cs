using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektKsiegarnia.Models
{
    public class Klient
    {
        //potrzebne by nie bylo erroru prze kreowaniu "KsiazkaController.cs" ?
        [Key] public int KlientId { get; set; }
        public string ImieNazwisko { get; set; }
        public DateTime DataDolaczenia { get; set; }

        public Klient(int dd, string im, DateTime dt)
        {
            KlientId = dd;
            ImieNazwisko = im;
            DataDolaczenia = dt;
        }

        //jesli nie bedzie do tego bezparametrowego konstruktora
        //to w "Views/Klient/Index.cshtml/Index()" bedzie breakpoint/exception
        public Klient()
        {
            KlientId = 0;
            ImieNazwisko = "John Doe";
            DataDolaczenia = DateTime.Parse("2000-12-31");
        }
    }
}