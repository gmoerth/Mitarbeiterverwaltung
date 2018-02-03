using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MitarbeiterwerwaltungDLL.Model
{
    public class Experten : Mitarbeiter
    {
        public Experten(int MitarbeiterID, string Name, DateTime Geburtsdatum, DateTime Eintrittsdatum, double Grundgehalt, string Fachgebiet) : base(MitarbeiterID, Name, Geburtsdatum, Eintrittsdatum, Grundgehalt)
        {
            this.Fachgebiet = Fachgebiet;
        }

        public Experten()
        {
        }

        private string _fachgebiet;
        public string Fachgebiet
        {
            get { return _fachgebiet; }
            set
            {
                _fachgebiet = value;
                NotifyPropertyChanged();
            }
        }
        public override double Jahresgehalt
        {
            get
            {
                return Grundgehalt * 15;
            }
        }

        public override string Ausgabe()
        {
            base.Ausgabe();
            strAusgabe += "\nFachgebiet:       " + Fachgebiet;
            return strAusgabe;
        }

        public override string this[string columnName]
        {
            get
            {
                string error = null;
                switch (columnName)
                {
                    case "Fachgebiet":
                        if (string.IsNullOrWhiteSpace(Fachgebiet))
                            error = "Das Feld Fachgebiet ist erforderlich";
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