using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Prime {
    class Program {
        public static void Main(string[] args) {
            // `args` should accept two integers for a range; an optional third integer may select the generator to use
            if (args.Length < 2) {
                Console.WriteLine("Must include two integers for an inclusive range to check for primes");
                return;
            }

            // TODO: parse args

            // TODO: create requested algorithm runner
                        
            var results = new List<int>(); // TODO: start algorithm instead of this stub

            Console.WriteLine(string.Join(", ", results));
        }
    }
}
