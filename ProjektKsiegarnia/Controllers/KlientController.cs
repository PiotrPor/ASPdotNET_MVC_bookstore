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
    public class KlientController : Controller
    {
        private KsiegarniaContext baza = new KsiegarniaContext();
        
        // GET: Klient
        public ActionResult Index()
        {
            return View(baza.ListaKlientow.ToList());
        }

        // GET: Klient/Details/5
        //nowa wersja napisana przeze mnie (poczatek jest ten co wczesniej)
        public ActionResult Details(int? id)
        {
            if (id == null)
            { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
            Klient tenklient = baza.ListaKlientow.Find(id);
            if (tenklient == null)
            { return HttpNotFound(); }
            List<Wypozyczenie> jegowyp = new List<Wypozyczenie>(); //lista wypozyczen tylko dla niego
            foreach (var wp in baza.ListaWypozyczen)
            {
                if (wp.KlientId == id)
                { jegowyp.Add(wp); }
            }
            var emptybs = new BookStructure { }; //potrzebne do ypisania jego wypozyczonych ksiazek
            KlasaDetali kd = new KlasaDetali(tenklient.ImieNazwisko, tenklient.DataDolaczenia,emptybs);
            Ksiazka ks;
            int ilewp = jegowyp.Count();
            int x=0;
            if (ilewp > 0)
            {
                kd.JegoKsiazki.Clear(); //lista bedzie pusta
                for (x = 0; x < ilewp; x++) //foreach(var jwp in jegowyp)
                {
                    ks = baza.ListaKsiazek.Find(jegowyp[x].KsiazkaId); //ksiazka z bazy z takim ID jak wpisane w bazie wypozyczen
                    emptybs.Tytul = ks.Tytul;
                    emptybs.Autor = ks.Autor;
                    emptybs.Cena = ks.Cena;
                    emptybs.Ile = jegowyp[x].Ile;
                    kd.JegoKsiazki.Add(emptybs);
                }
                //kd.IleWypozyczonych = ilewp;
            }
            /*else
            {
                emptybs.Tytul = "[bez tytulu]";
                emptybs.Autor = "Nikt";
                emptybs.Cena = 0;
                kd.JegoKsiazki[0] = emptybs;
            }*/
            kd.IleWypozyczonych = ilewp;
            return View(kd);
        }

        // GET: Klient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Klient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KlientId,ImieNazwisko,DataDolaczenia")] Klient klient)
        {
            if (ModelState.IsValid)
            {
                baza.ListaKlientow.Add(klient);
                baza.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(klient);
        }

        // GET: Klient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klient klient = baza.ListaKlientow.Find(id);
            if (klient == null)
            {
                return HttpNotFound();
            }
            return View(klient);
        }

        // POST: Klient/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KlientId,ImieNazwisko,DataDolaczenia")] Klient klient)
        {
            if (ModelState.IsValid)
            {
                baza.Entry(klient).State = EntityState.Modified;
                baza.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(klient);
        }

        // GET: Klient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klient klient = baza.ListaKlientow.Find(id);
            if (klient == null)
            {
                return HttpNotFound();
            }
            return View(klient);
        }

        // POST: Klient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Klient klient = baza.ListaKlientow.Find(id);
            baza.ListaKlientow.Remove(klient);
            baza.SaveChanges();
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
