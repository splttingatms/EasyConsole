using EasyConsole;

namespace Demo.Pages
{
    class Page1Ai : Page
    {
        public Page1Ai(Program program)
            : base("Page 1Ai", program)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Hello from Page 1Ai");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
