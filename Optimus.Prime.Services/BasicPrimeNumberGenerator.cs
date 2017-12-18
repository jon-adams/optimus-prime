using System.Collections.Generic;
using System.Linq;

namespace Optimus.Prime.Services {
    /// <summary>
    ///     Generate prime numbers the good old fashioned way. Brute force, inefficient (especially with the interface 
    ///     being able to be called different ways for the same data), but at least works without significant memory 
    ///     usage.
    /// </summary>
    /// <remarks>
    ///     Not good for large primes. Can take a very long time.
    /// </remarks>
    public class BasicPrimeNumberGenerator : IPrimeNumberGenerator {
        // woo boy this can be inefficient; but it works... just don't use it for large primes
        public IList<int> generate(int startingValue, int endingValue) {
            var start = startingValue;
            var end = endingValue;
            if (startingValue > endingValue) {
                // reverse range to be natural
                start = endingValue;
                end = startingValue;
            }

            // loop through each value in range; does not store previously calculated primes on each run.
            // WILDLY inefficient! Demonstration purposes only.
            return Enumerable.Range(start, end).Where(x => isPrime(x)).ToList();
        }

        // I'm not a mathematician. This is my port of the pseudo-code for a basic engine from https://en.wikipedia.org/wiki/Primality_test
        public bool isPrime(int value) {
            if (value < 2) {
                // negatives, 1 (which isn't considered prime by definition)
                return false;
            }

            if (value < 4) {
                // 2, 3
                return true;
            }

            if (value % 2 == 0 || value % 3 == 0) {
                // evens or divisible by 3
                return false;
            }

            // all the easy stuff checked; now brute force the rest
            var i = 5;
            while (i * i <= value) {
                if (value % i == 0 || value % (i + 2) == 0) {
                    return false;
                }

                // checked everything with multiple of 1-5 by this point; jump in increments of 6
                i = i + 6;
            }

            return true;
        }
    }
}
