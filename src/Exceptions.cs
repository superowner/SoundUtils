﻿/* SoundUtils

LICENSE - The MIT License (MIT)

Copyright (c) 2017 Tomona Nanase

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

namespace SoundUtils
{
    public class InvalidSamplingRateException : ArgumentOutOfRangeException
    {
        #region -- Constructors --

        public InvalidSamplingRateException(string paramName)
            : base(paramName, "サンプリング周波数は 0.0 (Hz) よりも大きな実数である必要があります。")
        {
        }

        public InvalidSamplingRateException(string paramName, double actualValue)
            : base(paramName, actualValue, "サンプリング周波数は 0.0 (Hz) よりも大きな実数である必要があります。")
        {
        }

        #endregion
    }

    public class InvalidFrequencyException : ArgumentOutOfRangeException
    {
        #region -- Constructors --

        public InvalidFrequencyException(string paramName)
            : base(paramName, "与えられた周波数は有効な範囲にありません。")
        {
        }

        public InvalidFrequencyException(string paramName, double actualValue)
            : base(paramName, actualValue, "与えられた周波数は有効な範囲にありません。")
        {
        }

        #endregion
    }
}
