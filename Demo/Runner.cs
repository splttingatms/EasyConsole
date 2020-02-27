using EasyConsole;
using System;

namespace Demo
{
    class Runner
    {
        static void Main(string[] args)
        {
            Settings.TitleColor = ConsoleColor.Blue;
            Settings.UserInputColor = ConsoleColor.Green;
            Settings.ShowSelectedEnumText = true;

            new DemoProgram().Run();
        }
    }
}
