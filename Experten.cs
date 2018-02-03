using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mitarbeiterverwaltung
{
    public class Experten : Mitarbeiter
    {
        public Experten(int MitarbeiterID, string Name, DateTime Geburtsdatum, DateTime Eintrittsdatum, double Grundgehalt, string Fachgebiet) : base(MitarbeiterID, Name, Geburtsdatum, Eintrittsdatum, Grundgehalt)
        {
            this.Fachgebiet = Fachgebiet;
        }

        public string Fachgebiet { get; set; }

        public override double Jahresgehalt()
        {
            return Grundgehalt * 15;
        }

        public override string Ausgabe()
        {
            base.Ausgabe();
            strAusgabe += "\nFachgebiet:       " + Fachgebiet;
            return strAusgabe;
        }
    }
}