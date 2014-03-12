// **********************************************************************************
// The MIT License (MIT)
// 
// Copyright (c) 2014 Rob Prouse
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 
// **********************************************************************************

using System.Drawing;
using System.Text;

namespace AsciiArt.ImageConverters
{
    public class Ascii : IAsciiConverter
    {
        protected const string MAP = "@MBHENR#KWXDFPQASUZbdehx*8Gm&04LOVYkpq5Tagns69owz$CIu23Jcfry%1v7l+it[] {}?j|()=~!-/<>\"^_';,:`. ";
        private int _pixelsPerCharacter;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ascii"/> class.
        /// </summary>
        /// <param name="pixelsPerCharacter">The pixels per character.</param>
        public Ascii(int pixelsPerCharacter)
        {
            _pixelsPerCharacter = pixelsPerCharacter;
        }

        /// <summary>
        /// Converts the given image to ascii art
        /// </summary>
        /// <param name="image">The image.</param>
        /// <returns></returns>
        public string Convert(Image image)
        {
            using (var resized = ResizeImage(image))
            {
                var sb = new StringBuilder(resized.Width * resized.Height);
                for (int y = 0; y < resized.Height; y++)
                {
                    for (int x = 0; x < resized.Width; x++)
                    {
                        string s = GetCharForPixel(resized.GetPixel(x, y));
                        sb.Append(s);
                    }
                    sb.AppendLine();
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// Gets the character for pixel based on its brightness.
        /// </summary>
        /// <param name="pixel">The pixel.</param>
        /// <returns>An ascii representation of the pixel</returns>
        public virtual string GetCharForPixel(Color pixel)
        {
            // Convert the transparent background to white
            if (pixel.A == 0)
                pixel = Color.White;

            // 0.0 is black 1.0 is white
            float brightness = pixel.GetBrightness();
            int i = MAP.Length - (int)(brightness * MAP.Length);
            if (i > MAP.Length - 1)
                i = MAP.Length - 1;

            return MAP.Substring(i,1);;
        }

        /// <summary>
        /// Resizes the image down so that each pixel in the returned image is equivalent to
        /// 8x8 pixels in the original
        /// </summary>
        /// <param name="image">The image.</param>
        /// <returns></returns>
        private Bitmap ResizeImage(Image image)
        {
            return new Bitmap(image, new Size(image.Width / _pixelsPerCharacter, image.Height / _pixelsPerCharacter));
        }
    }
}