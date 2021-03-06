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
using System.Linq;

namespace SoundUtils.Filtering.IIR
{
    /// <summary>
    /// 特定の周波数を強調させるリゾネーターを生成します。
    /// </summary>
    public class Resonator : InfiniteImpulseResponse
    {
        #region -- Public Properties --
        /// <summary>
        /// 強調させる周波数を格納した配列を取得または設定します。
        /// </summary>
        public double[] Frequencies { get; set; }

        /// <summary>
        /// 増幅度を取得または設定します。
        /// </summary>
        public double Amplifier { get; set; }

        /// <summary>
        /// 強調の尖鋭度を取得または設定します。
        /// </summary>
        public double Strength { get; set; }
        #endregion

        #region -- Constructors --
        /// <summary>
        /// パラメータを指定せずに新しい Resonator クラスのインスタンスを初期化します。
        /// </summary>
        public Resonator()
        {
            Amplifier = 1.0;
            Strength = double.PositiveInfinity;
            Frequencies = new double[0];
        }
        #endregion

        #region -- Protected Methods --
        /// <summary>
        /// 指定された配列に size だけの長さでインパルス応答を生成します。
        /// </summary>
        /// <param name="array">インパルス応答が生成される配列。</param>
        /// <param name="size">生成される長さ。</param>
        protected override void GenerateValues(double[] array, int size)
        {
            CheckFrequencies();

            var amp = Amplifier / (size / 2.0);

            Array.Clear(array, 0, size);

            if (Math.Abs(Strength) < double.Epsilon)
                array[0] = amp;
            else
                foreach (var frequency in Frequencies)
                    for (var i = 0; i < size; i++)
                        array[i] += Math.Sin(i * frequency * 2.0 * Math.PI / SamplingRate) * amp *
                                    Math.Exp(-Math.Pow(i, 2.0) / Math.Pow(Strength, 2.0));
        }
        #endregion

        #region -- Private Methods --

        private void CheckFrequencies()
        {
            foreach (var frequency in Frequencies.Where(frequency => frequency < 0.0 || frequency > SamplingRate))
                throw new InvalidFrequencyException(nameof(Frequencies), frequency);
        }

        #endregion
    }
}
