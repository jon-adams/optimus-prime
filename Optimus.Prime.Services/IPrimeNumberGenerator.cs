using System.Collections.Generic;

namespace Optimus.Prime.Services {
    /// <summary>
    /// Prime number generator
    /// </summary>
    public interface IPrimeNumberGenerator {
        /// <summary>
        ///     Generate an ordered list of primes, inclusize of the <paramref name="startingValue"/> and <paramref name="endingValue"/>
        /// </summary>
        /// <param name="startingValue">the inclusive start of the generator range</param>
        /// <param name="endingValue">the inclusive end of the generator range</param>
        /// <returns>an ordered list of primes in the specified range</returns>
        IList<int> generate(int startingValue, int endingValue);

        /// <summary>
        ///     Determines if the specified integer is a prime
        /// </summary>
        /// <param name="value">
        ///     a value to check; demo requirements didn't specify if negatives should be normalized to absolute or
        ///     not, so deciding to have value less than 2 always return false)
        /// </param>
        /// <returns>true if the integer is prime; false otherwise</returns>
        bool isPrime(int value);
    }
}
