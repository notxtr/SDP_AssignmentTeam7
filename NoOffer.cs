using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class NoOffer : Offer
    {
        public string getDescription()
        {
            return "No offer";
        }
        public double applyOffer(double amt)
        {
            return amt;
        }

        public Offer Clone()
        {
            Offer clone = new NoOffer();
            return clone;
        }
    }
}
