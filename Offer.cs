using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal interface Offer
    {

        public abstract string getDescription();
        public abstract double applyOffer(double amt);


        public abstract Offer Clone();
    }
}
