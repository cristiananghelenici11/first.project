using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class Math : IMath
    {
        public double Sqrt(double x) => System.Math.Sqrt(x);

        public double Add(double x, double y) => x + y;

        public double Div(double x, double y) => x / y;

        public double Mul(double x, double y) => x * y;

        public double Pow(double x, double y) => System.Math.Pow(x, y);

        public double Sub(double x, double y) => x - y;
<<<<<<< HEAD

        public double AddMultiple(double x, double y, double z) => x * y * z;
=======
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
    }
}
