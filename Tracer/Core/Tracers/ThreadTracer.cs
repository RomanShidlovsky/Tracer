using System.Diagnostics;
using System.Collections.Concurrent;
using Tracer.Core.Models;

namespace Tracer.Core.Tracers
{
    public class ThreadTracer : ITracer <ReadOnlyThreadInfo>
    {
        private class MethodResource
        {
            public MethodInfo MethodInfo { get; set; }
            public MethodTracer MethodTracer { get; set; }

            public MethodResource(MethodInfo methodInfo)
            {
                MethodInfo = methodInfo;
                MethodTracer = new MethodTracer();
            }
        }

        private readonly int _frameNumber = 2;
        private Stack<MethodResource> _resources = new();

        public void StartTrace()
        {
            MethodInfo info = GetMethodInfo();
            MethodResource methodResource = new(info);
            _resources.Push(methodResource);
            methodResource.MethodTracer.StartTrace();
        }

        public void StopTrace()
        {
            
        }

        public ReadOnlyThreadInfo GetTraceResult()
        {

        }

        private MethodInfo GetMethodInfo()
        {
            StackTrace stackTrace = new();
            StackFrame? stackFrame = stackTrace.GetFrame(_frameNumber);

            if (stackFrame != null)
            {
                var method = stackFrame.GetMethod();
                return new MethodInfo(method!.Name, method!.DeclaringType!.Name);
            }
            return new MethodInfo();
        }
    }
}
