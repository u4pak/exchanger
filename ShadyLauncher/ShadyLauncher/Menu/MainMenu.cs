using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;
using System.Diagnostics;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using RestSharp;

namespace ShadyLauncher.Menu
{
    internal class MainMenu
    {
        private static string HideText()
        {
            StringBuilder input = new StringBuilder();
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) break;
                if (key.Key == ConsoleKey.Backspace && input.Length > 0) input.Remove(input.Length - 1, 1);
                else if (key.Key != ConsoleKey.Backspace) input.Append(key.KeyChar);
            }
            return input.ToString();
        }

        public static void LoginMenu()
        {
            Console.Clear();

            Console.Write(@"

                       ███████╗██╗  ██╗ ██████╗██╗  ██╗ █████╗ ███╗   ██╗ ██████╗ ███████╗██████╗ 
                       ██╔════╝╚██╗██╔╝██╔════╝██║  ██║██╔══██╗████╗  ██║██╔════╝ ██╔════╝██╔══██╗
                       █████╗   ╚███╔╝ ██║     ███████║███████║██╔██╗ ██║██║  ███╗█████╗  ██████╔╝
                       ██╔══╝   ██╔██╗ ██║     ██╔══██║██╔══██║██║╚██╗██║██║   ██║██╔══╝  ██╔══██╗
                       ███████╗██╔╝ ██╗╚██████╗██║  ██║██║  ██║██║ ╚████║╚██████╔╝███████╗██║  ██║
                       ╚══════╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝

            ");

            Console.CursorVisible = true;

            Console.Write(@"
                                                Open auth page? (Y/N): ");


            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                var getAuthCode = new ProcessStartInfo
                {
                    FileName = "https://www.epicgames.com/id/api/redirect?clientId=34a02cf8f4414e29b15921876da36f9a&responseType=code",
                    UseShellExecute = true
                };
                Process.Start(getAuthCode);

            }

            Console.Clear();

            Console.Write(@"

                       ███████╗██╗  ██╗ ██████╗██╗  ██╗ █████╗ ███╗   ██╗ ██████╗ ███████╗██████╗ 
                       ██╔════╝╚██╗██╔╝██╔════╝██║  ██║██╔══██╗████╗  ██║██╔════╝ ██╔════╝██╔══██╗
                       █████╗   ╚███╔╝ ██║     ███████║███████║██╔██╗ ██║██║  ███╗█████╗  ██████╔╝
                       ██╔══╝   ██╔██╗ ██║     ██╔══██║██╔══██║██║╚██╗██║██║   ██║██╔══╝  ██╔══██╗
                       ███████╗██╔╝ ██╗╚██████╗██║  ██║██║  ██║██║ ╚████║╚██████╔╝███████╗██║  ██║
                       ╚══════╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝

            ");

            Console.WriteLine(@"
                Please enter your auth code below and press enter. (Any entered text will be invisible):");

            Console.CursorVisible = false;

            string authCode = HideText();

            Console.Clear();

            Console.Write(@"

                       ███████╗██╗  ██╗ ██████╗██╗  ██╗ █████╗ ███╗   ██╗ ██████╗ ███████╗██████╗ 
                       ██╔════╝╚██╗██╔╝██╔════╝██║  ██║██╔══██╗████╗  ██║██╔════╝ ██╔════╝██╔══██╗
                       █████╗   ╚███╔╝ ██║     ███████║███████║██╔██╗ ██║██║  ███╗█████╗  ██████╔╝
                       ██╔══╝   ██╔██╗ ██║     ██╔══██║██╔══██║██║╚██╗██║██║   ██║██╔══╝  ██╔══██╗
                       ███████╗██╔╝ ██╗╚██████╗██║  ██║██║  ██║██║ ╚████║╚██████╔╝███████╗██║  ██║
                       ╚══════╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝


                                                   Launching Game...


");

            // Get auth token
            var authClient = new RestClient("https://account-public-service-prod.ol.epicgames.com/account/api/oauth/token");
            var authRequest = new RestRequest(Method.POST);
            authRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            authRequest.AddHeader("Authorization", "Basic MzRhMDJjZjhmNDQxNGUyOWIxNTkyMTg3NmRhMzZmOWE6ZGFhZmJjY2M3Mzc3NDUwMzlkZmZlNTNkOTRmYzc2Y2Y=");
            authRequest.AddParameter("grant_type", "authorization_code");
            authRequest.AddParameter("code", authCode);
            IRestResponse authResponse = authClient.Execute(authRequest);


            var authObj = JsonConvert.DeserializeObject<dynamic>(authResponse.Content);

            // Get exchange code
            var exchangeClient = new RestClient("https://account-public-service-prod.ol.epicgames.com/account/api/oauth/exchange");
            var exchangeRequest = new RestRequest(Method.GET);
            exchangeRequest.AddHeader("Authorization", "Bearer " + authObj?.access_token);
            IRestResponse exchangeResponse = exchangeClient.Execute(exchangeRequest);

            var exchangeObj = JsonConvert.DeserializeObject<dynamic>(exchangeResponse.Content);

            // Launch Fortnite
            ProcessStartInfo gameInfo = new ProcessStartInfo();
            gameInfo.CreateNoWindow = true;
            gameInfo.UseShellExecute = true;
            gameInfo.WorkingDirectory = ShadyLauncher.FortniteUtil.FortniteUtils.BinariesPath;
            gameInfo.FileName = "FortniteLauncher.exe";
            gameInfo.WindowStyle = ProcessWindowStyle.Hidden;

            // Epic Servers
            gameInfo.Arguments = $"-AUTH_LOGIN=unused -AUTH_PASSWORD={exchangeObj?.code} -AUTH_TYPE=exchangecode -epicapp=Fortnite -epicenv=Prod -EpicPortal -epicuserid={authObj?.account_id}";

            // World Cup Servers
            //gameInfo.Arguments = $"-epicapp=FortniteEvents -skippatchcheck -useallavailablecores -AUTH_LOGIN=unused -AUTH_PASSWORD={exchangeCode} -AUTH_TYPE=exchangecode -epicenv=Prod -EpicPortal -epicuserid={userID} -fromfl=be -fltoken=7d05d6869798a086b4bb6222";

            try
            {
                using (Process gameProcess = Process.Start(gameInfo))
                {
                    gameProcess?.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oh no, something went wrong. " + ex.ToString());
            }
        }
    }
}
