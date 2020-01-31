using System;
using System.Collections.Generic;
using System.Text;

namespace Debriefer.View
{
    public class InfoMessageView
    {
        public string Message { get; set; }
        public Action Callback { get; set; }
        public void Display()
        {
            Console.Clear();
            Console.WriteLine(Message);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(false);
            Callback();
        }
    }
}
