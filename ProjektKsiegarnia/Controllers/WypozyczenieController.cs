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
    public class WypozyczenieController : Controller
    {
        private KsiegarniaContext baza = new KsiegarniaContext();

        // GET: Wypozyczenie
        public ActionResult Index()
        {
            var listaWypozyczen = baza.ListaWypozyczen.Include(w => w.ksiazka).Include(w => w.wypozyczajacy);
            return View(listaWypozyczen.ToList());
        }

        // GET: Wypozyczenie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wypozyczenie wypozyczenie = baza.ListaWypozyczen.Find(id);
            if (wypozyczenie == null)
            {
                return HttpNotFound();
            }
            return View(wypozyczenie);
        }

        // GET: Wypozyczenie/Create
        public ActionResult Create()
        {
            ViewBag.KsiazkaId = new SelectList(baza.ListaKsiazek, "KsiazkaId", "Tytul");
            ViewBag.KlientId = new SelectList(baza.ListaKlientow, "KlientId", "ImieNazwisko");
            return View();
        }

        // POST: Wypozyczenie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WypozyczenieId,KlientId,KsiazkaId")] Wypozyczenie wypozyczenie)
        {
            if (ModelState.IsValid)
            {
                baza.ListaWypozyczen.Add(wypozyczenie);
                baza.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KsiazkaId = new SelectList(baza.ListaKsiazek, "KsiazkaId", "Tytul", wypozyczenie.KsiazkaId);
            ViewBag.KlientId = new SelectList(baza.ListaKlientow, "KlientId", "ImieNazwisko", wypozyczenie.KlientId);
            return View(wypozyczenie);
        }

        // GET: Wypozyczenie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wypozyczenie wypozyczenie = baza.ListaWypozyczen.Find(id);
            if (wypozyczenie == null)
            {
                return HttpNotFound();
            }
            ViewBag.KsiazkaId = new SelectList(baza.ListaKsiazek, "KsiazkaId", "Tytul", wypozyczenie.KsiazkaId);
            ViewBag.KlientId = new SelectList(baza.ListaKlientow, "KlientId", "ImieNazwisko", wypozyczenie.KlientId);
            return View(wypozyczenie);
        }

        // POST: Wypozyczenie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WypozyczenieId,KlientId,KsiazkaId")] Wypozyczenie wypozyczenie)
        {
            if (ModelState.IsValid)
            {
                baza.Entry(wypozyczenie).State = EntityState.Modified;
                baza.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KsiazkaId = new SelectList(baza.ListaKsiazek, "KsiazkaId", "Tytul", wypozyczenie.KsiazkaId);
            ViewBag.KlientId = new SelectList(baza.ListaKlientow, "KlientId", "ImieNazwisko", wypozyczenie.KlientId);
            return View(wypozyczenie);
        }

        // GET: Wypozyczenie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wypozyczenie wypozyczenie = baza.ListaWypozyczen.Find(id);
            if (wypozyczenie == null)
            {
                return HttpNotFound();
            }
            return View(wypozyczenie);
        }

        // POST: Wypozyczenie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wypozyczenie wypozyczenie = baza.ListaWypozyczen.Find(id);
            baza.ListaWypozyczen.Remove(wypozyczenie);
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
