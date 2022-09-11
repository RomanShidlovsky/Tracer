using Tracer.Core;
using Tracer.Core.Models;

namespace Tracer.Core.Tests.TestClasses
{
    public class MethodTracerTestClass
    {
        private ITracer<long> _tracer;

        internal MethodTracerTestClass(ITracer<long> tracer)
        {
            _tracer = tracer;
        }

        public void T1()
        {
            _tracer.StartTrace();
            Thread.Sleep(300);
            _tracer.StopTrace();
        }

        public void T2()
        {
            _tracer.StartTrace();
            Thread.Sleep(200);
            T3();
            _tracer.StopTrace();
        }

        private void T3()
        {
            Thread.Sleep(300);
        }
    }
}
