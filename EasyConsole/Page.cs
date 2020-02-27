using System;
using System.Linq;

namespace EasyConsole
{
    public abstract class Page
    {
        public string Title { get; private set; }

        public Program Program { get; set; }

        public Page(string title, Program program)
        {
            Title = title;
            Program = program;
        }

        public virtual void Display()
        {
            Console.ForegroundColor = Settings.TitleColor;

            if (Program.History.Count > 1 && Program.BreadcrumbHeader)
            {
                string breadcrumb = null;
                foreach (var title in Program.History.Select((page) => page.Title).Reverse())
                    breadcrumb += title + " > ";
                breadcrumb = breadcrumb.Remove(breadcrumb.Length - 3);
                Console.WriteLine(breadcrumb);
                Console.WriteLine(new string('-', breadcrumb.Length)); //add line
            }
            else
            {
                Console.WriteLine(Title);
                Console.WriteLine(new string('-', Title.Length)); //add line
            }
            Console.ResetColor();

        }
    }
}
