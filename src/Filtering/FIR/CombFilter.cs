﻿/* SoundUtils

LICENSE - The MIT License (MIT)

Copyright (c) 2014 Tomona Nanase

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;

namespace SoundUtils.Filtering.FIR
{
    public class CombFilter : ImpulseResponse
    {
        #region -- Public Properties --
        public double Delay { get; set; }

        public double Amplifier { get; set; }
        #endregion

        #region -- Protected Methods --
        protected override void GenerateValues(double[] array, int size)
        {
            double progress = this.Delay;

            for (int i = 0, j = 0; i < size; j++)
            {
                double value = Math.Ceiling(progress);
                double alpha = 1.0 + progress - value;
                double beta = 1.0 - alpha;
                double amp = Math.Pow(this.Amplifier, j);

                i = (int)value - 1;
                progress += this.Delay;

                if (i < size)
                {
                    array[i] += alpha * amp;

                    if (i + 1 < size)
                        array[i + 1] += beta * amp;
                    else break;                    
                }
                else break;
            }
        }
        #endregion
    }
}
