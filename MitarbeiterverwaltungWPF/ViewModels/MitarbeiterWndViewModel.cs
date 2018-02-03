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
            Mitarbeiter = Mitarbeiter.Clone(new Mitarbeiter());
        }

        public void OnManagerClick()
        {
            Mitarbeiter = Mitarbeiter.Clone(new Manager());
        }

        public void OnExperteClick()
        {
            Mitarbeiter = Mitarbeiter.Clone(new Experten());
        }

    }
}
