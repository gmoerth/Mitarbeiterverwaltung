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
using System.Windows.Shapes;

namespace Mitarbeiterverwaltung.Views
{
    /// <summary>
    /// Interaktionslogik für MitarbeiterWnd.xaml
    /// </summary>
    public partial class MitarbeiterWnd : Window
    {
        public MitarbeiterWnd()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            txtBonus.IsEnabled = false;
            txtFachgebiet.IsEnabled = false;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (rbMitarbeiter.IsChecked == true)
                {
                    Mitarbeiter mit = new Mitarbeiter(int.Parse(txtID.Text), txtName.Text, (DateTime)dtpGeburtsdatum.SelectedDate,
                        (DateTime)dtpEintrittsdatum.SelectedDate, double.Parse(txtGrundgehalt.Text));
                    Verwaltung.AddPerson(mit);
                }
                else if (rbManager.IsChecked == true)
                {
                    Manager man = new Manager(int.Parse(txtID.Text), txtName.Text, (DateTime)dtpGeburtsdatum.SelectedDate,
                        (DateTime)dtpEintrittsdatum.SelectedDate, double.Parse(txtGrundgehalt.Text), double.Parse(txtBonus.Text));
                    Verwaltung.AddPerson(man);
                }
                else
                {
                    Experten exp = new Experten(int.Parse(txtID.Text), txtName.Text, (DateTime)dtpGeburtsdatum.SelectedDate,
                        (DateTime)dtpEintrittsdatum.SelectedDate, double.Parse(txtGrundgehalt.Text), txtFachgebiet.Text);
                    Verwaltung.AddPerson(exp);
                }
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler bei der Dateneingabe", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void rbMitarbeiter_Click(object sender, RoutedEventArgs e)
        {
            txtBonus.IsEnabled = false;
            txtFachgebiet.IsEnabled = false;
            txtFachgebiet.Text = "";
            txtBonus.Text = "";
        }

        private void rbManager_Click(object sender, RoutedEventArgs e)
        {
            txtBonus.IsEnabled = true;
            txtFachgebiet.IsEnabled = false;
            txtFachgebiet.Text = "";
        }

        private void rbExperte_Click(object sender, RoutedEventArgs e)
        {
            txtBonus.IsEnabled = false;
            txtFachgebiet.IsEnabled = true;
            txtBonus.Text = "";
        }
    }
}
