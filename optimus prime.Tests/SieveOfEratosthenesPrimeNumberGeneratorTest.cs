using NUnit.Framework;
using Optimus.Prime.Services;

namespace Optimus.Prime.Tests {
    [TestFixture]
    public class SieveOfEratosthenesPrimeNumberGeneratorTest {
        [Test]
        public void TestInvalidIsPrime() {
            Assert.IsFalse(new SieveOfEratosthenesPrimeNumberGenerator().isPrime(-1));
        }

        [Test]
        public void TestOneIsNotPrimeViaARangeGenerator() {
            Assert.AreEqual(0, new SieveOfEratosthenesPrimeNumberGenerator().generate(1, 1).Count);
        }

        [Test]
        public void TestTwoIsPrime() {
            Assert.IsTrue(new SieveOfEratosthenesPrimeNumberGenerator().isPrime(2));
        }

        [Test]
        public void TestThreeIsPrime() {
            Assert.IsTrue(new SieveOfEratosthenesPrimeNumberGenerator().isPrime(3));
        }

        [Test]
        public void TestFourIsNotPrime() {
            Assert.IsFalse(new SieveOfEratosthenesPrimeNumberGenerator().isPrime(4), "4 is not a prime number");
        }

        [Test]
        public void TestRequiredFirstTwentySixPrimeList() {
            Assert.AreEqual(
                new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101 },
                new SieveOfEratosthenesPrimeNumberGenerator().generate(1, 101),
                "First 25 prime numbers did not match");
        }

        [Test]
        public void TestRequiredFirstTwentySixPrimeListWithReversedRange() {
            Assert.AreEqual(
                new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101 },
                new SieveOfEratosthenesPrimeNumberGenerator().generate(101, 1),
                "First 25 prime numbers did not match when range supplied in reverse");
        }

        [Test]
        public void TestRequiredHigherPrimeList() {
            // expected list provided by http://www.primos.mat.br/primeiros_10000_primos.txt
            Assert.AreEqual(new[] { 7901, 7907, 7919 },
                new SieveOfEratosthenesPrimeNumberGenerator().generate(7900, 7920),
                "Prime number results for the range of 7900<=>7920 did not match expected");
        }

        [Test]
        public void TestMultiplePrimeChecks() {
            // expected list provided by http://www.primos.mat.br/primeiros_10000_primos.txt
            var generator = new SieveOfEratosthenesPrimeNumberGenerator();
            Assert.AreEqual(new[] { 7901, 7907, 7919 },
                generator.generate(7900, 7920),
                "Prime number results for the range of 7900<=>7920 did not match expected");
            Assert.AreEqual(new[] { 7901, 7907, 7919, 7927, 7933, 7937, 7949, 7951, 7963, 7993, 8009 },
                generator.generate(7900, 8010),
                "Prime number results for the range of 7900<=>8010 did not match expected");
            Assert.AreEqual(new[] { 7901, 7907, 7919 },
                generator.generate(7900, 7920),
                "Prime number results for the range of 7900<=>7920 did not match expected");
        }

        [Test]
        public void TestMatchWithBasicGenerator() {
            Assert.AreEqual(new BasicPrimeNumberGenerator().generate(20010, 21120),
                new SieveOfEratosthenesPrimeNumberGenerator().generate(20010, 21120),
                "Prime number BasicPrimeNumberGenerator and SieveOfEratosthenesPrimeNumberGenerator did not match results");
        }
    }
}
