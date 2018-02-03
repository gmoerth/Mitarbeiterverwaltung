﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mitarbeiterverwaltung
{
    public class Mitarbeiter
    {
        public Mitarbeiter(int MitarbeiterID, string Name, DateTime Geburtsdatum, DateTime Eintrittsdatum, double Grundgehalt)
        {
            this.ID = MitarbeiterID;
            this.Name = Name;
            this.Geburtsdatum = Geburtsdatum;
            this.Eintrittsdatum = Eintrittsdatum;
            this.Grundgehalt = Grundgehalt;
        }

        public Mitarbeiter(int MitarbeiterID, string Name, DateTime Geburtsdatum, double Grundgehalt) : this(MitarbeiterID, Name, Geburtsdatum, DateTime.Today, Grundgehalt)
        {
        }

        public int ID { get; set; }
        public string Name { get; set; }
        private DateTime _Geburtsdatum;
        public DateTime Geburtsdatum
        {
            get { return _Geburtsdatum; }
            set
            {
                if (value <= DateTime.Today)
                    _Geburtsdatum = value;
                else
                    throw new ArgumentException("Geburtsdatum kann nicht in der Zukunft liegen");
            }
        }
        private DateTime _Eintrittsdatum;
        public DateTime Eintrittsdatum
        {
            get { return _Eintrittsdatum; }
            set
            {
                if (value <= DateTime.Today)
                    _Eintrittsdatum = value;
                else
                    throw new ArgumentException("Eintrittsdatum kann nicht in der Zukunft liegen");
            }
        }
        public double Grundgehalt { get; set; }
        protected string strAusgabe;

        public virtual double Jahresgehalt()
        {
            return Grundgehalt * 14;
        }

        public virtual void Gehaltserhöhung(double Prozent)
        {
            Grundgehalt = Grundgehalt * (1 + (Prozent / 100));
        }

        public TimeSpan Anstellungsdauer()
        {
            TimeSpan span = DateTime.Now - Eintrittsdatum;
            return span;
        }

        public virtual string Ausgabe()
        {
            strAusgabe = "";
            strAusgabe += "\nHierarchie        " + GetType().Name.ToString();
            strAusgabe += "\nID:               " + ID.ToString();
            strAusgabe += "\nName:             " + Name;
            strAusgabe += "\nGeburtsdatum:     " + Geburtsdatum.ToShortDateString();
            strAusgabe += "\nEintrittsdatum:   " + Eintrittsdatum.ToShortDateString();
            strAusgabe += "\nGrundgehalt:      " + Grundgehalt.ToString("0.00") + " Euro";
            strAusgabe += "\nJahresgehalt:     " + Jahresgehalt().ToString("0.00") + " Euro";
            strAusgabe += "\nAnstellungsdauer: " + Anstellungsdauer().Days.ToString() + " Tage";
            return strAusgabe;
        }

        public override string ToString()
        {
            return GetType().Name + " " + ID + " " + Name;
        }
    }
}