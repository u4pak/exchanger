using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;


namespace ShadyLauncher
{
    internal class LaunchUtil
    {
        public class LauncherBase
        {
            // this launch method is old and unused. all it did was launch with an exchange code you got from ak-47 lol.
            public static void OldLaunch()
            {
                Console.WriteLine("Please enter your exchange code. (Get it from AK-47)");
                string exchangeCode = Console.ReadLine();

                Console.WriteLine("\nPlease enter your User ID. (Get it from AK-47)");
                string userID = Console.ReadLine();

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = true;
                startInfo.WorkingDirectory = FortniteUtil.FortniteUtils.BinariesPath;
                startInfo.FileName = "FortniteLauncher.exe";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;

                // Epic Servers
                startInfo.Arguments = $"-AUTH_LOGIN=unused -AUTH_PASSWORD={exchangeCode} -AUTH_TYPE=exchangecode -epicapp=Fortnite -epicenv=Prod -EpicPortal -epicuserid={userID} -log";

                try
                {
                    using (Process exeProcess = Process.Start(startInfo))
                    {
                        exeProcess.WaitForExit();
                    }
                }
                catch
                {

                }
            }
        }
    }
}
