using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProjektKsiegarnia.Models;


namespace ProjektKsiegarnia.DAL
{
    public class KsiegarniaInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<KsiegarniaContext>
    {
        //potrzebne do wlozenia do konstruktorow Ksiazek w Seed()
        float[] ceny = { 
            29.90f, 44.90f, 49.90f, 39.90f, 129, 39.99f, 12.99f, 26.90f, 34.90f, 129,
            39.99f, 25.60f, 39.90f, 29, 35.90f, 34, 45, 49.90f, 54.90f
        };
        string[] recenzje = {
            "Popularna kolekcja historii dla czytelników w prawie każdym wieku napisana przez Stanisława Lema",
            "Jeszcze jeden zbiór opowiastek od sławnego Polskiego autora science-fiction",
            "Autor podejmuje niełatwy i kontrowersyjny temat o chęci zysku powstrzymującej rozwój.",
            "Nawet jeśli nie jesteś biznesmenem, z tą książką w ręce zbijesz majątek.",
            "Ta książka jest niezbędnikiem dla kogoś, kto chce prowadzić biznes w Internecie.",
            "Nowatorska interpretacja historii o rozbitku- zamiast bezludnej wyspy mamy planetę",
            "Wprowadzjąca w przygnebienie wizja dyktatorskiego reżimu inspirowanego stalinizmem",
            "Pobudzająca do myślenia historia dystopii, gdzie dla lepszej przyszłości czyni się złe rzeczy.",
            "Historia z elementami horroru i kryminału, akcja dzieje się w nietypowych czasach",
            "Przystępne i przydatne wprowadzenie do sztuki zdobywania klientów dla Twojego biznesu.",
            "Wizja postapokaliptycznego świata w nietypowym środowisku - tunelach moskiewskiego metra.",
            "Jedna z pierwszych powieści tegu typu, stworzona przez pioniera gatunku.",
            "Pomimo że to nie podręcznik, ta pozycja da ci wiele wiedzy na temat fizyki kwantowej.",
            "Trzymająca w napięciu historia pokazująca, że każdy może zdecydować walczyć przeciw tyranom",
            "Trzymający w napięciu horror, gdzie każdy może być potworem - nawet o tym nie wiedząc",
            "To świetna książka jeśli chce się zdobyć jakieś pojęcie w tematyce fizyki kwantowej.",
            "Powieść science-fiction, gdzie zamiast planety bohaterowie zwiedzą megastrukturę...",
            "Część legendarnej serii od jednego z najznakiemitniejszych autorów science-fiction",
            "Tajemnicza mroczna wizja, skupiająca się na rzeczywistości, gdzie zło zwyciężyło",
        };

        //wypelnianie tabel i wgranie ich do bazy danych
        protected override void Seed(KsiegarniaContext kontekst)
        {
            var tomiszcza = new List<Ksiazka>
            {
                new Ksiazka{KsiazkaId=1,Tytul="Bajki robotów",Autor="Stanisław Lem",ISBN="978-83-080-4889-4",Cena=ceny[0],Recenzja=recenzje[0]},
                new Ksiazka{KsiazkaId=2,Tytul="Opowieści o pilocie Pirxie",Autor="Stanisław Lem",ISBN="978-83-080-7054-3",Cena=ceny[1],Recenzja=recenzje[1]},
                new Ksiazka{KsiazkaId=3,Tytul="Pułapka",Autor="Jacek Giedrojć",ISBN="978-83-240-5528-9",Cena=ceny[2],Recenzja=recenzje[2]},
                new Ksiazka{KsiazkaId=4,Tytul="Giełda. Podstawy Inwestowania",Autor="Adam Zaremba",ISBN="978-83-246-8050-4",Cena=ceny[3],Recenzja=recenzje[3]},
                new Ksiazka{KsiazkaId=5,Tytul="Biblia e-biznesu 2. Nowy testament",Autor="Maciej Dutko",ISBN="978-83-283-2464-0",Cena=ceny[4],Recenzja=recenzje[4]},
                new Ksiazka{KsiazkaId=6,Tytul="Marsjanin",Autor="Andy Weir",ISBN="978-83-287-0364-3",Cena=ceny[5],Recenzja=recenzje[5]},
                new Ksiazka{KsiazkaId=7,Tytul="Rok 1984",Autor="George Orwell",ISBN="978-83-287-0650-7",Cena=ceny[6],Recenzja=recenzje[6]},
                new Ksiazka{KsiazkaId=8,Tytul="Nowy wspaniały świat",Autor="Aldous Haxley",ISBN="978-83-287-0830-3",Cena=ceny[7],Recenzja=recenzje[7]},
                new Ksiazka{KsiazkaId=9,Tytul="Marina",Autor="Carlos Ruiz Zafon",ISBN="978-83-287-1533-2",Cena=ceny[8],Recenzja=recenzje[8]},
                new Ksiazka{KsiazkaId=10,Tytul="Marketing: Wprowadzenie",Autor="Gary Armstrong",ISBN="978-83-633-9110-2",Cena=ceny[9],Recenzja=recenzje[9]},
                new Ksiazka{KsiazkaId=11,Tytul="Metro 2035",Autor="Dmitry Glukhovsky",ISBN="978-83-653150-5-2",Cena=ceny[10],Recenzja=recenzje[10]},
                new Ksiazka{KsiazkaId=12,Tytul="Wehikuł czasu",Autor="Herbert George Wells",ISBN="978-83-654-9955-4",Cena=ceny[11],Recenzja=recenzje[11]},
                new Ksiazka{KsiazkaId=13,Tytul="Kwantowy świat",Autor="Amit Goswani",ISBN="978-83-66234-00-0",Cena=ceny[12],Recenzja=recenzje[12]},
                new Ksiazka{KsiazkaId=14,Tytul="451 stopni Fahrenheita",Autor="Ray Bradbury",ISBN="978-83-748-0922-1",Cena=ceny[13],Recenzja=recenzje[13]},
                new Ksiazka{KsiazkaId=15,Tytul="Coś",Autor="John Wood Campbell",ISBN="978-83-773-1341-1",Cena=ceny[14],Recenzja=recenzje[14]},
                new Ksiazka{KsiazkaId=16,Tytul="Krótka Historia Czasu",Autor="Stephen Hawking",ISBN="978-83-7785-767-0",Cena=ceny[15],Recenzja=recenzje[15]},
                new Ksiazka{KsiazkaId=17,Tytul="Pierścień",Autor="Larry Niven",ISBN="978-83-811-6539-6",Cena=ceny[16],Recenzja=recenzje[16]},
                new Ksiazka{KsiazkaId=18,Tytul="Narodziny Fundacji",Autor="Isaac Asimov",ISBN="978-83-818-8081-7",Cena=ceny[17],Recenzja=recenzje[17]},
                new Ksiazka{KsiazkaId=19,Tytul="Człowiek z wysokiego zamku",Autor="Philip Kindred Dick",ISBN="978-83-818-8155-5",Cena=ceny[18],Recenzja=recenzje[18]}
            };
            tomiszcza.ForEach(k => kontekst.ListaKsiazek.Add(k));
            kontekst.SaveChanges();

            var ludzie = new List<Klient>
            {
                //nie ma tu Goscia i Administratora
                new Klient(1,"Jan Kowalski",DateTime.Parse("2018-02-20")),
                new Klient(2,"Zbigniew Tomaszewski",DateTime.Parse("2018-03-06")),
                new Klient(3,"Damian Kryś",DateTime.Parse("2018-02-22")),
                new Klient(4,"Daniel Krysiak",DateTime.Parse("2018-05-11")),
                new Klient(5,"Krystian Balcerzyk",DateTime.Parse("2018-05-10")),
                new Klient(6,"Mateusz Brzozowski",DateTime.Parse("2018-05-10")),
                new Klient(7,"Tomasz Misiak",DateTime.Parse("2018-05-10")),
                new Klient(8,"Tadeusz Misicki",DateTime.Parse("2018-05-10")),
                new Klient(9,"Piotr Wrogowski",DateTime.Parse("2018-04-09"))
            };
            ludzie.ForEach(k => kontekst.ListaKlientow.Add(k));
            kontekst.SaveChanges();

            var pozyczki = new List<Wypozyczenie>
            {
                new Wypozyczenie{WypozyczenieId=1,KlientId=2,KsiazkaId=1},
                new Wypozyczenie{WypozyczenieId=2,KlientId=2,KsiazkaId=2},
                new Wypozyczenie{WypozyczenieId=3,KlientId=6,KsiazkaId=14},
                new Wypozyczenie{WypozyczenieId=4,KlientId=6,KsiazkaId=7},
                new Wypozyczenie{WypozyczenieId=5,KlientId=1,KsiazkaId=8},
                new Wypozyczenie{WypozyczenieId=6,KlientId=4,KsiazkaId=1},
                new Wypozyczenie{WypozyczenieId=7,KlientId=3,KsiazkaId=5}
            };
            pozyczki.ForEach(p => kontekst.ListaWypozyczen.Add(p));
            kontekst.SaveChanges();

            //base.Seed(kontekst);
        }
    }
}
