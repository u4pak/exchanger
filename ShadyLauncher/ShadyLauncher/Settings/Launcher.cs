using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadyLauncher.Settings
{
    internal class Launcher
    {
        public static void LauncherSettings()
        {
            Console.Clear();

            Console.Write(@"


                            ███████╗███████╗████████╗████████╗██╗███╗   ██╗ ██████╗ ███████╗
                            ██╔════╝██╔════╝╚══██╔══╝╚══██╔══╝██║████╗  ██║██╔════╝ ██╔════╝
                            ███████╗█████╗     ██║      ██║   ██║██╔██╗ ██║██║  ███╗███████╗
                            ╚════██║██╔══╝     ██║      ██║   ██║██║╚██╗██║██║   ██║╚════██║
                            ███████║███████╗   ██║      ██║   ██║██║ ╚████║╚██████╔╝███████║
                            ╚══════╝╚══════╝   ╚═╝      ╚═╝   ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚══════╝
                                                                

            ");

            Console.Write(@$"
                                         =====================================
                                         ||                                 ||
                                         ||    [1] Enable Startup Screen    ||
                                         ||                                 ||
                                         ||       [2] Custom EpicApp        ||
                                         ||                                 ||
                                         ||           [3] Go Back           ||
                                         ||                                 ||
                                         =====================================


                                                  Select an Option: ");

            var optionSelect = Console.ReadKey();

            if (optionSelect.Key == ConsoleKey.D1)
            {
                Console.Clear();

                Console.Write(@"


                            ███████╗███████╗████████╗████████╗██╗███╗   ██╗ ██████╗ ███████╗
                            ██╔════╝██╔════╝╚══██╔══╝╚══██╔══╝██║████╗  ██║██╔════╝ ██╔════╝
                            ███████╗█████╗     ██║      ██║   ██║██╔██╗ ██║██║  ███╗███████╗
                            ╚════██║██╔══╝     ██║      ██║   ██║██║╚██╗██║██║   ██║╚════██║
                            ███████║███████╗   ██║      ██║   ██║██║ ╚████║╚██████╔╝███████║
                            ╚══════╝╚══════╝   ╚═╝      ╚═╝   ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚══════╝
                                                                

            ");

                Console.Write(@"
                             Please enter your new value below (Ignore the weird formatting):
");

                var newValue = Console.ReadLine();

                
            }

            else if (optionSelect.Key == ConsoleKey.D2)
            {
                ShadyLauncher.Menu.Settings.SettingsMenu();
            }
            else if (optionSelect.Key == ConsoleKey.D3)
            {
                ShadyLauncher.Menu.Settings.SettingsMenu();
            }
            else
            {

            }
        }
    }
}
