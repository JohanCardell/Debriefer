using System;
using System.Collections.Generic;
using System.Text;

namespace Debriefer.View
{
    public class Menu
    {
        public string MainMenuItems =
                    "1. Add new content\n" +
                    "2. View content";

        public string SubMenuItems =
                    "1. Player\n" +
                    "2. Force\n" +
                    "3. Report\n" +
                    "4. Scenario\n";


        public Menu()
        {

        }

        public void MainMenu()
        {
            Console.Write(MainMenuItems);

            var input = Console.ReadKey().KeyChar;

            Console.Clear();

            switch (input)
            {
                case '1':
                    Console.Write(SubMenuItems);
                    break;
                default:
                    break;
            }

        }


    }
}
