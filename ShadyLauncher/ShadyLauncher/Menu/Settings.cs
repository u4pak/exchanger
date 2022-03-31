using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadyLauncher.Menu
{
    internal class Settings
    {
        public static void SettingsMenu()
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
                                             =============================
                                             ||                         ||
                                             ||      [1] Launcher       ||
                                             ||                         ||
                                             ||        [2] Misc         ||
                                             ||                         ||
                                             ||    [3] Exit to Menu     ||
                                             ||                         ||
                                             =============================


                                                  Select an Option: ");

            var optionSelect = Console.ReadKey();

            if (optionSelect.Key == ConsoleKey.D1)
            {
                ShadyLauncher.Settings.Launcher.LauncherSettings();
            }
            else if (optionSelect.Key == ConsoleKey.D2)
            {
                SettingsMenu();
            }
            else if (optionSelect.Key == ConsoleKey.D3)
            {
                MainMenu.FirstMenu();
            }
            else
            {

            }
        }
    }
}
