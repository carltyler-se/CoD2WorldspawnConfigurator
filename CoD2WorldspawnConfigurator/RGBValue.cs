using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoD2WorldspawnConfigurator
{
    internal class RGBValue
    {
        // Member Variables
        public int R 
        { 
            get { return R; } 
            set
            {
                if (value < 0) 
                    R = 0;
                else if (value > 256) 
                    R = 256;
                else 
                    R = value;
            }
        }
        public int G 
        {
            get { return G; }
            set
            {
                if (value < 0)
                    G = 0;
                else if (value > 256)
                    G = 256;
                else
                    G = value;
            }
        }
        public int B
        {
            get { return B; }
            set
            {
                if (value < 0)
                    B = 0;
                else if (value > 256)
                    B = 256;
                else
                    B = value;
            }
        }

        //Contructors
        RGBValue() { R = 0; G = 0; B = 0; }
        RGBValue(int r, int g, int b) { R = r; G = g; B = b; }

        public override string ToString()
        {
            return $@"{R} {G} {B}";
        }
    }
}
