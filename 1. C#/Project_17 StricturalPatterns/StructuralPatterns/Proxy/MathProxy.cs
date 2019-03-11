using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class MathProxy : IMath
    {
        private readonly Math _math = new Math();
        public double Pow(double x, double y)
        {
            return _math.Pow(x, y);
        }

        public double Add(double x, double y)
        {
            return _math.Add(x, y);
        }
        public double Div(double x, double y)
        {
            return _math.Div(x, y);
        }

        public double Mul(double x, double y) 
        {
            return _math.Mul(x, y);
        }

        public double Sqrt(double x) 
        {
            return _math.Sqrt(x);
        }

        public double Sub(double x, double y) 
        {
            return _math.Sub(x, y);
        }

    }
}
