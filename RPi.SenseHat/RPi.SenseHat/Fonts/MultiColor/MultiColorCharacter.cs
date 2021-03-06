﻿////////////////////////////////////////////////////////////////////////////
//
//  This file is part of RPi.SenseHat
//
//  Copyright (c) 2019, Mattias Larsson
//
//  Permission is hereby granted, free of charge, to any person obtaining a copy of
//  this software and associated documentation files (the "Software"), to deal in
//  the Software without restriction, including without limitation the rights to use,
//  copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the
//  Software, and to permit persons to whom the Software is furnished to do so,
//  subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
//  INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
//  PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
//  HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
//  OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
//  SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;

namespace Emmellsoft.IoT.RPi.SenseHat.Fonts.MultiColor
{
    /// <summary>
    /// A color font character.
    /// </summary>
    public class MultiColorCharacter : Character
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="symbol">The unicode character.</param>
        /// <param name="image">The pixels array. Must not be larger than 8x8 pixels.</param>
        /// <param name="transparencyColor">The color that represents transparency.</param>
        public MultiColorCharacter(char symbol, Image image, Color? transparencyColor = null)
            : base(symbol, image.Width)
        {
            if (image.Height > 8)
            {
                throw new ArgumentException("The pixels array must not be taller than 8 pixels!");
            }

            Image = image;
            TransparencyColor = transparencyColor;
        }

        /// <summary>
        /// The pixels array.
        /// </summary>
        public Image Image { get; }

        /// <summary>
        /// The color that represents transparency.
        /// </summary>
        public Color? TransparencyColor { get; }
    }
}
