using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MitarbeiterwerwaltungDLL.Model
{
    public class Manager : Mitarbeiter
    {
        public Manager(int MitarbeiterID, string Name, DateTime Geburtsdatum, DateTime Eintrittsdatum, double Grundgehalt, double Bonus) : base(MitarbeiterID, Name, Geburtsdatum, Eintrittsdatum, Grundgehalt)
        {
            this.Bonus = Bonus;
        }

        public Manager()
        {
        }

        private double _bonus;
        public double Bonus
        {
            get { return _bonus; }
            set
            {
                _bonus = value;
                NotifyPropertyChanged();
            }
        }
        public override double Jahresgehalt
        {
            get
            {
                return Grundgehalt * 14 * (1 + (Bonus / 100));
            }
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

        public override string this[string columnName]
        {
            get
            {
                string error = null;
                switch (columnName)
                {
                    case "Bonus":
                        if (Bonus <= 0)
                            error = "Es ist ein Bonus > 0 erforderlich";
                        break;
                    default:
                        error = base[columnName];
                        break;
                }
                return error;
            }
        }

    }
}