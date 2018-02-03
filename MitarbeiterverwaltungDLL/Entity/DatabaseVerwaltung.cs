using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MitarbeiterwerwaltungDLL.Model;
using System.Windows;

namespace MitarbeiterwerwaltungDLL.Entity
{
    public class DatabaseVerwaltung : IMitarbeiterListVerwaltung
    {
        MitarbeiterList context = new MitarbeiterList();

        public void AddPerson(Model.Mitarbeiter mitarbeiter)
        {
            context.Mitarbeiter.Add(mitarbeiter);
            context.SaveChanges();
        }

        public void DeletePerson(Model.Mitarbeiter mitarbeiter)
        {
            Mitarbeiter orig = context.Mitarbeiter.Find(mitarbeiter.ID);
            if (orig == null)
            {
                //throw new ArgumentException($"Mitarbeiter mit der ID {mitarbeiter.ID} nicht gefunden");
                MessageBox.Show("Mitarbeiter nicht gefunden", "Fehler bei der Dateneingabe", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            context.Mitarbeiter.Remove(orig);
            context.SaveChanges();
        }

        public IEnumerable<Model.Mitarbeiter> GetAllPersonen()
        {
            try
            {
                return context.Mitarbeiter.ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "SQL Server nicht gefunden", MessageBoxButton.OK ,MessageBoxImage.Error);
                Environment.Exit(0); 
                return null;
            }
        }

        public Model.Mitarbeiter GetPerson(int id)
        {
            return context.Mitarbeiter.Find(id);
        }

        public void UpdatePerson(Model.Mitarbeiter mitarbeiter)
        {
            /*Mitarbeiter orig = context.Mitarbeiter.Find(mitarbeiter.ID);
            if (orig == null)
            {
                //throw new ArgumentException($"Mitarbeiter mit der ID {mitarbeiter.ID} nicht gefunden");
                MessageBox.Show("Mitarbeiter nicht gefunden", "Fehler bei der Dateneingabe", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            context.Entry(orig).CurrentValues.SetValues(mitarbeiter);
            context.SaveChanges();*/
            // löschen und hinzufügen funktioniert auch wenn "Hierarchie" geändert wird
            DeletePerson(mitarbeiter);
            AddPerson(mitarbeiter);
        }
    }
}
