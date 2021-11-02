using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesInheritance
{
    class Monkey : Animal
    {
        public Monkey()
        {
            Energy = 30;
        }

        public override void Eat()
        {
            Energy += 5;
        }
    }
}
