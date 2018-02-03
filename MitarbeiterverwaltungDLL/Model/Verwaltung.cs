using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MitarbeiterwerwaltungDLL.Model
{
    public static class Verwaltung
    {
        public static ObservableCollection<Mitarbeiter> personen = new ObservableCollection<Mitarbeiter>();
        public static Mitarbeiter mitarbeiter = new Mitarbeiter();
        public static Manager manager = new Manager();
        public static Experten experte = new Experten();

        public static void DummyPersonen()
        {
            Mitarbeiter mitarbeiter1 = new Mitarbeiter(1000, "Gerhard", DateTime.Parse("24.06.1967"), DateTime.Parse("1.1.2014"), 2345.67);
            AddPerson(mitarbeiter1);
            Manager mitarbeiter2 = new Manager(1001, "Christine", DateTime.Parse("09.05.1970"), DateTime.Parse("1.5.2012"), 4000.00, 5.5);
            AddPerson(mitarbeiter2);
            Experten mitarbeiter3 = new Experten(1002, "Susi", DateTime.Parse("11.10.1975"), DateTime.Parse("1.12.2016"), 3000.00, "Kochen");
            AddPerson(mitarbeiter3);
        }

        public static void AddPerson(Mitarbeiter Person)
        {
            personen.Add(Person);
        }

        public static Mitarbeiter GetPerson(int ID)
        {
            foreach (Mitarbeiter mit in personen)
                if (mit.ID == ID)
                    return mit;
            return null;
        }

        public static Mitarbeiter GetPerson(Mitarbeiter person)
        {
            foreach (Mitarbeiter mit in personen)
                if (mit.ID == person.ID)
                    return mit;
            return null;
        }

        public static void DeletePerson(Mitarbeiter person)
        {
            foreach (Mitarbeiter mit in personen)
                if (mit.ID == person.ID)
                {
                    personen.Remove(mit);
                    break;
                }
        }

        public static void UpdatePerson(Mitarbeiter person)
        {
            foreach (Mitarbeiter mit in personen)
                if (mit.ID == person.ID)
                {
                    personen[personen.IndexOf(mit)] = person;
                    break;
                }
        }

        public static void Gehaltserhöhung(int ID, double Prozent)
        {
            foreach (Mitarbeiter mit in personen)
                if (mit.ID == ID)
                {
                    mit.Gehaltserhöhung(Prozent);
                    break;
                }
        }

        public static void Gehaltserhöhung(double Prozent)
        {
            foreach (Mitarbeiter mit in personen)
                mit.Gehaltserhöhung(Prozent);
        }

        public static string Ausgabe(int ID)
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

        public static string Ausgabe()
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