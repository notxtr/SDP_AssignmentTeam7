using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class FixedOffer: Offer
    {
        public FixedOffer(double discount, string description)
        {
            this.discount = discount;
            this.description = description;
        }
        public override string getDescription()
        {
            return description;
        }
        public override double applyOffer(double amt)
        {
            return amt - discount;
        }
    }
}
