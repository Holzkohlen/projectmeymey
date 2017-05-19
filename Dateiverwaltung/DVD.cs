﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dateiverwaltung
{
    class DVD : Media
    {

        protected int iLength;
        protected string sDirector;
        protected byte byAge;

        public int Length { get { return iLength; } }
        public string Director { get { return sDirector; } }
        public byte Age { get { return byAge; } }

        //Konstrukor beim Erstellen
        public DVD(int iLength, string sDirector, byte byAge, string sTitel, string sGenre, DateTime dtRelease)
        {
            this.iLength = iLength;
            this.sDirector = sDirector;
            this.byAge = byAge;
            this.sTitel = sTitel;
            this.sGenre = sGenre;
            this.dtRelease = dtRelease;
        }

        //Konstruktor für Aulesen XMLDatei
        public DVD(int iID, int iLength, string sDirector, byte byAge, string sTitel, string sGenre, DateTime dtRelease, DateTime dtLent, bool bLent, int iIDCustomer)
        {
            this.iLength = iLength;
            this.sDirector = sDirector;
            this.byAge = byAge;
            this.sTitel = sTitel;
            this.sGenre = sGenre;
            this.dtRelease = dtRelease;
            this.bLent = bLent;
            this.iIDCustomer = iIDCustomer;
        }

        public DVD(string iID, string sTitel, string sGenre, string dtRelease, string bLent, string iIDCustomer, string dtLent, string iLength, string sDirector, string byAge)
        {
            this.iID = Int32.Parse(iID);
            this.iLength = Int32.Parse(iLength);
            this.sDirector = sDirector;
            this.byAge = Byte.Parse(byAge);
            this.sTitel = sTitel;
            this.sGenre = sGenre;
            this.dtRelease = DateTime.Parse(dtRelease);
            this.dtLent = DateTime.Parse(dtLent);
            this.bLent = (bLent == "True") ? true : false;
            this.iIDCustomer = Int32.Parse(iIDCustomer);
        }

        public DVD(){ }

        public override IDictionary<string, string> read()
        {
            IDictionary<string, string> Dictionary = new Dictionary<string, string>();
            Dictionary["Klasse"] = "DVD";
            Dictionary["ID"] = Convert.ToString(iID);
            Dictionary["Titel"] = sTitel;
            Dictionary["Genre"] = sGenre;
            Dictionary["Release"] = Convert.ToString(dtRelease);
            Dictionary["Ausgeliehen"] = Convert.ToString(bLent);
            Dictionary["Kunden-ID"] = Convert.ToString(iIDCustomer);
            Dictionary["Ausleidatum"] = Convert.ToString(dtLent);

            Dictionary["Länge"] = Convert.ToString(iLength);
            Dictionary["Regisseur"] = sDirector;
            Dictionary["Altersbegrenzung"] = Convert.ToString(byAge);

            return Dictionary;
        }

    }
}
