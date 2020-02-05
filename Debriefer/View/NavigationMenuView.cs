using System;
using System.Collections.Generic;
using System.Text;

namespace Debriefer.View
{
    public class NavigationMenuView
    {
        public string Message { get; set; }
        public List<NavigationMenuItemView> MenuItems { get; set; }
        public void Display()
        {
            Console.Clear();
            Console.WriteLine(Message);
            for (int i = 0; i < MenuItems.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] - {MenuItems[i].Title}");
            }
            while (true)
            {
                if (int.TryParse(Console.ReadKey(false).KeyChar.ToString(), out int choice) && choice <= MenuItems.Count)
                {
                    Console.WriteLine("Loading...");
                    Console.Clear();
                    MenuItems[choice - 1].GoTo();
                    break;
                }
            }
        }
    }
}
