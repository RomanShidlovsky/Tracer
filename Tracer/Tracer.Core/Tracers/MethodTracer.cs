using System.Diagnostics;

namespace Tracer.Core.Tracers
{
    public class MethodTracer : ITracer<long>
    {
        private readonly Stopwatch _stopwatch = new();
        public void StartTrace()
        {
            _stopwatch.Start();
        }

        public void StopTrace()
        {
            _stopwatch.Stop();
        }

        public long GetTraceResult()
        {
            return _stopwatch.ElapsedMilliseconds;
        }

    }
    
}
