using System;
using System.Diagnostics;
using Optimus.Prime.Services;

namespace Optimus.Prime {
    class Program {
        public static void Main(string[] args) {
            // `args` should accept two integers for a range; an optional third integer may select the generator to use
            if (args.Length < 2) {
                Console.WriteLine("Must include two positive integers for an inclusive range to check for primes");
                return;
            }

            int first = -1;
            int second = -1;
            if (!int.TryParse(args[0], out first) ||
                !int.TryParse(args[1], out second)) {
                Console.WriteLine("Must include two positive integers for an inclusive range to check for primes");
                return;
            }

            // normalize algorithm argument, if available
            var thirdArg = args.Length > 2 ? args[2]?.Trim()?.ToLowerInvariant() : null;

            // pick a generator
            var generator = thirdArg == "alternate" || thirdArg == "a" || thirdArg == "eratosthenes"
                            ? (IPrimeNumberGenerator)new SieveOfEratosthenesPrimeNumberGenerator()
                            : new BasicPrimeNumberGenerator();

            // start generating
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var results = generator.generate(first, second);
            stopwatch.Stop();

            Console.WriteLine(string.Join(", ", results));
            Console.WriteLine("\nResults generated in {0}ms ({1} ticks)", stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks);
        }
    }
}
