using MitarbeiterverwaltungWPF.Views;
using MitarbeiterwerwaltungDLL.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //DummyRepository myRepository;

        public void LoadData()
        {
            //myRepository = new DummyRepository();
            Verwaltung.DummyPersonen();
            ReloadData();

        }

        public void ReloadData()
        {
            MitarbeiterList.Clear();
            //foreach (Student s in myRepository.LoadAllStudents())
            foreach (Mitarbeiter mit in Verwaltung.personen)
            {
                MitarbeiterList.Add(mit);
            }
        }

        public void OnAddStudent()
        {
            //Student student = ShowStudentDialog(new Student() { Birthdate = new DateTime(2000, 1, 1) });
            Mitarbeiter mitarbeiter = ShowMitarbeiterDialog(new Mitarbeiter()
            { Geburtsdatum = new DateTime(1980, 1, 1), Eintrittsdatum = DateTime.Today });
            if (mitarbeiter != null)
            {
                //myRepository.AddStudent(student);
                Verwaltung.AddPerson(mitarbeiter);
                ReloadData();
            }
        }

        public void OnEditMitarbeiter()
        {
            Mitarbeiter mit = ShowMitarbeiterDialog(SelectedMitarbeiter.Clone());
            if (mit != null)
            {
                //myRepository.UpdateStudent(s);
                Verwaltung.UpdatePerson(mit);
                int index = MitarbeiterList.IndexOf(SelectedMitarbeiter);
                MitarbeiterList[index] = mit;
                SelectedMitarbeiter = mit;
            }
        }

        public void OnDeleteMitarbeiter()
        {
            //myRepository.DeleteStudent(SelectedStudent);
            Verwaltung.DeletePerson(SelectedMitarbeiter);
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
