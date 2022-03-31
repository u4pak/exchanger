using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadyLauncher.FileManager
{
    internal class ConfigManager
    {
        public static void CheckConfig()
        {
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string confDir = (appdata + "\\Exchanger");

            string confFile = (confDir + "\\Config.exch");

            if (!Directory.Exists(confDir))
            {
                DirectoryInfo createConfDir = Directory.CreateDirectory(confDir);
            }

            if (!File.Exists(confFile))
            {
                try
                {
                    using (FileStream createConf = File.Create(confFile))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(@"[EXCHANGER CONFIG FILE]
[ONLY EDIT THESE VALUES IF YOU KNOW WHAT YOU ARE DOING]

EnableStartupScreen = 1
ExtremePancakeCooking = 0");

                        createConf.Write(info, 0, info.Length);
                    }
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }


        public static void ReadConfig(string paramName)
        {

        }


        public static void WriteConfig(string value, int line)
        {

            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string confDir = (appdata + "\\Exchanger\\Config.exch");

            string[] arrLine = File.ReadAllLines(confDir);
            arrLine[line - 1] = value;
            File.WriteAllLines(confDir, arrLine);
        }
    }
}
