using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relation
{
    class Vehicle
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
        }

        public void Stop()
        {
            Plug(false, true);
        }

        private void CheckFuel()
        {
            //
        }

        private void CheckBattery()
        {

        }

        private void Plug(bool start, bool stop)
        {

        }

    }


}
