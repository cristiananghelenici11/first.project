using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overload
{
    class Angle
    {
        private int _degrees;

        public int Degrees
        {
            get => _degrees;
            private set => _degrees = value % 360;
        }

        private int _minutes;

        public int Minutes
        {
            get => _minutes;
            private set
            {
                _minutes = value % 60;
                Degrees = value / 60;
            }
        }

        private int _seconds;

        public int Seconds
        {
            get => _seconds;
            private set
            {
                _seconds = value % 60;
                Minutes = value / 60;
            }
        }

        public Angle(int seconds) : this(0, 0,seconds)
        {
        }

        public Angle(int minutes, int seconds) : this(0, minutes, seconds)
        {
        }

        public Angle(int degrees, int minutes, int seconds)
        {
            int value = (degrees * 60 + minutes) * 60 + seconds;
            Seconds = value;
        }


        public Angle()
        {

        }

        public static Angle operator +(Angle angle1, Angle angle2)
        {
            return new Angle{Seconds = ToSeconds(angle1) + ToSeconds(angle2)};
        }

        public static Angle operator -(Angle angle1, Angle angle2)
        {
            return new Angle{Seconds = ToSeconds(angle1) - ToSeconds(angle2)};
        }

        public static Angle operator *(Angle angle1, Angle angle2)
        {
            return new Angle(ToSeconds(angle1) * ToSeconds(angle2));
        }

        public static Angle operator /(Angle angle1, Angle angle2)
        {
            return new Angle{Seconds = ToSeconds(angle1) / ToSeconds(angle2)};
        }

        public static bool operator ==(Angle angle1, Angle angle2)
        {
            return ToSeconds(angle1).Equals(ToSeconds(angle2));
        }        
        public static bool operator !=(Angle angle1, Angle angle2)
        {
            return !ToSeconds(angle1).Equals(ToSeconds(angle2));
        }

        public static int ToSeconds(Angle angle)
        {
            return (angle.Degrees * 60 + angle.Minutes) * 60 + angle.Seconds;
        }

        public override string ToString()
        {
            return $"{Degrees}, {Minutes}', {Seconds}''";
        }

        public int this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return Seconds;
                    case 1:
                        return Minutes;
                    case 2:
                        return Degrees;
                   default:
                       throw new IndexOutOfRangeException("Index Out Of Range Exception " + i);
                }
            }
            set
            {
                switch (i)
                {
                    case 0:
                        Seconds = value;
                        break;
                    case 1:
                        Minutes = value;
                        break;
                    case 2:
                        Degrees = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Index Out Of Range Exception " + i);
                }
            }
        } 
        public int this[string str]
        {
            get
            {
                switch (str)
                {
                    case "seconds":
                        return Seconds;
                    case "minutes":
                        return Minutes;
                    case "degrees":
                        return Degrees;
                   default:
                       throw new IndexOutOfRangeException("Index Out Of Range Exception " + str);
                }
            }
            set
            {
                switch (str)
                {
                    case "seconds":
                        Seconds = value;
                        break;
                    case "minutes":
                        Minutes = value;
                        break;
                    case "degrees":
                        Degrees = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Index Out Of Range Exception " + str);
                }
            }
        }
    }
}
