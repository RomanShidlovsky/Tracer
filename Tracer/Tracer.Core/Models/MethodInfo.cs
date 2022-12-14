namespace Tracer.Core.Models
{
    public class MethodInfo
    {
        public string Name { get; }
        public string ClassName { get; }
        public long Time { get; private set; }

        private List<MethodInfo> _methods;
        public IReadOnlyList<MethodInfo> Methods 
        {
            get { return _methods; } 
        }

        public MethodInfo(string name = "", string className = "", long time = 0)
        {
            Name = name;
            ClassName = className;
            Time = time;
            _methods = new List<MethodInfo>();
        }

        public MethodInfo(List<MethodInfo> methods)
        {
            Name = "";
            ClassName = "";
            Time = 0;
            _methods = methods;
        }

        internal void SetTime(long time)
        {
            Time = time;
        }

        internal void AddMethod(MethodInfo info)
        {
            _methods.Add(info);
        }
    }
}
