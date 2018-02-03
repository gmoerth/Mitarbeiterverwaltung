using MitarbeiterverwaltungWPF.ViewModels;
using MitarbeiterverwaltungWPF.Views;
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
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel viewModel;

        public MainWindow()
        {
            viewModel = new MainWindowViewModel();
            DataContext = viewModel;
            viewModel.LoadData();

            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click_Mitarbeiter_Add(object sender, RoutedEventArgs e)
        {
            viewModel.OnAddStudent();
        }

        private void Button_Click_Mitarbeiter_Edit(object sender, RoutedEventArgs e)
        {
            viewModel.OnEditMitarbeiter();
        }

        private void Button_Click_Mitarbeiter_Del(object sender, RoutedEventArgs e)
        {
            viewModel.OnDeleteMitarbeiter();
        }
    }
}
