using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoD2WorldspawnConfigurator
{
    internal class Worldspawn
    {
        // Member Variables
        private List<WorldspawnKeyVal> worldspawnKeyVals = new List<WorldspawnKeyVal>();

        // Functions
        public Worldspawn(List<WorldspawnKeyVal> keyVals)
        {
            worldspawnKeyVals = keyVals;
        }
        public Worldspawn()
        {

        }

        /// <summary>
        /// Adds a new key and value to the worldspawn, overwriting a pair if key is duplicate.
        /// </summary>
        /// <param name="keyVal"></param>
        /// <returns>True if successful, false if not</returns>
        public bool InsertKeyVal(WorldspawnKeyVal keyVal)
        {
            WorldspawnKeyVal foundKV = null;
            foreach(WorldspawnKeyVal kv in worldspawnKeyVals)
            {
                if (keyVal.Key == kv.Key)
                {
                    foundKV = kv;
                    break;
                }
            }

            if(foundKV != null)
                worldspawnKeyVals.Remove(foundKV);

            worldspawnKeyVals.Add(keyVal);
            return true;
        }

        public void ClearKeyVals()
        {
            worldspawnKeyVals.Clear();
        }

        public void AddKeyValRange(IEnumerable<WorldspawnKeyVal> keyVals)
        {
            foreach(WorldspawnKeyVal v in keyVals)
            {
                InsertKeyVal(v);
            }
        }

        public bool DeleteKeyVal(string keyToDel)
        {
            WorldspawnKeyVal foundKV = null;

            foreach (WorldspawnKeyVal kv in worldspawnKeyVals)
            {
                if (keyToDel == kv.Key)
                {
                    foundKV = kv;
                    break;
                }
            }

            return worldspawnKeyVals.Remove(foundKV);
        }

        public WorldspawnKeyVal GetKeyVal(string key)
        {
            string keyLower = key.ToLower();
            foreach (WorldspawnKeyVal kv in worldspawnKeyVals)
            {
                if (keyLower == kv.Key) return kv;
            }

            // return a default value for each key, should it not exist
            if (keyLower == "suncolor" || keyLower == "sundiffusecolor" || keyLower == "_color" || keyLower == "sundirection")
                return new WorldspawnKeyVal(keyLower, "0 0 0");
            else if (keyLower == "classname") 
                return new WorldspawnKeyVal(keyLower, "worldspawn");
            else
                return new WorldspawnKeyVal(keyLower, "0");
        }

        public bool DoesKeyValExist(string key)
        {
            foreach (WorldspawnKeyVal kv in worldspawnKeyVals)
            {
                if (key == kv.Key) return true;
            }
            return false;
        }

        public void SetWorldspawnKeyVals(IEnumerable<WorldspawnKeyVal> kvs)
        {
            ClearKeyVals();
            worldspawnKeyVals = (List<WorldspawnKeyVal>)kvs;
        }

        public int Count()
        {
            return worldspawnKeyVals.Count();
        }

        public List<WorldspawnKeyVal> GetWorldspawnKeyVals()
        {
            return worldspawnKeyVals;
        }    
    }
}
