using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class NoOffer : Offer
    {
        public override string getDescription()
        {
            return "No offer";
        }
        public override double applyOffer(double amt)
        {
            return amt;
        }
    }
}
