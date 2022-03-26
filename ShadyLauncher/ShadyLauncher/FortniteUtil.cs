using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadyLauncher
{
    internal class FortniteUtil
    {
        public class InstallationList
        {
            [JsonProperty("InstallLocation")] public string? InstallLocation { get; set; }

            [JsonProperty("NamespaceId")] public string? NamespaceId { get; set; }

            [JsonProperty("ItemId")] public string? ItemId { get; set; }

            [JsonProperty("ArtifactId")] public string? ArtifactId { get; set; }

            [JsonProperty("AppVersion")] public string? AppVersion { get; set; }

            [JsonProperty("AppName")] public string? AppName { get; set; }
        }

        public class InstalledApps
        {
            [JsonProperty("InstallationList")] public List<InstallationList>? InstallationList { get; set; }
        }

        public class FortniteUtils
        {
            public static string BinariesPath
                => GetFortnitePath() + @"\FortniteGame\Binaries\Win64";

            public static string GetFortnitePath()
            {
                var path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                    "Epic\\UnrealEngineLauncher\\LauncherInstalled.dat");

                return !File.Exists(path)
                       ? null
                       : Newtonsoft.Json.JsonConvert.DeserializeObject<InstalledApps>(File.ReadAllText(path)).InstallationList
                                    .FirstOrDefault(x => x.AppName == "Fortnite").InstallLocation;
            }
        }
    }
}
