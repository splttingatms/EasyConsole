using EasyConsole;

namespace Demo.Pages
{
    class MainPage : MenuPage
    {
        public MainPage(Program program)
            : base("Main Page", program,
                  new Option("Page 1", () => program.NavigateTo<Page1>()),
                  new Option("Page 2", () => program.NavigateTo<Page2>()),
                  new Option("Input", () => program.NavigateTo<InputPage>()))
        {
        }
    }
}
