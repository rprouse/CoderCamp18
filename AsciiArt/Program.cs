using System;
using System.Drawing;
using AsciiArt.ImageConverters;

namespace AsciiArt
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = args.Length > 0 ? args[0] : "octocat.png";

            try
            {
                using (var image = Image.FromFile(filename))
                {
                    var ascii = new Ascii();
                    var str = ascii.Convert(image);
                    Console.Write(str);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine( "Error converting image. " + e.Message );
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("*** Press ENTER to Exit ***");
            Console.ReadLine();
        }
    }
}
