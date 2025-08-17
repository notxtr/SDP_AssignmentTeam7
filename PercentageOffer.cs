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
            return $"{description} - {discount:0}% OFF";
        }
        public double applyOffer(double amt)
        {
            var discounted = amt * (1 - (discount / 100));
            return double.Round(discounted, 2, MidpointRounding.AwayFromZero);
        }

        public Offer Clone()
        {
            return new PercentageOffer(this.discount, this.description);
        }
    }
}
