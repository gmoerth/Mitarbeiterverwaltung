using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mitarbeiterverwaltung
{
    public static class Verwaltung
    {
        static List<Mitarbeiter> personen = new List<Mitarbeiter>();

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