using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoD2WorldspawnConfigurator
{

    internal class MapInfo
    {
        public string FileURL { get; set; }
        public string Name { get; set; }
        private List<WorldspawnKeyVal> worldspawnKeyVals;
        public List<WorldspawnKeyVal> WorldspawnKeyVals { get { return worldspawnKeyVals; } set { worldspawnKeyVals = value; } }
        public Worldspawn Worldspawn { get; set; }

        public MapInfo()
        {
            WorldspawnKeyVals = new List<WorldspawnKeyVal>();
        }

        public MapInfo(string fileURL)
        {
            FileURL = fileURL;
            WorldspawnKeyVals = new List<WorldspawnKeyVal>();
        }

        private void LoadMapFile()
        {
            // use FileURL to get the map name and the current worldspawn settings if any
        }

        public void InsertWorldspawnValue(WorldspawnKeyVal val)
        {
            bool keyValExists = false;
            foreach(WorldspawnKeyVal x in WorldspawnKeyVals)
            {
                if (x.Key == val.Key)
                {
                    keyValExists = true;
                    x.Key = val.Key;
                }
                break;
            }
            if(!keyValExists)               
                WorldspawnKeyVals.Add(val);
        }

        public void DeleteWorldspawnValue(string key)
        {
            WorldspawnKeyVal foundKeyVal = null;
            foreach (WorldspawnKeyVal x in WorldspawnKeyVals)
            {
                if (x.Key == key)
                {
                    foundKeyVal = x;
                }
                break;
            }
            if(foundKeyVal != null)
                WorldspawnKeyVals.Remove(foundKeyVal);
        }

        public WorldspawnKeyVal GetWorldspawnValue(string key)
        {
            foreach (WorldspawnKeyVal x in WorldspawnKeyVals)
            {
                if (x.Key == key)
                {
                    return x;
                }
            }
            return null;
        }


    }
}
