using NUnit.Framework;

namespace Optimus.Prime.Tests {
    [TestFixture]
    public class ProgramTest {
        [Test]
        public void TestMissingArgs() {
            Assert.DoesNotThrow(() => Program.Main(new string[0]));
            Assert.DoesNotThrow(() => Program.Main(new[] { "1" }));
        }

        [Test]
        public void TestInvalidArgs() {
            Assert.DoesNotThrow(() => Program.Main(new[] { "-1", "not a number" }));
        }

        [Test]
        public void TestOptionalButInvalidArgs() {
            Assert.DoesNotThrow(() => Program.Main(new[] { "1", "2", "someval" }));
        }

        [Test]
        public void TestInverseArgs() {
            Assert.DoesNotThrow(() => Program.Main(new[] { "2", "1" }));
        }

        [Test]
        public void TestOptionalArgs() {
            Assert.DoesNotThrow(() => Program.Main(new[] { "2", "1", "r" }));
        }
    }
}
