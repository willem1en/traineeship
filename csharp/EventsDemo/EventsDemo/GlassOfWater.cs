using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDemo
{
    class GlassOfWater
    {
        private int _temperature = 20;

        public int Temperature {
            get { return _temperature; }
            set
            {
                _temperature = value;

                TemperatureChanged?.Invoke(this, DateTime.Now);

                if (value < 0)
                    Freezing?.Invoke(this, DateTime.Now);

                if (value > 100)
                    Boiling?.Invoke(this, DateTime.Now);

                if (value >= 0 && value < 100)
                    Normal?.Invoke(this, DateTime.Now);
            }
        }

        public event EventHandler<DateTime> TemperatureChanged;
        public event EventHandler<DateTime> Boiling;
        public event EventHandler<DateTime> Freezing;
        public event EventHandler<DateTime> Normal;


        public void Cool()
        {
            Temperature--;
        }

        public void Heat()
        {
            Temperature++;
        }

        public void SuperCool()
        {
            Temperature -= 10;
        }

        public void SuperHeat()
        {
            Temperature += 10;
        }
    }
}
