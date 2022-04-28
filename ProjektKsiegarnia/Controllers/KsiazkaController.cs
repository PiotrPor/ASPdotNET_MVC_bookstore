using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjektKsiegarnia.DAL;
using ProjektKsiegarnia.Models;

namespace ProjektKsiegarnia.Controllers
{
    public class KsiazkaController : Controller
    {
        private KsiegarniaContext baza = new KsiegarniaContext();

        // GET: Ksiazka
        /*public ActionResult Index()
        {
            return View(baza.ListaKsiazek.ToList());
        }*/

        //sortowanie:
        // docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/sorting-filtering-and-paging-with-the-entity-framework-in-an-asp-net-mvc-application
        public ActionResult Index(string porzadekSortowania)
        {

            //operator 3-argumentowy jak w C++
            //ViewBag.TitleSortParam = string.IsNullOrEmpty(porzadekSortowania) ? "title_desc" : "";
            ViewBag.TitleSortParam = (porzadekSortowania == "Title") ? "title_desc" : "";
            ViewBag.PriceSortParam = (porzadekSortowania == "Price") ? "price_desc" : "Price";

            var wszystkieksiazki = from k in baza.ListaKsiazek select k;

            switch (porzadekSortowania)
            {
                case "title_desc":
                    wszystkieksiazki = wszystkieksiazki.OrderByDescending(k => k.Tytul);
                    break;
                case "Price":
                    wszystkieksiazki = wszystkieksiazki.OrderBy(k => k.Cena);
                    break;
                case "price_desc":
                    wszystkieksiazki = wszystkieksiazki.OrderByDescending(k => k.Cena);
                    break;
                default:
                    wszystkieksiazki = wszystkieksiazki.OrderBy(k => k.Tytul);
                    break;
            }
            return View(wszystkieksiazki.ToList());
        }

        // GET: Ksiazka/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ksiazka ksiazka = baza.ListaKsiazek.Find(id);
            if (ksiazka == null)
            {
                return HttpNotFound();
            }
            return View(ksiazka);
        }

        // GET: Ksiazka/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ksiazka/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KsiazkaId,Tytul,Autor,ISBN")] Ksiazka ksiazka)
        {
            if (ModelState.IsValid)
            {
                baza.ListaKsiazek.Add(ksiazka);
                baza.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ksiazka);
        }

        // GET: Ksiazka/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ksiazka ksiazka = baza.ListaKsiazek.Find(id);
            if (ksiazka == null)
            {
                return HttpNotFound();
            }
            return View(ksiazka); //wywola "Edit.cshtml" z "Views/Ksiazka/" i poda model jak klasa obiektu "ksiazka"
        }

        // POST: Ksiazka/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KsiazkaId,Tytul,Autor,ISBN")] Ksiazka ksiazka)
        {
            if (ModelState.IsValid)
            {
                baza.Entry(ksiazka).State = EntityState.Modified;
                baza.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ksiazka);
        }

        // GET: Ksiazka/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ksiazka ksiazka = baza.ListaKsiazek.Find(id);
            if (ksiazka == null)
            {
                return HttpNotFound();
            }
            return View(ksiazka);
        }

        // POST: Ksiazka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ksiazka ksiazka = baza.ListaKsiazek.Find(id);
            baza.ListaKsiazek.Remove(ksiazka);
            baza.SaveChanges();
            return RedirectToAction("Index");
        }

        //jesli id=5 to wywolywany jest adres: localhost:44323/Ksiazka/Zakup/5
        public ActionResult Zakup(int id)
        {
            if (id == null)
            { 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
            }
            Ksiazka kupowana = baza.ListaKsiazek.Find(id);
            if (kupowana == null)
            {
                return HttpNotFound();
            }
            return View(kupowana); //przejdzie do "Views/Ksiazka/Zakup.cshtml"
        }

        //uruchomi sie, gdy w "Views/Ksiazka/Zakup.cshtml" klikniemy klawisz <input type="submit" value="Zakup" ... />
        [HttpPost, ActionName("Zakup")]
        [ValidateAntiForgeryToken]
        public ActionResult ZakupConfirmed(int id)
        {
            int IdKlienta = KlasaDlaSesji.IDuzytkownika;
            int maxid = 0;
            bool juzkupiona = false;
            foreach (var wp in baza.ListaWypozyczen)
            {
                if (wp.WypozyczenieId > maxid)
                { maxid = wp.WypozyczenieId; }
                if (wp.KsiazkaId == id && wp.KlientId == IdKlienta)
                { 
                    juzkupiona = true;
                    wp.Ile += 1; //zakupionych egzemplarzy jest o 1 wiecej
                }
            }
            maxid += 1; //nastepne po najwiekszym ID
            if (!juzkupiona)
            {
                Wypozyczenie nowewyp = new Wypozyczenie { WypozyczenieId = maxid, KlientId = IdKlienta, KsiazkaId = id };
                baza.ListaWypozyczen.Add(nowewyp);
            }
            baza.SaveChanges(); //zapisz zmiany w bazie danych
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                baza.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
