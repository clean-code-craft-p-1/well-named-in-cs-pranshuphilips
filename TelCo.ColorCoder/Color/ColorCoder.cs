using System;

namespace TelCo.ColorCoder
{
    /// <summary>
    /// Provides methods to map between color pairs and pair numbers.
    /// </summary>
    public static class ColorCoder
    {
        /// <summary>
        /// Gets the color pair for a given pair number.
        /// </summary>
        /// <param name="pairNumber">Pair number (1-25).</param>
        /// <returns>Corresponding color pair.</returns>
        public static ColorPair GetColorFromPairNumber(int pairNumber)
        {
            int minorSize = ColorMap.MinorColors.Length;
            int majorSize = ColorMap.MajorColors.Length;

            if (pairNumber < 1 || pairNumber > minorSize * majorSize)
            {
                throw new ArgumentOutOfRangeException($"PairNumber {pairNumber} is out of range.");
            }

            int zeroBasedPairNumber = pairNumber - 1;
            int majorIndex = zeroBasedPairNumber / minorSize;
            int minorIndex = zeroBasedPairNumber % minorSize;

            return new ColorPair
            {
                MajorColor = ColorMap.MajorColors[majorIndex],
                MinorColor = ColorMap.MinorColors[minorIndex]
            };
        }

        /// <summary>
        /// Gets the pair number for a given color pair.
        /// </summary>
        /// <param name="pair">The color pair.</param>
        /// <returns>Corresponding pair number.</returns>
        public static int GetPairNumberFromColor(ColorPair pair)
        {
            int majorIndex = Array.IndexOf(ColorMap.MajorColors, pair.MajorColor);
            int minorIndex = Array.IndexOf(ColorMap.MinorColors, pair.MinorColor);

            if (majorIndex == -1 || minorIndex == -1)
            {
                throw new ArgumentException($"Unknown Colors: {pair}");
            }

            return majorIndex * ColorMap.MinorColors.Length + minorIndex + 1;
        }
    }
}
