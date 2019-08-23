using System;
using System.Collections.Generic;
using System.Configuration;

namespace Parsing_Service.Model
{
    class Settings
    {
        //PARSER SETTINGS
        public static Dictionary<String, DateTime> PARSING_DIRECTORIES = new Dictionary<String, DateTime>();
        public static int PARSING_MODE = 1;
        public static List<String> FILTERS = new List<String>();
        public static String FILTER_STRING="";

        public const int MALFORMED_PLACHEHOLDER_NUMERIC = -1;
        public const String MALFORMED_FIELD_PLACEHOLDER_STRING = "Malformed";

        //INTERNAL SETTINGS TAGS FOR STORING CONF
        public const string SAVED_DIRECTORIES_TAG = "Directories";
        public const string SAVED_DATES_TAG = "Dates";
        public const string SAVED_MODE_TAG = "Mode";
        public const string SAVED_FILTERS_TAG = "Filters";

        public static void printCurrentSettingsFileDir()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            Console.WriteLine("Local user config path: {0}", config.FilePath);
        }

        public static void ReadAllSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings is empty.");
                }
                else
                {
                    String[] directories = appSettings[Settings.SAVED_DIRECTORIES_TAG].Split(';');
                    String[] dates = appSettings[Settings.SAVED_DATES_TAG].Split(';');


                    for (int i = 0; i < directories.Length; i++)
                    {
                        Console.WriteLine(directories[i] + "\n" + dates[i]);
                        if (directories[i].Length > 1)
                        {
                            Settings.PARSING_DIRECTORIES.Add(directories[i], DateTime.Parse(dates[i]));
                            Console.WriteLine(directories[i] + DateTime.Parse(dates[i]));
                        }

                    }

                    Settings.PARSING_MODE = Int32.Parse(appSettings[Settings.SAVED_MODE_TAG]);
                    Settings.FILTER_STRING = appSettings[Settings.SAVED_FILTERS_TAG];

                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }

        public static void ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                Console.WriteLine(result);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }

        public static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
        public static void saveAllSettings()
        {
            string toSaveDirs = "", toSaveLastParse = "";
            foreach (KeyValuePair<String, DateTime> entry in Settings.PARSING_DIRECTORIES)
            {
                toSaveDirs += entry.Key + ";";
                toSaveLastParse += entry.Value + ";";
            }

            AddUpdateAppSettings(Settings.SAVED_DIRECTORIES_TAG, toSaveDirs);
            AddUpdateAppSettings(Settings.SAVED_DATES_TAG, toSaveLastParse);
            AddUpdateAppSettings(Settings.SAVED_MODE_TAG, Settings.PARSING_MODE.ToString());
            AddUpdateAppSettings(Settings.SAVED_FILTERS_TAG, Settings.FILTER_STRING);
        }
    }
}
