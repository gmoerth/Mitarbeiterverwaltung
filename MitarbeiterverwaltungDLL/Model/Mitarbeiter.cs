using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MitarbeiterwerwaltungDLL.Model
{
    [Table("Mitarbeiter")]
    public class Mitarbeiter : INotifyPropertyChanged, IDataErrorInfo
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

        public Mitarbeiter()
        {
        }

        private int _id;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyPropertyChanged();
            }
        }
        private string _name;
        [Required]
        [StringLength(256)]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }
        private DateTime _geburtsdatum;
        [Required]
        public DateTime Geburtsdatum
        {
            get { return _geburtsdatum; }
            set
            {
                _geburtsdatum = value;
                NotifyPropertyChanged();
            }
        }
        private DateTime _eintrittsdatum;
        [Required]
        public DateTime Eintrittsdatum
        {
            get { return _eintrittsdatum; }
            set
            {
                _eintrittsdatum = value;
                NotifyPropertyChanged();
            }
        }
        private double _grundgehalt;
        [Required]
        public double Grundgehalt
        {
            get { return _grundgehalt; }
            set
            {
                _grundgehalt = value;
                NotifyPropertyChanged();
            }
        }
        private string _hierarchie;
        [Required]
        [StringLength(50)]
        public string Hierarchie
        {
            get
            {
                _hierarchie = GetType().Name;
                return _hierarchie;
            }
            set
            {
                //_hierarchie = value;
                NotifyPropertyChanged();
            }
        }
        public virtual double Jahresgehalt
        {
            get
            {
                return Grundgehalt * 14;
            }
        }
        public TimeSpan Anstellungsdauer
        {
            get
            {
                TimeSpan span = DateTime.Now - Eintrittsdatum;
                return span;
            }
        }
        protected string strAusgabe;

        public virtual void Gehaltserhöhung(double Prozent)
        {
            Grundgehalt = Grundgehalt * (1 + (Prozent / 100));
        }

        public virtual string Ausgabe()
        {
            strAusgabe = "";
            strAusgabe += "\nHierarchie        " + Hierarchie;
            strAusgabe += "\nID:               " + ID.ToString();
            strAusgabe += "\nName:             " + Name;
            strAusgabe += "\nGeburtsdatum:     " + Geburtsdatum.ToShortDateString();
            strAusgabe += "\nEintrittsdatum:   " + Eintrittsdatum.ToShortDateString();
            strAusgabe += "\nGrundgehalt:      " + Grundgehalt.ToString("0.00") + " Euro";
            strAusgabe += "\nJahresgehalt:     " + Jahresgehalt.ToString("0.00") + " Euro";
            strAusgabe += "\nAnstellungsdauer: " + Anstellungsdauer.Days.ToString() + " Tage";
            return strAusgabe;
        }

        public override string ToString()
        {
            return GetType().Name + " " + ID + " " + Name;
        }

        public virtual Mitarbeiter Clone()
        {
            Mitarbeiter person = MemberwiseClone() as Mitarbeiter;
            return person;
        }

        public virtual Mitarbeiter Clone(Mitarbeiter person)
        {
            person.ID = ID;
            person.Name = Name;
            person.Geburtsdatum = Geburtsdatum;
            person.Eintrittsdatum = Eintrittsdatum;
            person.Grundgehalt = Grundgehalt;
            return person;
        }

        #region für IDataErrorInfo
        public virtual string Error
        {
            get { throw new NotImplementedException(); }
        }

        public virtual string this[string columnName]
        {
            get
            {
                string error = null;
                switch (columnName)
                {
                    case "ID":
                        if (ID <= 0)
                            error = "Es ist eine ID > 0 erforderlich";
                        break;
                    case "Name":
                        if (string.IsNullOrWhiteSpace(Name))
                            error = "Das Feld Name ist erforderlich";
                        break;
                    case "Geburtsdatum":
                        if (Geburtsdatum.Year < 1900)
                            error = "Das Geburtsdatum muss > 1900 sein";
                        else if (Geburtsdatum > DateTime.Today)
                            error = "Das Geburtsdatum darf nicht in der Zukunft sein";
                        break;
                    case "Eintrittsdatum":
                        if (Eintrittsdatum.Year < 2000)
                            error = "Das Eintrittsdatum muss > 2000 sein";
                        else if (Eintrittsdatum > DateTime.Today)
                            error = "Das Eintrittsdatum darf nicht in der Zukunft sein";
                        break;
                    case "Grundgehalt":
                        if (Grundgehalt <= 0)
                            error = "Es ist ein Grundgehalt > 0 erforderlich";
                        break;
                }
                return error;
            }
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion

    }
}