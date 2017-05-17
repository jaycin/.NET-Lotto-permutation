using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JaysData
{
    public class Entry
    {
        public long EntryId { get; set; }
        
        public virtual Number N1 { get; set; }
        public virtual Number N2 { get; set; }
        public virtual Number N3 { get; set; }
        public virtual Number N4 { get; set; }
        public virtual Number N5 { get; set; }
        public virtual Number N6 { get; set; }


    }
}
