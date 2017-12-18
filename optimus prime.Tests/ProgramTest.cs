using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Optimus.Prime.Tests {
    [TestFixture]
    public class ProgramTest {
        // simple little action mock; due to Action<> and not having an interface for Program, easier to stub this than use mocking with Moq
        private class ConsoleWriteActionStub {
            public List<string> Messages { get; set; } = new List<string>(0);

            public void Action(string value) {
                Messages.Add(value);
            }

            public void ActionWithArgs(string value, object obj1, object obj2) {
                Messages.Add(string.Format(value, obj1, obj2));
            }
        }

        [Test]
        public void TestMissingArgs() {
            Assert.DoesNotThrow(() => Program.Main(new string[0]));
            Assert.DoesNotThrow(() => Program.Main(new[] { "1" }));
        }

        [Test]
        public void TestMissingArgsSimple() {
            var outputMock = new ConsoleWriteActionStub();

            int first, second;
            string third;
            Assert.DoesNotThrow(() => Program.ParseArgs(new string[0], outputMock.Action, out first, out second, out third));
            Assert.DoesNotThrow(() => Program.ParseArgs(new[] { "1" }, outputMock.Action, out first, out second, out third));
            Assert.AreEqual(2, outputMock.Messages.Count, "Action call count did not match expected");
            Assert.AreEqual("Must include two positive integers for an inclusive range to check for primes", outputMock.Messages.First());
        }


        [Test]
        public void TestInvalidArgs() {
            Assert.DoesNotThrow(() => Program.Main(new[] { "-1", "not a number" }));
        }

        [Test]
        public void TestInvalidInt() {
            Assert.DoesNotThrow(() => Program.Main(new[] { (11L + Int32.MaxValue).ToString(), "not a number" }));
        }

        [Test]
        public void TestOptionalButInvalidArgs() {
            Assert.DoesNotThrow(() => Program.Main(new[] { "1", "2", "someval" }));
        }

        [Test]
        public void TestInverseArgsSimple() {
            Assert.DoesNotThrow(() => Program.Main(new[] { "2", "1" }));
        }

        [Test]
        public void TestInverseArgs() {
            var outputMock = new ConsoleWriteActionStub();
            Assert.DoesNotThrow(() => Program.Execute(outputMock.ActionWithArgs, 2, 1, ""));
            Assert.AreEqual(2, outputMock.Messages.Count, "Action call count did not match expected");
            Assert.IsTrue(outputMock.Messages[0].StartsWith("Results"), "Did not output any results");
            Assert.IsTrue(outputMock.Messages[1].StartsWith("\nResults generated"), "Result timer output missing");
        }

        [Test]
        public void TestOptionalArgs() {
            Assert.DoesNotThrow(() => Program.Main(new[] { "2", "1", "alternate" }));
        }

        [Test]
        public void TestRaceArgs() {
            Assert.DoesNotThrow(() => Program.Main(new[] { "20002", "1", "race" }));
        }
    }
}
