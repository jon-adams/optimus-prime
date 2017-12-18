using System;
using System.Collections.Generic;
using System.Linq;

namespace Optimus.Prime.Services {
    /// <summary>
    ///     &quot;The sieve of Eratosthenes is a simple, ancient algorithm for finding all prime numbers up to any 
    ///     given limit.&quot;
    /// </summary>
    /// <remarks>
    ///     Much more efficient than <see cref="BasicPrimeNumberGenerator"/>
    /// </remarks>
    /// <seealso cref="https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes"/>
    public class SieveOfEratosthenesPrimeNumberGenerator : IPrimeNumberGenerator {
        public IList<int> generate(int startingValue, int endingValue) {
            throw new NotImplementedException();
        }

        public bool isPrime(int value) {
            throw new NotImplementedException();
        }
    }
}
