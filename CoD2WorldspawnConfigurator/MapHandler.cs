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
            if (!mapSourceFolder.EndsWith("\\")) { mapSourceFolder += "\\"; }
        }

        public static string GetMapSourceFolder()
        {
            return mapSourceFolder;
        }

        public static bool MapExists(string mapName)
        {
            string fullMapUrl = $@"{mapSourceFolder}{mapName}";
            bool exists = File.Exists(fullMapUrl);
            return exists;
        }

        public static string[] GetAllMapNamesInFolder(string rootFolder)
        {
            if (rootFolder == null || rootFolder == "") return null;

            List<string> filteredNames = new List<string>();
            string[] names = Directory.GetFiles(rootFolder);
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].EndsWith(".map") || names[i].EndsWith(".map\\"))
                    filteredNames.Add(names[i]);
            }
            return filteredNames.ToArray();
        }

        //returns false if an error occurs
        public static List<WorldspawnKeyVal> GetWorldspawnSettings(string mapName)
        {
            if (!MapExists(mapName))
                return null;

            List<WorldspawnKeyVal> fetchedKeyVals = new List<WorldspawnKeyVal>();

            try
            {
                using (StreamReader reader = new StreamReader(mapSourceFolder + mapName))
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

                        fetchedKeyVals.Add(ParseLine(currentLine));
                    }
                }
            }
            catch(Exception)
            {
                return null;
            }

            return fetchedKeyVals;
        }

        private static WorldspawnKeyVal ParseLine(string line)
        {
            line = line.Replace("\"", string.Empty);

            //northyaw 90

            string[] splitLine = line.Split(new char[] { ' ' }, 2, System.StringSplitOptions.None);
            //northyaw ([0])
            //90 ([1])
            return new WorldspawnKeyVal(splitLine[0], splitLine[1]);
        }

        public static bool SaveWorldspawnSettings(string mapName, List<WorldspawnKeyVal> keyVals)
        {
            if (!MapExists(mapName))
                return false;

            List<string> allLines = new List<string>();
            List<WorldspawnKeyVal> isolatedKeyVals = new List<WorldspawnKeyVal>();

            string currentLine = "";

            // Store all lines currently in file

            try
            {
                using(StreamReader reader = new StreamReader(mapSourceFolder + mapName))
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

            int postWorldspawnIndex = 0;


            // Isolate worldspawn lines from allLines
            // Start at position 3 of the lines to skip first 3 lines of file
            // and loop until next line contains comments (eg. // brush 0)
            for (int i = 3; i < allLines.Count; i++)
            {
                if (allLines[i].StartsWith("//"))
                {
                    postWorldspawnIndex = i;
                    break;
                }
                isolatedKeyVals.Add(ParseLine(allLines[i]));
            }

            List<WorldspawnKeyVal> newKeyVals = new List<WorldspawnKeyVal>();

            foreach(WorldspawnKeyVal keyVal in keyVals)
            {
                bool kvFound = false;
                foreach(WorldspawnKeyVal isolatedKV in isolatedKeyVals)
                {
                    if(keyVal.Key == isolatedKV.Key)
                    {
                        isolatedKV.Value = keyVal.Value;
                        kvFound = true;
                        break;
                    }
                }
                if(!kvFound)
                {
                    newKeyVals.Add(keyVal);
                }
            }
            // Add the keyvals that did not already exist to the old ones
            isolatedKeyVals.AddRange(newKeyVals);


            // Write lines back to file
            try
            {
                using (StreamWriter writer = new StreamWriter(mapSourceFolder + mapName))
                {
                    //write the first 3 lines first
                    for(int i = 0; i < 3; i++)
                    {
                        writer.WriteLine(allLines[i]);
                    }
                    // write the worldspawns
                    foreach(WorldspawnKeyVal keyVal in isolatedKeyVals)
                    {
                        writer.WriteLine(keyVal.ToString());
                    }
                    // write the remaining lines
                    for(int i = postWorldspawnIndex; i < allLines.Count; i++)
                    {
                        writer.WriteLine(allLines[i]);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Returns null if getting info was unsuccessful
        /// </summary>
        /// <param name="fullURL"></param>
        /// <returns></returns>
        public static MapInfo GetMapInfo(string fullURL)
        {
            if (!File.Exists(fullURL)) return null;
            if (!fullURL.EndsWith(".map")) return null;

            // Isolate the maps name
            string mapName = "";
            string[] urlSections = fullURL.Split('\\');

            if (urlSections.Length > 1)
                mapName = urlSections[urlSections.Length - 1];
            else
                return null;

            // package mapinfo with things
            MapInfo mapInfo = new MapInfo();
            mapInfo.Name = mapName;
            mapInfo.Worldspawn.SetWorldspawnKeyVals(GetWorldspawnSettings(mapName));

            return mapInfo;
        }
    }
}
