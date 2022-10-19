using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoD2WorldspawnConfigurator
{
    public static class Utils
    {
        public static string GetMapNameFromURL(string fullURL)
        {
            string[] splits = fullURL.Split('\\');
            return splits[splits.Length - 1];
        }

        public static Worldspawn ParseWorldspawnString(string worldspawnString)
        {
            Worldspawn ws = new Worldspawn();

            /* 
             {
                "northyaw" "90"
                "_color" "1 .95 .95"
                "ambient" "0.05"
                "sundiffusecolor" "0.80 0.82 0.85"
                "diffusefraction" "0.31"
                "classname" "worldspawn"
                "sundirection" "-137.8 305 0"
                "suncolor" "0.9 0.95 1"
                "sunlight" "1.5"
            }
            */

            // TODO:
            // remove all whitespace
            // replace { and } with String.Empty
            // replace "" with single space
            // replace " with string.Empty

            return ws;
        }
    }
}
