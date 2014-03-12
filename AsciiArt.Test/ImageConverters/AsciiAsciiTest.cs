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

#region Using Directives

using System;
using System.Drawing;
using AsciiArt.ImageConverters;
using NUnit.Framework;

#endregion

namespace AsciiArt.Test.ImageConverters
{
    [TestFixture]
    public class AsciiAsciiTest
    {
        private AnsiiAscii _ascii;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            _ascii = new AnsiiAscii(8);
        }

        [Test]
        [TestCaseSource("TestPixels")]
        public void TestGetCharForPixel(Color pixel, string expected)
        {
            string c = _ascii.GetCharForPixel(pixel);
            Assert.That(c, Is.StringStarting(expected));
        }

        private static object[] TestPixels =
        {
            // Transparent
            new object[] { Color.Transparent, " " },

            // Exact matches
            new object[] { Color.FromArgb( 0x00, 0x00, 0x00 ), "\x1B[30m" },
            new object[] { Color.FromArgb( 0x80, 0x00, 0x00 ), "\x1B[31m" },
            new object[] { Color.FromArgb( 0x00, 0x80, 0x00 ), "\x1B[32m" },
            new object[] { Color.FromArgb( 0x80, 0x80, 0x00 ), "\x1B[33m" },
            new object[] { Color.FromArgb( 0x00, 0x00, 0x80 ), "\x1B[34m" },
            new object[] { Color.FromArgb( 0x80, 0x00, 0x80 ), "\x1B[35m" },
            new object[] { Color.FromArgb( 0x00, 0x80, 0x80 ), "\x1B[36m" },
            new object[] { Color.FromArgb( 0xc0, 0xc0, 0xc0 ), "\x1B[37m" },
            new object[] { Color.FromArgb( 0x80, 0x80, 0x80 ), "\x1B[30;1m" },
            new object[] { Color.FromArgb( 0xff, 0x00, 0x00 ), "\x1B[31;1m" },
            new object[] { Color.FromArgb( 0x00, 0xff, 0x00 ), "\x1B[32;1m" },
            new object[] { Color.FromArgb( 0xff, 0xff, 0x00 ), "\x1B[33;1m" },
            new object[] { Color.FromArgb( 0x00, 0x00, 0xff ), "\x1B[34;1m" },
            new object[] { Color.FromArgb( 0xff, 0x00, 0xff ), "\x1B[35;1m" },
            new object[] { Color.FromArgb( 0x00, 0xff, 0xff ), "\x1B[36;1m" },
            new object[] { Color.FromArgb( 0xff, 0xff, 0xff ), "\x1B[37;1m" },

            // Near matches
            new object[] { Color.FromArgb( 0x00, 0x22, 0x00 ), "\x1B[30m" },
            new object[] { Color.FromArgb( 0x88, 0x00, 0x00 ), "\x1B[31m" },
            new object[] { Color.FromArgb( 0x20, 0x80, 0x00 ), "\x1B[32m" },
            new object[] { Color.FromArgb( 0x99, 0x80, 0x00 ), "\x1B[33m" },
            new object[] { Color.FromArgb( 0x20, 0x00, 0x80 ), "\x1B[34m" },
            new object[] { Color.FromArgb( 0x80, 0x20, 0x80 ), "\x1B[35m" },
            new object[] { Color.FromArgb( 0x00, 0x88, 0x80 ), "\x1B[36m" },
            new object[] { Color.FromArgb( 0xc0, 0xc5, 0xc0 ), "\x1B[37m" },
            new object[] { Color.FromArgb( 0x85, 0x80, 0x80 ), "\x1B[30;1m" },
            new object[] { Color.FromArgb( 0xff, 0x22, 0x00 ), "\x1B[31;1m" },
            new object[] { Color.FromArgb( 0x00, 0xff, 0x22 ), "\x1B[32;1m" },
            new object[] { Color.FromArgb( 0xff, 0xff, 0x22 ), "\x1B[33;1m" },
            new object[] { Color.FromArgb( 0x00, 0x00, 0xee ), "\x1B[34;1m" },
            new object[] { Color.FromArgb( 0xff, 0x00, 0xee ), "\x1B[35;1m" },
            new object[] { Color.FromArgb( 0x00, 0xff, 0xee ), "\x1B[36;1m" },
            new object[] { Color.FromArgb( 0xff, 0xff, 0xee ), "\x1B[37;1m" },
        };
    }
}