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

using System;
using System.Drawing;
using AsciiArt.Interfaces;

namespace AsciiArt.ImageConverters
{
    public class AnsiiAscii : Ascii, IAsciiConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ascii"/> class.
        /// </summary>
        /// <param name="pixelsPerCharacter">The pixels per character.</param>
        public AnsiiAscii(int pixelsPerCharacter) 
            : base(pixelsPerCharacter)
        {
        }

        /// <summary>
        /// Gets the character for pixel based on its brightness.
        /// </summary>
        /// <param name="pixel">The pixel.</param>
        /// <returns>
        /// An ascii representation of the pixel
        /// </returns>
        public override string GetCharForPixel(Color pixel)
        {
            // Convert the transparent background
            if (pixel.A == 0)
                return " ";

            return RgbToAnsiiForegroundCode(pixel) + "█";
        }

        /// <summary>
        /// These are the 16 DOS ASII color codes
        /// </summary>
        private static Color[] ansi16 = new[]
        {
            Color.FromArgb( 0x00, 0x00, 0x00 ),
            Color.FromArgb( 0x80, 0x00, 0x00 ),
            Color.FromArgb( 0x00, 0x80, 0x00 ),
            Color.FromArgb( 0x80, 0x80, 0x00 ),
            Color.FromArgb( 0x00, 0x00, 0x80 ),
            Color.FromArgb( 0x80, 0x00, 0x80 ),
            Color.FromArgb( 0x00, 0x80, 0x80 ),
            Color.FromArgb( 0xc0, 0xc0, 0xc0 ),
            Color.FromArgb( 0x80, 0x80, 0x80 ),
            Color.FromArgb( 0xff, 0x00, 0x00 ),
            Color.FromArgb( 0x00, 0xff, 0x00 ),
            Color.FromArgb( 0xff, 0xff, 0x00 ),
            Color.FromArgb( 0x00, 0x00, 0xff ),
            Color.FromArgb( 0xff, 0x00, 0xff ),
            Color.FromArgb( 0x00, 0xff, 0xff ),
            Color.FromArgb( 0xff, 0xff, 0xff ),
        };

        private string RgbToAnsiiForegroundCode(Color color)
        {
            var res = RgbToIndexed(color);
            if( res >= 8 )
                return string.Format("\x1B[{0};1m", (res + 30 - 8) );

            return string.Format("\x1B[{0}m", (res + 30) );
        }

        private string RgbToAnsiiBackgroundCode(Color color)
        {
            var res = RgbToIndexed(color);
            return string.Format( "\x1B[{0}m", (res >= 8 ? (res+40-8) : (res+40)));
        }

        private int RgbToIndexed(Color color)
        {
            double minDistance = 0;
            int result = 0;
            for (int i = 0; i < 16; i++)
            {
                // Determine how far away the given color is from the ansii color
                Color ansii = ansi16[i];
                var distance = Math.Pow(Math.Abs(ansii.R - color.R), 2) + 
                               Math.Pow(Math.Abs(ansii.G - color.G), 2) +
                               Math.Pow(Math.Abs(ansii.B - color.B), 2);

                // If it is a match, return it
                if (distance == 0)
                    return i;

                if (minDistance == 0 || minDistance > distance)
                {
                    minDistance = distance;
                    result = i;
                }
            }
            return result;
        }
    }
}