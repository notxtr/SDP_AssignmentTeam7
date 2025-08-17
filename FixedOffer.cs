using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class FixedOffer: Offer
    {
        private double discount;
        private string description;
        public FixedOffer(double discount, string description)
        {
            this.discount = discount;
            this.description = description;
        }
        public string getDescription()
        {
            return $"{description} - ${discount} Off (Fixed) ";
        }
        public double applyOffer(double amt)
        {
            return amt - discount;
        }

        public Offer Clone()
        {
            return new FixedOffer(this.discount, this.description);
        }
    }
}
