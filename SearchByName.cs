using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class SearchByName : Search
    {
        public override List<Restaurant> ExecuteSearch(List<Restaurant> restaurants, string query)
        {
            if (string.IsNullOrWhiteSpace(query)) return restaurants;
            if (restaurants == null || restaurants.Count == 0) return new List<Restaurant>();

            return restaurants.Where(r =>
                r.Name.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}