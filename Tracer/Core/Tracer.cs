using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Tracer.Core
{
    public class Tracer : ITracer
    {
        private Stopwatch _stopWatch;
        public Tracer()
        {
            _stopWatch = new Stopwatch();
        }

        public void StartTrace()
        {
            StackTrace stackTrace = new StackTrace();
            _stopWatch.Reset();
            _stopWatch.Start();
        }

        public void StopTrace()
        {
            _stopWatch.Stop();
        }

        public TraceResult GetTraceResult()
        {
            StackTrace st = new StackTrace();
            StackFrame? sf = st.GetFrame(1);

            return new TraceResult(sf.GetMethod().Name, sf.GetMethod().DeclaringType.Name, _stopWatch.ElapsedMilliseconds);
        }
    }
}
