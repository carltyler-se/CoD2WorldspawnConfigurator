using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoD2WorldspawnConfigurator
{
    public class WorldspawnKeyVal
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public WorldspawnKeyVal(string key, string val)
        {
            Key = key;
            Value = val;
        }
        public override string ToString()
        {
            return "\"" + Key + "\"" + " " + "\"" + Value + "\"";
        }
    }
}
