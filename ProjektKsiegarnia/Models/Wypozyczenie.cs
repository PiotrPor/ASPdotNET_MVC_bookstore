using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektKsiegarnia.Models
{
    public class Wypozyczenie
    {
        [Key] public int WypozyczenieId { get; set; }
        public int KlientId { get; set; }
        public int KsiazkaId { get; set; }
        public int Ile { get; set; } = 1; //ile sztuk ksiazki wypozyczyl

        public virtual Klient wypozyczajacy { get; set; }
        public virtual Ksiazka ksiazka { get; set; }
    }
}