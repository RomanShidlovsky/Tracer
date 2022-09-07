using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Core.Models
{
    public class ReadOnlyThreadInfo
    {
        public int ThreadId { get; }
        public long Time { get; }
        public IReadOnlyList<ReadOnlyMethodInfo> Methods { get; }

        public ReadOnlyThreadInfo(int threadId, long time, List<ReadOnlyMethodInfo> methods)
        {
            ThreadId = threadId;
            Time = time;
            Methods = methods;
        }
    }
}
