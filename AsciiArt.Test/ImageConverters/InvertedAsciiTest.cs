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

#region Using Directives

using System;
using System.Drawing;
using AsciiArt.ImageConverters;
using NUnit.Framework;

#endregion

namespace AsciiArt.Test.ImageConverters
{
    [TestFixture]
    public class InvertedAsciiTest
    {
        private InvertedAscii _ascii;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            _ascii = new InvertedAscii();
        }

        [Test]
        [TestCaseSource("TestPixels")]
        public void TestGetCharForPixel(Color pixel, char expectedChar)
        {
            char c = _ascii.GetCharForPixel(pixel);
            Assert.That(c, Is.EqualTo(expectedChar));
        }

        private static object[] TestPixels =
        {
            new object[] { Color.White, ' ' },
            new object[] { Color.Transparent, ' ' },
            new object[] { Color.Black, '@' }
        };
    }
}