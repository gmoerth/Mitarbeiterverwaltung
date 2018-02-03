using Mitarbeiterverwaltung.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mitarbeiterverwaltung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click_Mitarbeiter_Add(object sender, RoutedEventArgs e)
        {
            MitarbeiterWnd mitDlg = new MitarbeiterWnd();
            if (mitDlg.ShowDialog() == true)
            {
                MessageBox.Show(Verwaltung.Ausgabe(), "Verwaltung -> Ausgabe", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            txtNummer.Text = mitDlg.txtID.Text;
        }

        private void Button_Click_Mitarbeiter_Get(object sender, RoutedEventArgs e)
        {
            try
            {
                int Nummer = int.Parse(txtNummer.Text);
                Mitarbeiter mit = Verwaltung.GetPerson(Nummer);
                MitarbeiterWnd mitDlg = new MitarbeiterWnd();
                mitDlg.txtID.Text = mit.ID.ToString();
                mitDlg.txtName.Text = mit.Name;
                mitDlg.dtpGeburtsdatum.Text = mit.Geburtsdatum.ToString();
                mitDlg.dtpEintrittsdatum.Text = mit.Eintrittsdatum.ToString();
                mitDlg.txtGrundgehalt.Text = mit.Grundgehalt.ToString("0.00");
                if (mit.GetType().Name == "Mitarbeiter")
                    mitDlg.rbMitarbeiter.IsChecked = true;
                else if (mit.GetType().Name == "Manager")
                {
                    mitDlg.rbManager.IsChecked = true;
                    Manager man = (Manager)Verwaltung.GetPerson(Nummer);
                    mitDlg.txtBonus.Text = man.Bonus.ToString("0.00");
                    mitDlg.txtBonus.IsEnabled = true;
                }
                else
                {
                    mitDlg.rbExperte.IsChecked = true;
                    Experten exp = (Experten)Verwaltung.GetPerson(Nummer);
                    mitDlg.txtFachgebiet.Text = exp.Fachgebiet;
                    mitDlg.txtFachgebiet.IsEnabled = true;
                }
                if (mitDlg.ShowDialog() == true)
                {
                    MessageBox.Show(Verwaltung.Ausgabe(), "Verwaltung -> Ausgabe", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler bei der Dateneingabe", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

    }
}
