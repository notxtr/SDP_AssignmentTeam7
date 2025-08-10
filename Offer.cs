using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal abstract class Offer
    {
        protected double discount;
        protected string description;

        public abstract string getDescription();
        public abstract double applyOffer(double amt);
    }
}
