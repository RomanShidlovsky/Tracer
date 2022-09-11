using Tracer.Core;
using Tracer.Core.Models;

namespace Tracer.Core.Tests.TestClasses
{
    public class TracerTestClass
    {
        private InnerTracerTestClass _inner;
        private ITracer<TraceResult> _tracer;

        internal TracerTestClass(ITracer<TraceResult> tracer)
        {
            _tracer = tracer;
            _inner = new InnerTracerTestClass(_tracer);
        }

        public void PublicMethod()
        {
            _tracer.StartTrace();
            _inner.InnerMethod();
            Thread.Sleep(100);
            PrivateMethod();
            _tracer.StopTrace();
        }

        private void PrivateMethod()
        {
            _tracer.StartTrace();
            Thread.Sleep(200);
            _tracer.StopTrace();
        }
    }
}
