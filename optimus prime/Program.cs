using System;
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

            // pick a generator
            // TODO: load alternate generator if requested
            IPrimeNumberGenerator generator = new BasicPrimeNumberGenerator();

            // start generating
            var results = generator.generate(first, second);

            Console.WriteLine(string.Join(", ", results));
        }
    }
}
