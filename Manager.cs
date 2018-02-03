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

        public override void Ausgabe()
        {
            base.Ausgabe();
            Console.WriteLine($"Bonus:            {Bonus:0.00} %");
        }

        public override void Gehaltserhöhung(double Prozent)
        {
            Grundgehalt = Grundgehalt * (1 + ((Prozent + Bonus) / 100));
        }
    }
}