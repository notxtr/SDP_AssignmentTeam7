using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal interface Aggregate
    {
        public Iterator createIterator(string filter, int Type);
    }
}
