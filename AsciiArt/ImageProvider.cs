using System.Drawing;
using AsciiArt.Interfaces;

namespace AsciiArt
{
    public class ImageProvider : IImageProvider
    {
        #region Implementation of IImageProvider

        public Image GetImage( string filename )
        {
            return Image.FromFile(filename);
        }

        #endregion
    }
}