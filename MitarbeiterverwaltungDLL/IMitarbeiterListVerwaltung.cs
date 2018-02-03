using MitarbeiterwerwaltungDLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitarbeiterwerwaltungDLL
{
    public interface IMitarbeiterListVerwaltung
    {
        void AddPerson(Mitarbeiter mitarbeiter);
        Mitarbeiter GetPerson(int id);
        void UpdatePerson(Mitarbeiter mitarbeiter);
        void DeletePerson(Mitarbeiter mitarbeiter);

        IEnumerable<Mitarbeiter> GetAllPersonen();
    }
}
