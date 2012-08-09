using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridDaemon
{
    public static   class ConsoleHelper
    {
        public static void Show(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public static void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
