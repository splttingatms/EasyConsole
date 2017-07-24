# EasyConsole [![NuGet](https://img.shields.io/nuget/v/EasyConsole.svg)](https://www.nuget.org/packages/EasyConsole/)
EasyConsole is a library to make it easier for developers to build a simple menu interface for a .NET console application.

![Program Demo](https://i.imgur.com/Hlc2QoI.gif)

### Features
* Automatically numbered menus
* Fluent creation of menus
* Input/Output helpers

## Quick Start
### Menu
The base functionality of the library is to provide an easy way to create console menus. A `Menu` consists of `Options` that will be presented to a user for selection. An option contains a name, that will be displayed to the user, and a callback function to invoke if the user selects the option. Render the menu in the console using the `Display()` method.

```c#
var menu = new EasyConsole.Menu()
      .Add("foo", () => Console.WriteLine("foo selected"))
      .Add("bar", () => Console.WriteLine("bar selected"));
menu.Display();
```
![Menu Demo](http://i.imgur.com/GXeYOm0.png)

### Utilities - Input/Output
EasyConsole also provides input and output utilities to abstract the concept of dealing with the Console.

The `Output` class adds helper methods to control the color of text in the console.
```c#
Output.WriteLine("default");
Output.WriteLine(ConsoleColor.Red, "red");
Output.WriteLine(ConsoleColor.Green, "green");
Output.WriteLine(ConsoleColor.Blue, "blue");
```
![Output Utility Demo](http://i.imgur.com/tfeS18X.png)

The `Input` class adds helper methods that prompt the user for input. The utility takes care of displaying prompt text and handling parsing logic. For example, non-numeric input will be rejected by `ReadInt()` and the user will be re-prompted.
```c#
object input = Input.ReadString("Please enter a string:");
Output.WriteLine("You wrote: {0}", input);

input = Input.ReadInt("Please enter an integer (between 1 and 10):", min: 1, max: 10);
Output.WriteLine("You wrote: {0}", input);
```
![Input Utility Demo](http://i.imgur.com/NLIr0mY.png)

### Program
All of these features can be put together to create complex programs with nested menus. A console program consists of a main `Program` class that contains `Pages`. The `Program` class is a navigator of pages and will keep a history of pages that a user is navigating through. Think of it as your browser history. To create a program you must subclass the `Program` class and add any `Pages` in the constructor. _Note_: Before exiting the constructor, you must set one of the pages as the _main_ page where the program should start.

```c#
class DemoProgram : Program
{
    public DemoProgram()
        : base("EasyConsole Demo", breadcrumbHeader: true)
    {
        AddPage(new MainPage(this));
        AddPage(new Page1(this));
        AddPage(new Page1A(this));
        AddPage(new Page1B(this));
        AddPage(new Page2(this));

        SetPage<MainPage>();
    }
}
```
A `Page` can display any type of data, but the subclass `MenuPage` was created to speed up the creation of pages that display menus. Simply pass in all of the options you want displayed into the `options` parameter in the constructor.

```c#
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
```

As you can see, navigation is handled by the `Program` class. As you navigate through to different pages, the history is logged. You can then invoke `NavigateBack()` if you would like to go back to the previous page.

## Example Project
The source code contains an example console demo under the [Demo directory](https://github.com/splttingatms/EasyConsole/tree/master/Demo). It offers a demo with nested menu options as well as an example of how to prompt the user for input.

