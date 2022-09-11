using Tracer.Core.Tracers;
using Tracer.Core.Tests.TestClasses;

namespace Tracer.Core.Tests
{
    public class MethodTracerTests
    {
        [Test]
        public void GetTraceResult_Returned300()
        {
            // arrange
            var methodTracer = new MethodTracer();
            var testClass = new MethodTracerTestClass(methodTracer);
            long expected = 300;
            // act
            testClass.T1();
            long actual = methodTracer.GetTraceResult();
            // assert
            Assert.That(actual, Is.EqualTo(expected).Within(25));
        }

        [Test]
        public void GetTraceResult_WithInnerMethod_Returned500()
        {
            // arrange
            var methodTracer = new MethodTracer();
            var testClass = new MethodTracerTestClass(methodTracer);
            long expected = 500;
            // act
            testClass.T2();
            long actual = methodTracer.GetTraceResult();
            // assert
            Assert.That(actual, Is.EqualTo(expected).Within(25));
        }
    }
}