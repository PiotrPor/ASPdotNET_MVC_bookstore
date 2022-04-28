using System;
using System.ComponentModel.DataAnnotations;
//using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektKsiegarnia.Models
{
    public class Ksiazka
    {
        //'[Key]' jest potrzebne by nie bylo erroru prze kreowaniu "KsiazkaController.cs" (?)
        [Key]  public int KsiazkaId { get; set; }
        public string Tytul { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public float Cena { get; set; }
        public string Recenzja { get; set; }
    }
}