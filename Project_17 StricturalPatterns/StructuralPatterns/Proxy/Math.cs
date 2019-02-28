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
    }
}
