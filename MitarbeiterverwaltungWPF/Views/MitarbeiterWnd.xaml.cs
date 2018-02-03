using MitarbeiterverwaltungWPF.ViewModels;
using MitarbeiterwerwaltungDLL.Model;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace MitarbeiterverwaltungWPF.Views
{
    /// <summary>
    /// Interaktionslogik für MitarbeiterWnd.xaml
    /// </summary>
    public partial class MitarbeiterWnd : Window
    {
        MitarbeiterWndViewModel viewModel;

        //public MitarbeiterWnd()
        public MitarbeiterWnd(MitarbeiterWndViewModel viewModel)
        {
            DataContext = viewModel;
            this.viewModel = viewModel;

            InitializeComponent();

            txtName.Focus();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.HasErrors(this))
            {
                MessageBox.Show("Die eingegebenen Daten sind nicht gültig", "Fehler bei der Dateneingabe", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DialogResult = true;
            Close();
        }

        private void rbMitarbeiter_Click(object sender, RoutedEventArgs e)
        {
            viewModel.OnMitarbeiterClick();
            DataContext = Verwaltung.mitarbeiter;
            DataContext = viewModel;
        }

        private void rbManager_Click(object sender, RoutedEventArgs e)
        {
            viewModel.OnManagerClick();
            DataContext = Verwaltung.manager;
            DataContext = viewModel;
        }

        private void rbExperte_Click(object sender, RoutedEventArgs e)
        {
            viewModel.OnExperteClick();
            DataContext = Verwaltung.experte;
            DataContext = viewModel;
        }

    }
}
