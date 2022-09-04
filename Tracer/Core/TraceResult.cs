using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Core
{
    public class TraceResult
    {
        private readonly string _methodName;
        public string MethodName
        {
            get { return _methodName; }
        }

        private readonly string _className;
        public string ClassName
        {
            get { return _className; }
        }

        private readonly long _time;
        public long Time
        {
            get { return _time; }
        }

        public TraceResult(string methodName, string className, long time)
        {
            _methodName = methodName;
            _className = className;
            _time = time;
        }
    }
}
