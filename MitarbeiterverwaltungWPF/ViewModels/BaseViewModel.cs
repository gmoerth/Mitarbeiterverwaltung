using MitarbeiterwerwaltungDLL.Model;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace MitarbeiterverwaltungWPF.ViewModels
{
    /*
    * Anmerkung von Michaela: Die Basisklasse für die View-Models und die Entity-Klassen haben eigentlich keine Ist-Ein Beziehung.
    * Daher ist es zwar compilertechnisch erlaubt die Klasse von Mitarbeiter abzuleiten und die Implementierung zu nützen. 
    * Es ist aber logisch nicht richtig und daher sollte man es auch nicht machen. Wenn sehr viel gemeinsamer Code existiert, 
    * kann man stattdessen eine gemeinsame Basisklasse schreiben (NotifyingObjectBase oder so) oder den gemeinsamen Code in eine 
    * Hilfsklasse auslagern.
    * Für INotifyPropertyChanged ist es besser die Schnittstelle hier eigenständig noch einmal zu implementieren.
    * Und für IDataErrorInfo ist fraglich ob die Implmentierung hier wirklich nötig ist. Wenn ja gilt dasselbe auch hier
    *
    * public class BaseViewModel : Mitarbeiter, INotifyPropertyChanged, IDataErrorInfo 
    */ 
    public class BaseViewModel : INotifyPropertyChanged
    {
        public bool HasErrors(DependencyObject obj)
        {
            return Validation.GetHasError(obj) || LogicalTreeHelper.GetChildren(obj).OfType<DependencyObject>().Any(HasErrors);
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion
    }
}
