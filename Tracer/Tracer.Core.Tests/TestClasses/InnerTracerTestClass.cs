using Tracer.Core;
using Tracer.Core.Models;

namespace Tracer.Core.Tests.TestClasses
{
    public class InnerTracerTestClass
    {
        private ITracer<TraceResult> _tracer;

        internal InnerTracerTestClass(ITracer<TraceResult> tracer)
        {
            _tracer = tracer;
        }

        public void InnerMethod()
        {
            _tracer.StartTrace();
            Thread.Sleep(300);
            _tracer.StopTrace();
        }
    }
}
