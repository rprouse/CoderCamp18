using System;
using AsciiArt.ImageConverters;

namespace AsciiArt
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = args.Length > 0 ? args[0] : "octocat.png";

            var converter = new FileConverter(new Ascii());
            string output = converter.ConvertFile(filename);
            Console.WriteLine(output);

            WaitToExit();
        }

        private static void WaitToExit()
        {
            Console.WriteLine();
            Console.WriteLine("*** Press ENTER to Exit ***");
            Console.ReadLine();
        }
    }
}
