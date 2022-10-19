using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoD2WorldspawnConfigurator
{

    public class MapInfo
    {
        public string FileURL { get; set; }
        public string Name { get; set; }
        
        private Worldspawn worldspawn = new Worldspawn();
        public Worldspawn Worldspawn { get { return worldspawn; } set { worldspawn = value; } }

        public MapInfo()
        {
        }

        public MapInfo(string fileURL, string name, Worldspawn ws)
        {
            FileURL = fileURL;
            Name = name;
            Worldspawn = ws;
        }

        public void InsertWorldspawnValue(WorldspawnKeyVal val)
        {
            Worldspawn.InsertKeyVal(val);
        }
        public void InsertWorldspawnValue(string key, string value)
        {
            Worldspawn.InsertKeyVal(new WorldspawnKeyVal(key, value));
        }

        public void DeleteWorldspawnValue(string key)
        {
            Worldspawn.DeleteKeyVal(key);
        }

        public WorldspawnKeyVal GetWorldspawnValue(string key)
        {
            return Worldspawn.GetKeyVal(key);
        }
    }
}
