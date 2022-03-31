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
using System.Configuration;
using System.Collections.Specialized;
using System.IO;
using System.Collections;

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

Console.SetWindowSize(120, 30);


Console.CursorVisible = false;

Console.Title = "Exchanger | Created by shady#9999";

ShadyLauncher.FileManager.ConfigManager.CheckConfig();

Console.WriteLine(@"



   





                       ███████╗██╗  ██╗ ██████╗██╗  ██╗ █████╗ ███╗   ██╗ ██████╗ ███████╗██████╗ 
                       ██╔════╝╚██╗██╔╝██╔════╝██║  ██║██╔══██╗████╗  ██║██╔════╝ ██╔════╝██╔══██╗
                       █████╗   ╚███╔╝ ██║     ███████║███████║██╔██╗ ██║██║  ███╗█████╗  ██████╔╝
                       ██╔══╝   ██╔██╗ ██║     ██╔══██║██╔══██║██║╚██╗██║██║   ██║██╔══╝  ██╔══██╗
                       ███████╗██╔╝ ██╗╚██████╗██║  ██║██║  ██║██║ ╚████║╚██████╔╝███████╗██║  ██║
                       ╚══════╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝
                                                                          
                             An minimalistic alternative to EGL for all Fortnite players.
");

System.Threading.Thread.Sleep(2000);

ShadyLauncher.Menu.MainMenu.FirstMenu();

