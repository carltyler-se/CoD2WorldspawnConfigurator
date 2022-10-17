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

        // TODO: WORLDSPAWN DOESNT LOAD WHEN SELECTING IN LISTBOX
        //       POSSIBLY DOWN TO MAPSOURCEFOLDER 

        public static void SetMapSourceFolder(string path)
        {
            mapSourceFolder = path;
            if (!mapSourceFolder.EndsWith("\\")) { mapSourceFolder += "\\"; }
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

                        //"northyaw" "90"

                        currentLine = currentLine.Replace("\"", string.Empty);

                        //northyaw 90

                        string[] splitLine = currentLine.Split(new char[] {' '}, 2, System.StringSplitOptions.None);
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

            int worldspawnStartIndex = 0;
            int worldspawnLastIndex = 0;
            for (int i = 0; i < allLines.Count; i++)
            {
                if (allLines[i] == $@"// entity 0")
                {
                    i += 1;
                }

            }
            // ---------------------

            // Write lines back to file
            try
            {
                using (StreamWriter writer = new StreamWriter(mapSourceFolder + mapName + mapExtension))
                {
                    foreach(string line in allLines)
                    {
                        writer.WriteLine(line);
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
