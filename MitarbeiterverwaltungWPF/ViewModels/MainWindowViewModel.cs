using MitarbeiterverwaltungWPF.Views;
using MitarbeiterwerwaltungDLL;
using MitarbeiterwerwaltungDLL.Model;
using MitarbeiterwerwaltungDLL.Entity;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace MitarbeiterverwaltungWPF.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        public ObservableCollection<Mitarbeiter> MitarbeiterList { get; /*protected set;*/ } = new ObservableCollection<Mitarbeiter>();
        private Mitarbeiter _selectedMitarbeiter;
        public Mitarbeiter SelectedMitarbeiter
        {
            get
            {
                return _selectedMitarbeiter;
            }
            set
            {
                _selectedMitarbeiter = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("HasSelectedMitarbeiter");
            }
        }
        public bool HasSelectedMitarbeiter
        {
            get
            {
                return SelectedMitarbeiter != null;
            }
        }

        IMitarbeiterListVerwaltung verwaltung;

        public void LoadData()
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Mit Datenbank SQLExpress = JA\n\noder mit Dummy MitarbeiterList = Nein", "Mitarbeiterverwaltung © G_&_CH_MOERTH", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Database.SetInitializer(new DatabaseInit());
                verwaltung = new DatabaseVerwaltung();
            }
            else if (result == MessageBoxResult.No)
            {
                verwaltung = new Verwaltung();
            }

            ReloadData();
        }

        public void ReloadData()
        {
            MitarbeiterList.Clear();
            foreach (Mitarbeiter mit in verwaltung.GetAllPersonen())
            {
                MitarbeiterList.Add(mit);
            }
        }

        public void OnAddMitarbeiter()
        {
            int x = 0; // Neue Mitarbeiter bekommen immer neue ID ... gelöschte ID werden nicht nochmal vergeben
            foreach (Mitarbeiter mit in verwaltung.GetAllPersonen())
                if (mit.ID >= x)
                    x = mit.ID;
            Mitarbeiter mitarbeiter = ShowMitarbeiterDialog(new Mitarbeiter()
            { ID = ++x, Geburtsdatum = new DateTime(1980, 1, 1), Eintrittsdatum = DateTime.Today });
            if (mitarbeiter != null)
            {
                verwaltung.AddPerson(mitarbeiter);
                SelectedMitarbeiter = mitarbeiter;
                ReloadData();
            }
        }

        public void OnEditMitarbeiter()
        {
            Mitarbeiter mit = ShowMitarbeiterDialog(SelectedMitarbeiter.Clone());
            if (mit != null)
            {
                verwaltung.UpdatePerson(mit);
                int index = MitarbeiterList.IndexOf(SelectedMitarbeiter);
                MitarbeiterList[index] = mit;
                SelectedMitarbeiter = mit;
            }
        }

        public void OnDeleteMitarbeiter()
        {
            verwaltung.DeletePerson(SelectedMitarbeiter);
            ReloadData();
        }

        public Mitarbeiter ShowMitarbeiterDialog(Mitarbeiter mitarbeiter)
        {
            MitarbeiterWndViewModel viewModel = new MitarbeiterWndViewModel() { Mitarbeiter = mitarbeiter };
            MitarbeiterWnd dlgMitarbeiterWnd = new MitarbeiterWnd(viewModel);
            if (dlgMitarbeiterWnd.ShowDialog() == true)
            {
                return viewModel.Mitarbeiter;
            }
            else
                return null;
        }

    }
}
