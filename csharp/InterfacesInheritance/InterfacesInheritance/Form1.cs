using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfacesInheritance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TestCalculators_Click(object sender, EventArgs e)
        {
            var wc = new WillemsCalculator();
            var nc = new NewCalculator();

            var calc = new List<ICalculate>();

            calc.Add(wc);
            calc.Add(nc);

            foreach(var c in calc)
            {
                int ans = c.Add(2, 3);
            }
        }

        private void TestZoo_Click(object sender, EventArgs e)
        {
            var mo = new Monkey();
            mo.Name = "Rafiki";

            var li = new Lion();
            li.Name = "Simba";

            var el = new Elephant();
            el.Name = "Dombo";

            var Zoo = new List<Animal>();

            Zoo.Add(mo);
            Zoo.Add(li);
            Zoo.Add(el);

            foreach (Animal a in Zoo)
            {
                if (a is Monkey)
                {
                    a.Eat();
                }
            }

            foreach (Animal a in Zoo.OfType<Lion>())
            {
                a.Eat();
            }

            foreach (Animal a in Zoo)
            {
                var ollie = a as Elephant;

                if (ollie != null)
                    ollie.Eat();
            }

            dgvAnimals.DataSource = Zoo;

        }
    }
}
