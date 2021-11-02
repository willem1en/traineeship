using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesInheritance
{
    class Lion : Animal
    {
        public override void Eat()
        {
            Energy++;
        }
    }
}
