using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuecherListe
{
    class Buecher
    {
        //Properties
        public int ID { get; private set; }
        
        public string Titel { get; private set; }

        public string Author { get; private set; }

        public string Kurzbeschreibung { get; private set; }

        public string Kategorie { get; private set; }

        public string Verlag { get; private set; }

        //Konstruktur

        public Buecher(int id, string titel, string author, string kurzbeschreibung, string kategorie, string verlag)
        {
            if (author == null)
            {
                throw new ArgumentNullException();
            }

            else if (author == "" || titel == ""  ||kurzbeschreibung == "" || kategorie == "" ||verlag == "" || id <0)
            {
                throw new ArgumentException();
            }
            this.ID = id;
            this.Titel = titel;
            this.Author = author;
            this.Kurzbeschreibung = kurzbeschreibung;
            this.Kategorie = kategorie;
            this.Verlag = verlag;

        }
        public override string ToString()
        {
            return "ID: " + ID + "\n Titel: " + Titel + "\n Author: " + Author + "\n Kurzbeschreibung: " + Kurzbeschreibung + "\n Kategorie: " + Kategorie + "\n Verlag: " + Verlag;
        }

    }
}
