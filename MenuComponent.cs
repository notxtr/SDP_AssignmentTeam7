using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal abstract class MenuComponent 
    {
        public virtual void add(MenuComponent mc)
        {
            throw new NotSupportedException();
        }

        public virtual void remove(MenuComponent mc)
        {
            throw new NotSupportedException();
        }
        public virtual MenuComponent getChild(int index)
        {
            throw new NotSupportedException();
        }
        public virtual void print(string filter)
        {
            throw new NotSupportedException();
        }

        public virtual void subPrint(string filter, int Type)
        {
            throw new NotSupportedException();
        }

        public virtual string Name
        {
            get { throw new NotSupportedException(); }
        }

        public virtual string Description
        {
            get { throw new NotSupportedException(); }
        }

        public virtual string DishType
        {
            get { throw new NotSupportedException(); }
        }

        public virtual double Price
        {
            get { throw new NotSupportedException(); }
        }

    }
}
