using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Optimus.Prime;

namespace Optimus.Prime.Tests {
    [TestFixture]
    public class ProgramTest {
        [Test]
        public void Test() {
            Assert.DoesNotThrow(() => Program.Main(new[] { "1" }));
        }
    }
}
