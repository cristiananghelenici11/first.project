using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relation
{
    internal class Vehicle
    {
        public double Speed { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        // compozitia
        private Fuel _fuel;
        private Engine _engine;
        public Vehicle()
        {
            _fuel = new Fuel();
            _engine = new Engine();
        }
       
        
        public void Move()
        {
            CheckFuel();
            CheckBattery();
            Plug(true, false);
            Console.WriteLine("Move Vehicle");
        }

        public void Stop()
        {
            Plug(false, true);
        }

        private void CheckFuel()
        {
            Console.WriteLine("Check Fuel");
        }

        private void CheckBattery()
        {
            Console.WriteLine("Check battery");
        }

        private void Plug(bool start, bool stop)
        {
            if (start)
            {
                Console.WriteLine("Start engine");
            }
            else
            {
                Console.WriteLine("Stop Engine");
            }
        }

    }

    struct MyStruct
    {
        private int n;
        MyStruct(int n)
        {
            this.n = n;
        }
    }

}
