using Tracer.Core.Tracers;
using Tracer.Core.Models;

namespace Tracer.Core.Tests.TestClasses
{
    public class ThreadTracerTestClass
    {
        private ITracer<ThreadInfo> _tracer;

        public ThreadTracerTestClass(ITracer<ThreadInfo> tracer)
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
            _tracer.StartTrace();
            Thread.Sleep(300);
            _tracer.StopTrace();
        }

        public void T4()
        {
            T2();
            T3();
        }
    }
}
