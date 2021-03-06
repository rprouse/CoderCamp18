﻿// **********************************************************************************
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
using AsciiArt.Interfaces;

namespace AsciiArt.ImageConverters
{
    public class InvertedAscii : Ascii, IAsciiConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ascii"/> class.
        /// </summary>
        /// <param name="pixelsPerCharacter">The pixels per character.</param>
        public InvertedAscii(int pixelsPerCharacter) 
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
            // Convert the transparent background to black
            if (pixel.A == 0)
                pixel = Color.White;

            // 0.0 is black 1.0 is white
            float brightness = 1f - pixel.GetBrightness();
            int i = MAP.Length - (int)(brightness * MAP.Length);
            if (i > MAP.Length - 1)
                i = MAP.Length - 1;

            return MAP.Substring(i,1);
        }
    }
}