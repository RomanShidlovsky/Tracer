using Tracer.Core;
using Tracer.Core.Models;

namespace Tracer.Example.Classes
{
    public class Bar
    {
        private ITracer<TraceResult> _tracer;

        internal Bar(ITracer<TraceResult> tracer)
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
