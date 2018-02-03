using MitarbeiterwerwaltungDLL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitarbeiterwerwaltungDLL.Entity
{
    public class DatabaseInit : DropCreateDatabaseIfModelChanges<MitarbeiterList>
    {
        protected override void Seed(MitarbeiterList context)
        {
            //base.Seed(context);
            foreach (Mitarbeiter mit in Verwaltung.DummyMitarbeiterList())
            {
                context.Mitarbeiter.Add(mit);
            }
            context.SaveChanges();
        }
    }
}
