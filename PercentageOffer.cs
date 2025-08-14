using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class PercentageOffer : Offer
    {
        public PercentageOffer(double discount, string description)
        {
            this.discount = discount;
            this.description = description;
        }
        public override string getDescription()
        {
            return $"{description} - {discount * 100}% OFF ";
        }
        public override double applyOffer(double amt)
        {
            return amt * (discount / 100);
        }

        public override Offer Clone()
        {
            return new PercentageOffer(this.discount, this.description);
        }
    }
}
