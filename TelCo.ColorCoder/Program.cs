using System;
using System.Diagnostics;
using System.Drawing;

namespace TelCo.ColorCoder
{
    /// <summary>
    /// Test class for ColorCoder functionality.
    /// </summary>
    class Program
    {
        static void Main()
        {
            RunTests();
        }

        /// <summary>
        /// Runs test cases to verify color coding.
        /// </summary>
        static void RunTests()
        {
            TestGetColorFromPairNumber(4, Color.White, Color.Brown);
            TestGetColorFromPairNumber(5, Color.White, Color.SlateGray);
            TestGetColorFromPairNumber(23, Color.Violet, Color.Green);

            TestGetPairNumberFromColor(Color.Yellow, Color.Green, 18);
            TestGetPairNumberFromColor(Color.Red, Color.Blue, 6);
        }

        static void TestGetColorFromPairNumber(int pairNumber, Color expectedMajor, Color expectedMinor)
        {
            ColorPair pair = ColorCoder.GetColorFromPairNumber(pairNumber);
            Console.WriteLine($"[In] Pair Number: {pairNumber}, [Out] Colors: {pair}");
            Debug.Assert(pair.MajorColor == expectedMajor);
            Debug.Assert(pair.MinorColor == expectedMinor);
        }

        static void TestGetPairNumberFromColor(Color major, Color minor, int expectedPairNumber)
        {
            ColorPair pair = new ColorPair { MajorColor = major, MinorColor = minor };
            int pairNumber = ColorCoder.GetPairNumberFromColor(pair);
            Console.WriteLine($"[In] Colors: {pair}, [Out] Pair Number: {pairNumber}");
            Debug.Assert(pairNumber == expectedPairNumber);
        }
    }
}
