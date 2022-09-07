using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Core.Models
{
    public class ReadOnlyMethodInfo
    {
        public string Name { get; }
        public string ClassName { get; }
        public int Time { get; }
        public IReadOnlyList<ReadOnlyMethodInfo> Methods { get; }

        public ReadOnlyMethodInfo(string name, string className, int time, List<ReadOnlyMethodInfo> methods)
        {
            Name = name;
            ClassName = className;
            Time = time;
            Methods = methods;
        }
    }
}
