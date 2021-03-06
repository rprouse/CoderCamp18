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

using System;
using AsciiArt.ImageConverters;
using AsciiArt.Interfaces;

namespace AsciiArt
{
    public class FileConverter
    {
        private IAsciiConverter _converter;
        private readonly IImageProvider _imageProvider;

        public FileConverter(IAsciiConverter converter, IImageProvider imageProvider)
        {
            _converter = converter;
            _imageProvider = imageProvider;
        }

        public string ConvertFile(string filename)
        {
            try
            {
                using(var image = _imageProvider.GetImage(filename))
                {
                    return _converter.Convert(image);
                }
            }
            catch (Exception e)
            {
                return string.Format("Error converting image. {0}", e.Message);
            }
        }
    }
}