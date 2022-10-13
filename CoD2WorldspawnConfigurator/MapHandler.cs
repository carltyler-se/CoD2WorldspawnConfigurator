using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoD2WorldspawnConfigurator
{
    static class MapHandler
    {
        private static string mapSourceFolder = "";
        private static readonly string mapExtension = ".map";

        public static void SetMapSourceFolder(string path)
        {
            mapSourceFolder = path;
            if (!mapSourceFolder.EndsWith("/")) { mapSourceFolder += "/"; }
        }

        public static bool MapExists(string mapName)
        {
            return File.Exists($@"{mapSourceFolder}{mapName}{mapExtension}");
        }

        //returns false if an error occurs
        public static List<WorldspawnKeyVal> GetWorldspawnSettings(string mapName)
        {
            if (!mapName.StartsWith("mp_"))
                return null;
            if (!MapExists(mapName))
                return null;

            List<WorldspawnKeyVal> fetchedKeyVals = new List<WorldspawnKeyVal>();

            try
            {
                using (StreamReader reader = new StreamReader(mapSourceFolder + mapName + mapExtension))
                {
                    string currentLine = "";

                    // loop through to entity 0 (worldspawn)
                    while (true)
                    {
                        currentLine = reader.ReadLine();
                        if (currentLine == $@"// entity 0")
                            break;
                    }

                    //skips past the first {
                    reader.ReadLine();

                    while (true)
                    {
                        currentLine = reader.ReadLine();

                        if (currentLine.StartsWith($@"//")) break;

                        //"northyaw" "90"

                        currentLine = currentLine.Replace("\"", string.Empty);

                        //northyaw 90

                        string[] splitLine = currentLine.Split(' ');
                        //northyaw ([0])
                        //90 ([1])

                        fetchedKeyVals.Add(new WorldspawnKeyVal(splitLine[0], splitLine[1]));
                    }
                }
            }
            catch(Exception)
            {
                return null;
            }

            return fetchedKeyVals;
        }

        public static bool SaveWorldspawnSettings(string mapName, List<WorldspawnKeyVal> keyVals)
        {
            if (!mapName.StartsWith("mp_"))
                return false;
            if (!MapExists(mapName))
                return false;

            List<string> allLines = new List<string>();

            string currentLine = "";

            // Store all lines currently in file

            try
            {
                using(StreamReader reader = new StreamReader(mapSourceFolder + mapName + mapExtension))
                {
                    while (!reader.EndOfStream)
                    {
                        allLines.Add(reader.ReadLine()); 
                    }
                }
            }
            catch(Exception)
            {
                return false;
            }


            // ALTER WORLDSPAWN HERE

            // 

            // ---------------------

            // Write lines back to file
            try
            {
                using (StreamWriter writer = new StreamWriter(mapSourceFolder + mapName + mapExtension))
                {

                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
