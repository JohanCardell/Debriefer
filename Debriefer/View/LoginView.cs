using System;
using Debriefer.Control;
using Debriefer.Model;

namespace Debriefer.View
{
    public class LoginView
    {
        public Func<string,string, bool> ValidateLogin;
        //public Func<Player,Player> LoginSuccessCallback;
        public Action<String> LoginSuccessCallback;
        internal void Display()
        {
            Console.Clear();
            Console.Write("Type in your username: ");
            var username = Console.ReadLine();
            Console.Write("Enter password: ");
            var password = GetPassword();
            if (ValidateLogin(username, password) == false)
            {
                Console.WriteLine("\nInvalid Username or Password, press any key to continue;");
                Console.ReadKey(true);
                Display();
                return;
            }
            
            LoginSuccessCallback(username);
        }

        private string GetPassword()
        {
            string pass = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        return pass;
                    }
                }
            } while (true);
        }
    }
}