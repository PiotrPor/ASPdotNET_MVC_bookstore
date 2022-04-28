using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//klasa statyczna, by wszystkie podstrony ja jedyna widzialy
//przechowuje informacje o tym, kim jestesmy

namespace ProjektKsiegarnia.Models
{
    public static class KlasaDlaSesji
    {
        public static int IDuzytkownika { get; set; } = -1;
        public static int IleMozliwychUzytkownikow { get; set; } = 11;
        public static string NazwaZalogowanego { get; set; } = "Gosc"; 

        /*
         Gosc ma ID = -1
         Admin ma ID = 0
         Nastepni maja kolejno 1, 2, 3,...
         */
        public static string[] Nazwy { get; set; } = { 
            "Gosc", "Admin", "J_Kowalski", "Z_Tomaszewski", "D_Kryś", "D_Krysiak",
            "K_Balcerzyk", "M_Brzozowski", "T_Misiak", "T_Misicki", "P_Wrogowski"
        };

        //funkcja "UstawKto()" jest teraz w HomeController.cs
    }
}