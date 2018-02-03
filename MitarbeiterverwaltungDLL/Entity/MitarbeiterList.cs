using MitarbeiterwerwaltungDLL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitarbeiterwerwaltungDLL.Entity
{
    public partial class MitarbeiterList : DbContext
    {
        public MitarbeiterList()
            : base("name=MitarbeiterList")
        {
        }

        public virtual DbSet<Mitarbeiter> Mitarbeiter { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mitarbeiter>()
               .Map<Mitarbeiter>(m => m.Requires("Discriminator").HasValue("Mit"))
               .Map<Manager>(m => m.Requires("Discriminator").HasValue("Man"))
               .Map<Experten>(m => m.Requires("Discriminator").HasValue("Exp"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
