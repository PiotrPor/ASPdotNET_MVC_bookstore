using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ProjektKsiegarnia.Models.KlasaDlaSesji; //by mozna uzyc funkcji UstawKto()

namespace ProjektKsiegarnia.Controllers
{
    public class HomeController : Controller
    {
        //Index(), About() i Kontakt() pokazuja strony z *.cshtml z folderu Views/Home/
        // @Html.ActionLink("Domowa Strona", "Index", "Home")
        public ActionResult Index()
        {
            return View(); 
        }

        // @Html.ActionLink("About", "About", "Home")
        public ActionResult About()
        {
            //w "Controllers/HomeController.cs" jest napisane "@ViewBag.Message" (duzy napis)
            //w "Views/Home/About.cshtml" jest npisany mniejszy tekst pod duzym napisem
            ViewBag.Message = "Krotka informacja do przeczytania o tej stronie";
            return View();
        }

        // @Html.ActionLink("Dane kontaktowa", "Contact", "Home")
        public ActionResult Kontakt()
        {
            //analogicznie jak "@ViewBag.Message" w About()
            ViewBag.Message = "Strona z danymi kontaktowymi";
            return View();
        }

        //uzywa danych itd z klasy KlasaDlaSesji.cs
        //przyjmuje liczbe ktory to z kolei uzytkownik w tablicy "Nazwy"
        public ActionResult UstawKto(int ktory)
        {
            if (ktory >= 1 && ktory <= 11)
            { IDuzytkownika = ktory - 2; }
            else
            { IDuzytkownika = -1; }
            NazwaZalogowanego = Nazwy[IDuzytkownika + 1];
            return RedirectToAction("Index");
        }
    }
}