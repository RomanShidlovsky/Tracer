using Tracer.Core;
using Tracer.Core.Tests.TestClasses;

namespace Tracer.Core.Tests
{
    public class TracerTests
    {
        [Test]
        public void SingleThread_TimeShouldBe600()
        {
            // arrange
            var tracer = new Tracers.Tracer();
            var testClass = new TracerTestClass(tracer);
            long expectedTime = 600;
            int expectedCount = 1;
            // act
            testClass.PublicMethod();
            var res = tracer.GetTraceResult();
            // assert
            Assert.Multiple(() =>
            {
                Assert.That(res.Threads.Count, Is.EqualTo(expectedCount));
                Assert.That(res.Threads[0].Time, Is.EqualTo(expectedTime).Within(50));
            });
        }

        [Test]
        public void MultiThread_ThreadIdShouldBeDifferent()
        {
            // arrange
            var tracer = new Tracers.Tracer();
            var testClass = new TracerTestClass(tracer);
            var innerClass = new InnerTracerTestClass(tracer);
            int expectedCount = 2;
            // act
            testClass.PublicMethod();
            var task = Task.Run(() => testClass.PublicMethod());
            testClass.PublicMethod();
            innerClass.InnerMethod();
            task.Wait();
            var res = tracer.GetTraceResult();
            // assert
            Assert.Multiple(() =>
            {
                Assert.That(res.Threads.Count, Is.EqualTo(expectedCount));
                Assert.That(res.Threads[0].ThreadId, Is.Not.EqualTo(res.Threads[1].ThreadId));
            });
        }
    }
}
