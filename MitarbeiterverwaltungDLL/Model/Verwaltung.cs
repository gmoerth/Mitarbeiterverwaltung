using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MitarbeiterwerwaltungDLL.Model
{
    public class Verwaltung : IMitarbeiterListVerwaltung
    {
        ObservableCollection<Mitarbeiter> personen = new ObservableCollection<Mitarbeiter>();

        public static IEnumerable<Mitarbeiter> DummyMitarbeiterList()
        {
            return new List<Mitarbeiter>()
            {
                new Mitarbeiter(1000, "Gerhard", DateTime.Parse("24.06.1967"), DateTime.Parse("1.10.2014"), 2345.67),
                new Manager(1001, "Christine", DateTime.Parse("09.05.1970"), DateTime.Parse("1.5.2012"), 4000.00, 5.5),
                new Experten(1002, "Susi", DateTime.Parse("11.10.1975"), DateTime.Parse("1.12.2016"), 3000.00, "SW-Entwicklung")
            };
        }

        public Verwaltung()
        {
            foreach (Mitarbeiter mit in DummyMitarbeiterList())
            {
                AddPerson(mit);
            }
        }

        public IEnumerable<Mitarbeiter> GetAllPersonen()
        {
            return personen;
        }

        public void AddPerson(Mitarbeiter Person)
        {
            personen.Add(Person);
        }

        public Mitarbeiter GetPerson(int ID)
        {
            foreach (Mitarbeiter mit in personen)
                if (mit.ID == ID)
                    return mit;
            return null;
        }

        public Mitarbeiter GetPerson(Mitarbeiter person)
        {
            foreach (Mitarbeiter mit in personen)
                if (mit.ID == person.ID)
                    return mit;
            return null;
        }

        public void DeletePerson(Mitarbeiter person)
        {
            foreach (Mitarbeiter mit in personen)
                if (mit.ID == person.ID)
                {
                    personen.Remove(mit);
                    break;
                }
        }

        public void UpdatePerson(Mitarbeiter person)
        {
            foreach (Mitarbeiter mit in personen)
                if (mit.ID == person.ID)
                {
                    personen[personen.IndexOf(mit)] = person;
                    break;
                }
        }

        public void Gehaltserhöhung(int ID, double Prozent)
        {
            foreach (Mitarbeiter mit in personen)
                if (mit.ID == ID)
                {
                    mit.Gehaltserhöhung(Prozent);
                    break;
                }
        }

        public void Gehaltserhöhung(double Prozent)
        {
            foreach (Mitarbeiter mit in personen)
                mit.Gehaltserhöhung(Prozent);
        }

        public string Ausgabe(int ID)
        {
            string str = "";
            foreach (Mitarbeiter mit in personen)
                if (mit.ID == ID)
                {
                    str = mit.Ausgabe();
                    break;
                }
            return str;
        }

        public string Ausgabe()
        {
            string str = "";
            foreach (Mitarbeiter mit in personen)
            {
                str += mit.Ausgabe();
                str += "\n";
            }
            return str;
        }
    }
}