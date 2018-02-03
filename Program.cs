using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mitarbeiterverwaltung
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test verschiedene Mitarbeiter
            Mitarbeiter mitarbeiter = new Mitarbeiter(1000, "Gerhard", DateTime.Parse("24.06.1967"), DateTime.Parse("1.10.2014"), 2345.67);
            Manager manager = new Manager(1001, "Christine", DateTime.Parse("09.05.1970"), DateTime.Parse("1.5.2012"), 4000.00, 5.5);
            Experten experten = new Experten(1002, "Susi", DateTime.Parse("11.10.1975"), DateTime.Parse("1.12.2016"), 3000.00, "SW-Entwicklung");
            // Test Verwaltung
            Verwaltung.AddPerson(mitarbeiter);
            Verwaltung.AddPerson(manager);
            Verwaltung.AddPerson(experten);
            Verwaltung.Ausgabe();
            // Test Gehaltserhöhung
            Verwaltung.Gehaltserhöhung(3.0);
            Verwaltung.Ausgabe();
            // Test ToString
            Console.WriteLine(manager);
        }
    }
}
