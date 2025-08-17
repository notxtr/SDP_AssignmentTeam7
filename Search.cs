using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal abstract class Search
    {
        public abstract List<Restaurant> ExecuteSearch(List<Restaurant> restaurants, string query);
    }
}