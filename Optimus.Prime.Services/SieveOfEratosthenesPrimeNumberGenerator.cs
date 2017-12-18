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
        private BitArray primes;
        
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
            return Enumerable.Range(start, end - start + 1).Where(i => primes.Get(i)).Select(i => i).ToList();
        }

        public bool isPrime(int value) {
            if (value < 2) {
                return false;
            }

            // assumes that primes calculated up to length-1
            if (primes != null && value < primes.Length - 1) {
                // cool, all values calculated already; just return the value
                primes.Get(value);
            }

            // fresh array of trues (with one extra hanging to make index lookups match the algorithm a little easier)
            primes = new BitArray(value + 1);
            primes.SetAll(true);
            // except for 0, 1 which are not calculated and always are not prime by definition
            primes.Set(0, false);
            primes.Set(1, false);

            // store square root so it doesn't recalculate every iteration
            var sqrt = Math.Sqrt(value);
            for (var i = 2; i <= sqrt; i++) {
                if (!primes.Get(i)) {
                    // already flagged as not a prime; no need to recalculate
                    continue;
                }

                var iSq = i * 2;
                var j = iSq;
                for (var k = 0; j <= value; j = iSq + (k * i), k++) {
                    primes.Set(j, false);
                }
            }

            return primes.Get(value);
        }
    }
}
