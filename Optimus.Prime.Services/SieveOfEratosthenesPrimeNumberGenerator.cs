using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Optimus.Prime.Services {
    /// <summary>
    ///     &quot;The sieve of Eratosthenes is a simple, ancient algorithm for finding all prime numbers up to any 
    ///     given limit.&quot;
    ///     
    ///     <para>Not thread safe.</para>
    /// </summary>
    /// <remarks>
    ///     Much more efficient than <see cref="BasicPrimeNumberGenerator"/>.
    /// </remarks>
    /// <seealso cref="https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes"/>
    public class SieveOfEratosthenesPrimeNumberGenerator : IPrimeNumberGenerator {
        // range to store all calculated values that are not prime (indexes 0 and 1 are always false)
        private BitArray range;

        /// <summary>
        ///     Since the primes are calculated up to the limit, can efficiently store only up to the limit that is
        ///     requested. If anything equal or lower is requested, can just pick the value out no extra calculation.
        ///     But if anything higher is requested, then need to resize the array up, while retaining any pre-
        ///     calculated values.
        /// </summary>
        /// <param name="limit">the upper limit of the prime check</param>
        private void CheckAndResizeAvailableRange(int limit) {
            // fresh array of trues (with one extra hanging to make index lookups match the algorithm a little easier)
            var allTrue = new BitArray(limit + 1);
            allTrue.SetAll(true);
            // except for 0, 1 which are not calculated and always are not prime by definition; shouldn't matter since 
            // all methods currently exit early with false anyway... but just to be safe:
            allTrue.Set(0, false);
            allTrue.Set(1, false);

            if (range == null) {
                range = allTrue;
                return;
            }

            if (range.Length + 1 < limit) {
                // not big enough

                // would like to just use the new all true array then AND the differences so old false values are 
                // retained—but the .Net And() method doesn't allow different sizes...
                // allTrue.And(range);
                // so just loop through all the existing values to copy old school
                for (var i = 0; i < range.Length; i++) {
                    allTrue.Set(i, range.Get(i));
                }

                range = allTrue;
                return;
            }
        }

        public IList<int> generate(int startingValue, int endingValue) {
            var start = startingValue;
            var end = endingValue;
            if (startingValue > endingValue) {
                // reverse range to be natural
                start = endingValue;
                end = startingValue;
            }

            if (end < 2) {
                return new List<int>(0);
            }

            // The sieve calculates up to the end. Check the end, which naturally checks everything before it.
            var lastPrime = isPrime(end);

            /* 
             * Then only spit out the results for the requested range. This LINQ does loop twice, but only goes over 
             * the actual primes in the second loop (converting the index to an int in the output list), so it
             * shouldn't be too bad.
             */
            return Enumerable.Range(start, end - start + 1).Where(i => range.Get(i)).Select(i => i).ToList();
        }

        public bool isPrime(int value) {
            if (value < 2) {
                return false;
            }

            // assumes that the range length has always been calculated; makes this NOT thread-safe, and be careful
            // with any internal changes to make sure this short-cut logic is not broken
            if (range != null && value < range.Length) {
                // cool, all values calculated already; just return the value
                range.Get(value);
            }

            CheckAndResizeAvailableRange(value);

            // store square root so it doesn't recalculate every iteration
            var sqrt = Math.Sqrt(value);
            for (var i = 2; i <= sqrt; i++) {
                if (!range.Get(i)) {
                    // already flagged as not a prime; no need to recalculate
                    continue;
                }

                var iSq = i * 2;
                var j = iSq;
                for (var k = 0; j <= value; j = iSq + (k * i), k++) {
                    range.Set(j, false);
                }
            }

            return range.Get(value);
        }
    }
}
