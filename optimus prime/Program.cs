using System;
using System.Diagnostics;
using Optimus.Prime.Services;

namespace Optimus.Prime {
    class Program {
        public static void Main(string[] args) {
            int first, second;
            string third;
            if (!ParseArgs(args, Console.WriteLine, out first, out second, out third)) {
                return;
            }

            Execute(Console.WriteLine, first, second, third);
        }

        internal static bool ParseArgs(string[] args, Action<string> output, out int first, out int second, out string third) {
            first = -1;
            second = -1;
            third = "";

            // `args` should accept two integers for a range; an optional third integer may select the generator to use
            if (args.Length < 2) {
                output("Must include two positive integers for an inclusive range to check for primes");
                return false;
            }

            if (!int.TryParse(args[0], out first) ||
                !int.TryParse(args[1], out second)) {
                output("Must include two positive integers (32-bit max) for an inclusive range to check for primes");
                return false;
            }

            // normalize algorithm argument, if available
            third = args.Length > 2 ? args[2].Trim().ToLowerInvariant() : null;
            return true;
        }

        internal static void Execute(Action<string, object, object> output, int first, int second, string third) {
            // should use an IoC container for picking the algorithms instead of using `new`, but skipping that step for simplicity of this demo

            var stopwatch = new Stopwatch();
            if (third == "race") {
                // for fun, let's race algorithms:
                var generator = new BasicPrimeNumberGenerator();
                var generator2 = new SieveOfEratosthenesPrimeNumberGenerator();
                var stopwatch2 = new Stopwatch();
                stopwatch.Start();
                var results = generator.generate(first, second);
                stopwatch.Stop();
                stopwatch2.Start();
                var results2 = generator2.generate(first, second);
                stopwatch2.Stop();
                output("\nBasicPrimeNumberGenerator               generated in {0}ms ({1} ticks)", stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks);
                output("SieveOfEratosthenesPrimeNumberGenerator generated in {0}ms ({1} ticks)", stopwatch2.ElapsedMilliseconds, stopwatch2.ElapsedTicks);
            } else {
                // pick a generator
                var generator = third == "alternate" || third == "a" || third == "eratosthenes"
                                ? (IPrimeNumberGenerator)new SieveOfEratosthenesPrimeNumberGenerator()
                                : new BasicPrimeNumberGenerator();

                stopwatch.Start();
                // start generating
                var results = generator.generate(first, second);
                stopwatch.Stop();

                output("Results: {0}{1}", string.Join(", ", results), "");
                output("\nResults generated in {0}ms ({1} ticks)", stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks);
            }
        }
    }
}
