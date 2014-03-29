using System;
using System.Drawing;
using AsciiArt.ImageConverters;
using Ninject;

namespace AsciiArt
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = args.Length > 0 ? args[0] : "octocat.png";

            var converter = Factory.Kernel.Get<IFileConverter>();
            string output = converter.ConvertFile(filename);
            Console.WriteLine(output);

            WaitToExit();
        }

        private static void WaitToExit()
        {
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("*** Press ENTER to Exit ***");
            Console.ReadLine();
        }
    }
}
