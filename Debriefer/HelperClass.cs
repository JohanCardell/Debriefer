using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers

{
    static public class Input
    {
        static public int GetDigit()
        {
            return int.Parse(Console.ReadKey(false).KeyChar.ToString());
        }
    }
}
