using NUnit.Framework;
using Optimus.Prime.Services;

namespace Optimus.Prime.Tests {
    [TestFixture]
    public class BasicPrimeNumberGeneratorTest {
        [Test]
        public void TestSimpleIsPrime() {
            IPrimeNumberGenerator generator = new BasicPrimeNumberGenerator();
            Assert.IsTrue(generator.isPrime(3));
        }

        [Test]
        public void TestInvalidIsPrime() {
            IPrimeNumberGenerator generator = new BasicPrimeNumberGenerator();
            Assert.IsFalse(generator.isPrime(-1));
        }

        [Test]
        public void TestSimpleIsNotPrime() {
            IPrimeNumberGenerator generator = new BasicPrimeNumberGenerator();
            Assert.IsFalse(generator.isPrime(4), "4 is not a prime number");
        }

        [Test]
        public void TestRequiredFirstTwentySixPrimeList() {
            IPrimeNumberGenerator generator = new BasicPrimeNumberGenerator();
            Assert.AreEqual(
                new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101 },
                generator.generate(1, 101),
                "First 25 prime numbers did not match");
        }

        [Test]
        public void TestRequiredFirstTwentySixPrimeListWithReversedRange() {
            IPrimeNumberGenerator generator = new BasicPrimeNumberGenerator();
            Assert.AreEqual(
                new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101 },
                generator.generate(101, 1),
                "First 25 prime numbers did not match when range supplied in reverse");
        }

        [Test]
        public void TestRequiredHigherPrimeList() {
            IPrimeNumberGenerator generator = new BasicPrimeNumberGenerator();
            // expected list provided by http://www.primos.mat.br/primeiros_10000_primos.txt
            Assert.AreEqual(new[] { 7901, 7907, 7919 },
                generator.generate(7900, 7920),
                "Prime number results for the range of 7900<=>7920 did not match expected");
        }
    }
}
