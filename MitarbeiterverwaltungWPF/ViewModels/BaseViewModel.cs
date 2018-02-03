using MitarbeiterwerwaltungDLL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MitarbeiterverwaltungWPF.ViewModels
{
    public class BaseViewModel : Mitarbeiter, INotifyPropertyChanged, IDataErrorInfo
    {
        public bool HasErrors(DependencyObject obj)
        {
            return Validation.GetHasError(obj) || LogicalTreeHelper.GetChildren(obj).OfType<DependencyObject>().Any(HasErrors);
        }
    }
}
