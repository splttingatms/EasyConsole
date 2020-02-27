using EasyConsole;
using System;

namespace Demo.Pages
{
    class InputPage : Page
    {
        public InputPage(Program program)
            : base("Input", program)
        {
        }

        public override void Display()
        {
            base.Display();

            //var intInput = Input.ReadInt("Enter integer:", 0, 1000000);
            var strInput = Input.ReadString("Enter text:");
            var floatInput = Input.ReadDouble("Enter numeric value:");
            var floatInput2 = Input.ReadDouble("Enter numeric value:", -20, 34.7f);
            var enumInput2 = Input.ReadEnum<Fruit>("Select a fruit");
            var boolInput = Input.ReadBool("Are you mad?");
            var dateInput = Input.ReadDate("Enter date:");
            var dateInput2 = Input.ReadDate("Enter date:", DateTime.Parse("2020-01-01"), DateTime.Now);

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }

    enum Fruit
    {
        Apple,
        Banana,
        Coconut
    }
}
