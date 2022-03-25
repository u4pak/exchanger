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

/*

Welcome to Exchanger!

Exchanger is a simple program that allows you to
launch Fortnite with an authentication code instead
of using EGL.

ATM, Exchanger has very little features, but I plan
in the future to add way more features, such as saving
multiple accounts and managing your FN account directly
from the program.

If you use any of my code, please make sure to credit
me and leave your program open sourced!

- shady#9999

(P.S: Don't make fun of my messy code, I'm normally a
Python guy, and Python doesn't use classes lol.)

*/

Console.Title = "Exchanger | Created by shady#9999";

Console.WriteLine(@"
███████╗██╗  ██╗ ██████╗██╗  ██╗ █████╗ ███╗   ██╗ ██████╗ ███████╗██████╗ 
██╔════╝╚██╗██╔╝██╔════╝██║  ██║██╔══██╗████╗  ██║██╔════╝ ██╔════╝██╔══██╗
█████╗   ╚███╔╝ ██║     ███████║███████║██╔██╗ ██║██║  ███╗█████╗  ██████╔╝
██╔══╝   ██╔██╗ ██║     ██╔══██║██╔══██║██║╚██╗██║██║   ██║██╔══╝  ██╔══██╗
███████╗██╔╝ ██╗╚██████╗██║  ██║██║  ██║██║ ╚████║╚██████╔╝███████╗██║  ██║
╚══════╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝
                                                                           
An minimalistic alternative to EGL for all Fortnite players.
");

Console.WriteLine("Open auth page? (Y/N):");

string authOpenYN = Console.ReadLine();

if (authOpenYN == "y")
{
    var psi = new ProcessStartInfo
    {
        FileName = "https://www.epicgames.com/id/api/redirect?clientId=34a02cf8f4414e29b15921876da36f9a&responseType=code",
        UseShellExecute = true
    };
    Process.Start(psi);
}
if (authOpenYN == "Y")
{
    var psi = new ProcessStartInfo
    {
        FileName = "https://www.epicgames.com/id/api/redirect?clientId=34a02cf8f4414e29b15921876da36f9a&responseType=code",
        UseShellExecute = true
    };
    Process.Start(psi);
}

Console.WriteLine("\nPlease enter your auth code:");
string authCode = Console.ReadLine();

// get auth token
var authClient = new RestClient("https://account-public-service-prod.ol.epicgames.com/account/api/oauth/token");
var authRequest = new RestRequest(Method.POST);
authRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
authRequest.AddHeader("Authorization", "Basic MzRhMDJjZjhmNDQxNGUyOWIxNTkyMTg3NmRhMzZmOWE6ZGFhZmJjY2M3Mzc3NDUwMzlkZmZlNTNkOTRmYzc2Y2Y=");
authRequest.AddParameter("grant_type", "authorization_code");
authRequest.AddParameter("code", authCode);
IRestResponse authResponse = authClient.Execute(authRequest);

var authObj = JsonConvert.DeserializeObject<dynamic>(authResponse.Content);

//Console.WriteLine(authObj);

// get exchange code
var exchangeClient = new RestClient("https://account-public-service-prod.ol.epicgames.com/account/api/oauth/exchange");
var exchangeRequest = new RestRequest(Method.GET);
exchangeRequest.AddHeader("Authorization", "Bearer " + authObj.access_token);
IRestResponse exchangeResponse = exchangeClient.Execute(exchangeRequest);

var exchangeObj = JsonConvert.DeserializeObject<dynamic>(exchangeResponse.Content);

//Console.WriteLine("\n" + exchangeObj);

// launch fn
ProcessStartInfo startInfo = new ProcessStartInfo();
startInfo.CreateNoWindow = true;
startInfo.UseShellExecute = true;
startInfo.WorkingDirectory = ShadyLauncher.FortniteUtil.FortniteUtils.BinariesPath;
startInfo.FileName = "FortniteLauncher.exe";
startInfo.WindowStyle = ProcessWindowStyle.Hidden;

// Epic Servers
startInfo.Arguments = $"-AUTH_LOGIN=unused -AUTH_PASSWORD={exchangeObj.code} -AUTH_TYPE=exchangecode -epicapp=Fortnite -epicenv=Prod -EpicPortal -epicuserid={authObj.account_id}";

// World Cup Servers
//startInfo.Arguments = $"-epicapp=FortniteEvents -skippatchcheck -useallavailablecores -AUTH_LOGIN=unused -AUTH_PASSWORD={exchangeCode} -AUTH_TYPE=exchangecode -epicenv=Prod -EpicPortal -epicuserid={userID} -fromfl=be -fltoken=7d05d6869798a086b4bb6222";
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

//ShadyLauncher.LaunchUtil.LauncherBase.Launch();

//Console.WriteLine(ShadyLauncher.FortniteUtil.FortniteUtils.BinariesPath);