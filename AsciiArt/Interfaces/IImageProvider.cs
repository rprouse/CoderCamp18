using System.Drawing;

namespace AsciiArt.Interfaces
{
    public interface IImageProvider
    {
        Image GetImage(string filename);
    }
}