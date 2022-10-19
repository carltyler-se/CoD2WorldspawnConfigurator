using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoD2WorldspawnConfigurator
{
    public static class WorldspawnDescription
    {
        public static string Classname { get { return "What the engine looks for when finding lighting settings during compile. Should not be changed"; } }
        public static string Northyaw { get { return "Value, in degrees, where north would point, relative to the maps default orientation.\nRange: -359 - 359";  } }
        public static string Ambient { get { return "Amount of ambient light is added to the map. Higher values will brighten places where there is no direct light.\nRange: 0 - 1"; } }
        public static string DiffuseFraction { get { return "This is the brightness of the indirect light source. A value of 1 will prevent light bouncing from reflective surfaces.\nRange: 0 - 1"; } }
        public static string Color { get { return "The color of the ambient light. Each value applies to the Red, Green and Blue RGB values, normalised to 1.\nRange: 0 - 1"; } }
        public static string SunColor { get { return "The color of the sunlight. Each value applies to the Red, Green and Blue RGB values, normalised to 1.\nRange: 0 - 1"; } }
        public static string SunDiffuseColor { get { return "The color of the indirect light. Each value applies to the Red, Green and Blue RGB values, normalised to 1.\nRange: 0 - 1"; } }
        public static string Sunlight { get { return "The intensity of the sunlight. Values over 1 will be overbright\nRange: 0 - 2"; } }
        public static string SunDirection { get { return "Represents the X (North-South), Y (Vertical) and Z axis. Z axis is unused as per the official documentation.\nRange: -359 - 359"; } }
        public static string ContrastGain { get { return "Unknown for now. Will be updated when available."; } }
        public static string BounceFraction { get { return "The intensity of the Global Illumination calculation. Higher numbers mean faltter shading where light is present.\nRange: 0 - 1"; } }
    }

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
            if (worldspawnKeyVals == null) return 0;
            return worldspawnKeyVals.Count();
        }

        public List<WorldspawnKeyVal> GetWorldspawnKeyVals()
        {
            return worldspawnKeyVals;
        }    
    }
}
