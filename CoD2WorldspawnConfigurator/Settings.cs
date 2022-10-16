using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoD2WorldspawnConfigurator
{
    /// <summary>
    /// MAKE SURE TO SET THE FILES LOCATION ON INIT
    /// </summary>
    static class Settings
    {
        private static string rootFolderLocation = "";
        private static string settingsFileLocation = "";
        public static string SettingsFileLocation 
        { 
            get 
            { 
                return settingsFileLocation; 
            } 
            set
            {
                settingsFileLocation = value;
            }

        }

        public static void SaveMapSourceLocationToFile(string newSourceLocation)
        {
            List<string> allSettings = GetAllSettingsStringsFromFile().ToList();
            int index = -1;
            for (int i = 0; i < allSettings.Count; i++)
            {
                if (allSettings[i].ToLower().StartsWith("mapsourcelocation"))
                {
                    index = i;
                    break;
                }
            }
            // if the mapsourcelocation was found, overwrite it
            if(index > -1)
                allSettings[index] = $@"mapsourcelocation={newSourceLocation}";
            // otheriwise, add it onto the end of the settings list
            else
                allSettings.Add($@"mapsourcelocation={newSourceLocation}");

            using (StreamWriter writer = new StreamWriter(SettingsFileLocation))
            {
                foreach(var setting in allSettings)
                {
                    writer.WriteLine(setting);
                }
            }
        }

        public static string GetMapSourceFolderUrl()
        {
            string[] settings = GetAllSettingsStringsFromFile();
            string mapSourceString = "";
            foreach(string s in settings)
            {
                if(s.ToLower().StartsWith("mapsourcelocation"))
                {
                    string[] splits = s.Split('=');
                    mapSourceString = splits[1];
                }
            }
            return mapSourceString;
        }

        private static string[] GetAllSettingsStringsFromFile()
        {
            List<string> lines = new List<string>();
            try
            {
                using (StreamReader reader = new StreamReader(SettingsFileLocation))
                {
                    while (!reader.EndOfStream)
                    {
                        lines.Add(reader.ReadLine());
                    }
                }
            }
            catch(Exception)
            {
                return lines.ToArray();

            }
            return lines.ToArray();
        }
    }
}
