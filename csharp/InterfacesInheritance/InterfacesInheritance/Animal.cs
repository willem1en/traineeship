using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesInheritance
{
    abstract class Animal
    {
        public string Name { get; set; }
        public int Energy { get; set; }
        public virtual void Eat()
        {
            Energy += 10;
        }

        public Animal()
        {
            Energy = 100;
        }

        public abstract void UseEnergy();
    }
}
