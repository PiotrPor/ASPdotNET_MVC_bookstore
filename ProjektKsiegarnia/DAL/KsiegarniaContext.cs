using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektKsiegarnia.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProjektKsiegarnia.DAL
{
    public class KsiegarniaContext : DbContext
    {
        public KsiegarniaContext() : base("KsiegarniaContext")
        { }

        public DbSet<Ksiazka> ListaKsiazek { get; set; }
        public DbSet<Klient> ListaKlientow { get; set; }
        public DbSet<Wypozyczenie> ListaWypozyczen { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}