using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoD2WorldspawnConfigurator
{
    internal class Direction
    {
        // Member Variables
        public int X
        {
            get { return X; }
            set
            {
                if (value < -360)
                    X = -360;
                else if (value > 360)
                    X = 360;
                else
                    X = value;
            }
        }
        public int Y
        {
            get { return Y; }
            set
            {
                if (value < -360)
                    Y = -360;
                else if (value > 360)
                    Y = 360;
                else
                    Y = value;
            }
        }
        public int Z
        {
            get { return 0; }
            set
            {
                Z = 0;
            }
        }

        public Direction(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $@"{X} {Y} {Z}";
        }
    }
}
