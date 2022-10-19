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
    }
}
