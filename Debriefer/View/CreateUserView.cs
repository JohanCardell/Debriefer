using System;

namespace Debriefer.View
{
    class NewUserDataScreen
    {

        public Action<string, string, bool> UserInputCallback;

        internal void Display()
        {
            Console.Write("Enter user name: ");
            var name = Console.ReadLine();
            Console.Write("Enter password: ");
            var password = Console.ReadLine();
            Console.Write("Give admin rights? y/n: ");
            bool admin = false;
            if (Console.Read().ToString().Equals("y")) admin = true;
            Console.Clear();
            UserInputCallback(name, password, admin);
        }
    }
}
