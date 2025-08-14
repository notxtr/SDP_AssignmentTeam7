using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class PercentageOffer : Offer
    {
        private double discount;
        private string description;
        public PercentageOffer(double discount, string description)
        {
            this.discount = discount;
            this.description = description;
        }
        public string getDescription()
        {
            return $"{description} - {discount * 100}% OFF ";
        }
        public double applyOffer(double amt)
        {
            return amt * (discount / 100);
        }

        public Offer Clone()
        {
            return new PercentageOffer(this.discount, this.description);
        }
    }
}
