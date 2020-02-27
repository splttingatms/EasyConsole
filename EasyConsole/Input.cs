using System;

namespace EasyConsole
{
    public static class Input
    {

        enum YesNoEnum
        {
            Yes,
            No
        }

        public static string ReadLine()
        {
            Console.ForegroundColor = Settings.UserInputColor;
            var value = Console.ReadLine();
            Console.ResetColor();
            return value;
        }


        public static int ReadInt(string prompt, int min, int max)
        {
            Output.DisplayPrompt(prompt);
            return ReadInt(min, max);
        }

        public static int ReadInt(int min, int max)
        {
            int value = ReadInt();

            while (value < min || value > max)
            {
                Output.DisplayPrompt("Please enter an integer between {0} and {1} (inclusive)", min, max);
                value = ReadInt();
            }
            return value;
        }

        public static int ReadInt()
        {
            string input = ReadLine();
            int value;

            while (!int.TryParse(input, out value))
            {
                Output.DisplayPrompt("Please enter an integer");
                input = ReadLine();
            }
            return value;
        }


        public static string ReadString(string prompt)
        {
            Output.DisplayPrompt(prompt);
            var input = ReadLine();
            return input;
        }

        public static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            Type type = typeof(TEnum);

            if (!type.IsEnum)
                throw new ArgumentException("TEnum must be an enumerated type");

            Output.WriteLine(prompt);
            Menu menu = new Menu();

            TEnum choice = default(TEnum);
            foreach (var value in Enum.GetValues(type))
                menu.Add(Enum.GetName(type, value), () => { choice = (TEnum)value; });
            menu.Display();

            if (Settings.ShowSelectedEnumText)
            {
                //go to previous line after "Choose an option: [N]"
                int cursorPosition = 18 + menu.SelectedIndex.ToString().Length;
                Console.SetCursorPosition(cursorPosition, Console.CursorTop - 1); 
                Output.WriteLine(Settings.UserInputColor, $" ({choice})");
            }

            return choice;
        }

        public static double ReadDouble(string prompt)
        {
            Output.DisplayPrompt(prompt);
            string input = ReadLine();
            double value;

            while (!double.TryParse(input, out value))
            {
                Output.DisplayPrompt("Please enter a numeric value");
                input = ReadLine();
            }
            return value;
        }
        public static double ReadDouble(string prompt, float min, float max)
        {
            double value = ReadDouble(prompt);
            while (value < min || value > max)
            {
                Output.DisplayPrompt("Please enter a numeric value between {0} and {1} (inclusive)", min, max);
                value = ReadDouble(prompt);
            }
            return value;
        }


        public static DateTime ReadDate(string prompt)
        {
            Output.DisplayPrompt(prompt);
            string input = ReadLine();
            DateTime value;
            while (!DateTime.TryParse(input, out value))
            {
                Output.DisplayPrompt("Please enter a valid date-time");
                input = ReadLine();
            }
            return value;
        }
        public static DateTime ReadDate(string prompt, DateTime min, DateTime max)
        {
            DateTime value = ReadDate(prompt);
            while (value < min || value > max)
            {
                Output.DisplayPrompt("Please enter a date between {0} and {1} (inclusive)", min, max);
                value = ReadDate(prompt);
            }
            return value;
        }

        public static bool ReadBool(string prompt)
        {
            var input = Input.ReadEnum<YesNoEnum>(prompt);
            return (input == YesNoEnum.Yes);
        }


    }
}
