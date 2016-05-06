namespace EasyConsole
{
    public static class StringExtensions
    {
        public static string Format(this string format, params object[] args)
        {
            return string.Format(format, args);
        }
    }
}
