using Tracer.Core.Tracers;
using Tracer.Core.Tests.TestClasses;

namespace Tracer.Core.Tests
{
    public class ThreadTracerTests
    {
        [Test]
        public void SingleMethodCallMethodNameShouldBeT1()
        {
            // arrange
            var threadTracer = new ThreadTracer(2);
            var testClass = new ThreadTracerTestClass(threadTracer);
            string expected = "T1";
            // act
            testClass.T1();
            string actual = threadTracer.GetTraceResult().Methods[0].Name;
            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void WithInnerMethodMethodTimeShouldBe500()
        {
            // arrange
            var threadTracer = new ThreadTracer(2);
            var testClass = new ThreadTracerTestClass(threadTracer);
            long expected = 500;
            // act
            testClass.T2();
            long actual = threadTracer.GetTraceResult().Methods[0].Time;
            // assert
            Assert.That(actual, Is.EqualTo(expected).Within(25));
        }


        [Test]
        public void ThreadInfo_ThreadIdCheck_MethodsCountShouldBe2()
        {
            // arrange
            var threadTracer = new ThreadTracer(2);
            var testClass = new ThreadTracerTestClass(threadTracer);
            int idExpected = Environment.CurrentManagedThreadId;
            int countExpected = 2;
            // act
            testClass.T4();
            var result = threadTracer.GetTraceResult();
            // assert
            Assert.Multiple(() =>
            {
                Assert.That(result.ThreadId, Is.EqualTo(idExpected));
                Assert.That(result.Methods.Count, Is.EqualTo(countExpected));
            });
        }

        [Test]
        public void ThreadInfo_ThreadTimeShouldBeSumOfMethodsTime()
        {
            // arrange 
            var threadTracer = new ThreadTracer(2);
            var testClass = new ThreadTracerTestClass(threadTracer);
            long expected = 800;
            // act
            testClass.T4();
            long actual = threadTracer.GetTraceResult().Time;
            // assert
            Assert.That(actual, Is.EqualTo(expected).Within(50));
        }
    }
}
