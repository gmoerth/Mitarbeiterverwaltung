using MitarbeiterwerwaltungDLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitarbeiterverwaltungWPF.ViewModels
{
    public class MitarbeiterWndViewModel : BaseViewModel
    {
        public Mitarbeiter Mitarbeiter { get; set; }

        public void OnMitarbeiterClick()
        {
            Verwaltung.mitarbeiter.ID = Mitarbeiter.ID;
            Verwaltung.mitarbeiter.Name = Mitarbeiter.Name;
            Verwaltung.mitarbeiter.Geburtsdatum = Mitarbeiter.Geburtsdatum;
            Verwaltung.mitarbeiter.Eintrittsdatum = Mitarbeiter.Eintrittsdatum;
            Verwaltung.mitarbeiter.Grundgehalt = Mitarbeiter.Grundgehalt;
            if (Mitarbeiter.Hierarchie == "Manager")
                Verwaltung.manager.Bonus = ((Manager)Mitarbeiter).Bonus;
            if (Mitarbeiter.Hierarchie == "Experten")
                Verwaltung.experte.Fachgebiet = ((Experten)Mitarbeiter).Fachgebiet;
            Mitarbeiter = Verwaltung.mitarbeiter;
        }

        public void OnManagerClick()
        {
            Verwaltung.manager.ID = Mitarbeiter.ID;
            Verwaltung.manager.Name = Mitarbeiter.Name;
            Verwaltung.manager.Geburtsdatum = Mitarbeiter.Geburtsdatum;
            Verwaltung.manager.Eintrittsdatum = Mitarbeiter.Eintrittsdatum;
            Verwaltung.manager.Grundgehalt = Mitarbeiter.Grundgehalt;
            if (Mitarbeiter.Hierarchie == "Manager")
                Verwaltung.manager.Bonus = ((Manager)Mitarbeiter).Bonus;
            if (Mitarbeiter.Hierarchie == "Experten")
                Verwaltung.experte.Fachgebiet = ((Experten)Mitarbeiter).Fachgebiet;
            Mitarbeiter = Verwaltung.manager;
        }

        public void OnExperteClick()
        {
            Verwaltung.experte.ID = Mitarbeiter.ID;
            Verwaltung.experte.Name = Mitarbeiter.Name;
            Verwaltung.experte.Geburtsdatum = Mitarbeiter.Geburtsdatum;
            Verwaltung.experte.Eintrittsdatum = Mitarbeiter.Eintrittsdatum;
            Verwaltung.experte.Grundgehalt = Mitarbeiter.Grundgehalt;
            if (Mitarbeiter.Hierarchie == "Manager")
                Verwaltung.manager.Bonus = ((Manager)Mitarbeiter).Bonus;
            if (Mitarbeiter.Hierarchie == "Experten")
                Verwaltung.experte.Fachgebiet = ((Experten)Mitarbeiter).Fachgebiet;
            Mitarbeiter = Verwaltung.experte;
        }

    }
}
