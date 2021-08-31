using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ConsolePrinter
{
    public class NicePrinter
    {
        private readonly BigInteger _pi;
        private const string Nice = "69420";

        public NicePrinter()
        {
            _pi = PiCalculator.GetPi(2000000, 10);
        }

        
        // credit for picalc: https://gist.github.com/quietlynn/2028653
        private static class PiCalculator
        {
            // Pi = 16 * arctan(1/5) - 4 * arctan(1/239)
            public static BigInteger GetPi(int digits, int iterations)
            {
                return 16 * BigMath.ArcTan1OverX(5, digits).ElementAt(iterations)
                       - 4 * BigMath.ArcTan1OverX(239, digits).ElementAt(iterations);
            }
        }

        private static class BigMath
        {
            //arctan(x) = x - x^3/3 + x^5/5 - x^7/7 + x^9/9 - ...
            public static IEnumerable<BigInteger> ArcTan1OverX(int x, int digits)
            {
                var mag = BigInteger.Pow(10, digits);
                var sum = BigInteger.Zero;
                bool sign = true;
                for (int i = 1; true; i += 2)
                {
                    var cur = mag / (BigInteger.Pow(x, i) * i);
                    if (sign)
                    {
                        sum += cur;
                    }
                    else
                    {
                        sum -= cur;
                    }
                    yield return sum;
                    sign = !sign;
                }
            }
        }
        public int GetNice()
        {
            var numbersAfterComma = _pi.ToString()[1..];
            int result = 0;
            
            for (int i = 0; i < numbersAfterComma.Length - Nice.Length; i++)
            {
                if 
                (
                    numbersAfterComma[i] == Nice[0] 
                    && numbersAfterComma [i + 1] == Nice[1]
                    && numbersAfterComma [i + 2] == Nice[2]
                    && numbersAfterComma [i + 3] == Nice[3]
                    && numbersAfterComma [i + 4] == Nice[4]
                )
                {
                    result++;
                }
            }

            return result;
        }
    }
}