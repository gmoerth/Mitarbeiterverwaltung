using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mitarbeiterverwaltung
{
    public class Manager : Mitarbeiter
    {
        public Manager(int MitarbeiterID, string Name, DateTime Geburtsdatum, DateTime Eintrittsdatum, double Grundgehalt, double Bonus) : base(MitarbeiterID, Name, Geburtsdatum, Eintrittsdatum, Grundgehalt)
        {
            this.Bonus = Bonus;
        }

        public double Bonus { get; set; }

        public override double Jahresgehalt()
        {
            return Grundgehalt * 14 * (1 + (Bonus / 100));
        }

        public override string Ausgabe()
        {
            base.Ausgabe();
            strAusgabe += "\nBonus:            " + Bonus.ToString("0.00") + " %";
            return strAusgabe;
        }

        public override void Gehaltserhöhung(double Prozent)
        {
            Grundgehalt = Grundgehalt * (1 + ((Prozent + Bonus) / 100));
        }
    }
}