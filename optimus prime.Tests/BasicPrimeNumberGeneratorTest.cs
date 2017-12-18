using NUnit.Framework;
using Optimus.Prime.Services;

namespace Optimus.Prime.Tests {
    [TestFixture]
    public class BasicPrimeNumberGeneratorTest {
        [Test]
        public void TestSimpleIsPrime() {
            Assert.IsTrue(new BasicPrimeNumberGenerator().isPrime(3));
        }

        [Test]
        public void TestInvalidIsPrime() {
            Assert.IsFalse(new BasicPrimeNumberGenerator().isPrime(-1));
        }

        [Test]
        public void TestSimpleIsNotPrime() {
            Assert.IsFalse(new BasicPrimeNumberGenerator().isPrime(4), "4 is not a prime number");
        }

        [Test]
        public void TestRequiredFirstTwentySixPrimeList() {
            Assert.AreEqual(
                new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101 },
                new BasicPrimeNumberGenerator().generate(1, 101),
                "First 25 prime numbers did not match");
        }

        [Test]
        public void TestRequiredFirstTwentySixPrimeListWithReversedRange() {
            Assert.AreEqual(
                new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101 },
                new BasicPrimeNumberGenerator().generate(101, 1),
                "First 25 prime numbers did not match when range supplied in reverse");
        }

        [Test]
        public void TestRequiredHigherPrimeList() {
            // expected list provided by http://www.primos.mat.br/primeiros_10000_primos.txt
            Assert.AreEqual(new[] { 7901, 7907, 7919 },
                new BasicPrimeNumberGenerator().generate(7900, 7920),
                "Prime number results for the range of 7900<=>7920 did not match expected");
        }
    }
}
