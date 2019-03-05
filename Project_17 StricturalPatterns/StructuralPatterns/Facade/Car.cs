using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facade
{
    public class Car
    {
        private readonly string _mark;
<<<<<<< HEAD
        private readonly Engine _engine;
        private readonly Gearbox _gearBox ;

        public Car(string mark, Engine engine, Gearbox gearBox)
        {
            _engine = engine;
            _gearBox = gearBox;
            _mark = mark;
        }
=======

        public Car(string mark)
        {
            _mark = mark;
        }
 
        private readonly Engine _engine = new Engine();
        private readonly Gearbox _gearBox = new Gearbox();
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355

        public void Start()
        {
           _engine.Start();
           _gearBox.SetOnDrive();
           Console.WriteLine($"Start {_mark} ...\n");
           Thread.Sleep(2000);
        }

        public void Stop()
        {
            _gearBox.SetOnParking();
            _engine.Stop();
            Console.WriteLine($"Stop {_mark}");
        }
    }
}
