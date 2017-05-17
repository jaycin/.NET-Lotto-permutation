using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaysData
{
    public class JaysContext : DbContext
    {
        public JaysContext ():base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        public DbSet<Number> Numbers { get; set; }
        public DbSet<Entry> Entries { get; set; }
        

    }
}
