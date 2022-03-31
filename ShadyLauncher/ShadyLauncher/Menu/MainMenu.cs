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
        public static void FirstMenu()
        {
            Console.Clear();

            Console.CursorVisible = true;

            Console.Write(@"





                       ███████╗██╗  ██╗ ██████╗██╗  ██╗ █████╗ ███╗   ██╗ ██████╗ ███████╗██████╗ 
                       ██╔════╝╚██╗██╔╝██╔════╝██║  ██║██╔══██╗████╗  ██║██╔════╝ ██╔════╝██╔══██╗
                       █████╗   ╚███╔╝ ██║     ███████║███████║██╔██╗ ██║██║  ███╗█████╗  ██████╔╝
                       ██╔══╝   ██╔██╗ ██║     ██╔══██║██╔══██║██║╚██╗██║██║   ██║██╔══╝  ██╔══██╗
                       ███████╗██╔╝ ██╗╚██████╗██║  ██║██║  ██║██║ ╚████║╚██████╔╝███████╗██║  ██║
                       ╚══════╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝

            ");

            Console.Write(@"
                                             =============================
                                             ||                         ||
                                             ||    [1] Main Launcher    ||
                                             ||                         ||
                                             ||      [2] Settings       ||
                                             ||                         ||
                                             =============================


                                                  Select an Option: ");

            var optionSelect = Console.ReadKey();

            if (optionSelect.Key == ConsoleKey.D1)
            {
                ShadyLauncher.Menu.Login.LoginMenu();
            }
            else if (optionSelect.Key == ConsoleKey.D2)
            {
                ShadyLauncher.Menu.Settings.SettingsMenu();
            }
        }
    }
}
